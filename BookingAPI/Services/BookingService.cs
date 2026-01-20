using Microsoft.EntityFrameworkCore;
using BookingAPI.Data;
using BookingAPI.Dtos;
using BookingAPI.Errors;
using BookingAPI.Models;
using BookingAPI.Services;
using BookingAPI;
public class BookingService : IBookingService
{
    private readonly AppDbContext _context;
    public BookingService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<BookingResponseDto> CreateAsync(BookingCreateDto dto, int userId)
    {
        var booking = new Booking
        {
            ResourceId = dto.ResourceId,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            UserId = userId
        };

        if (!await _context.Resources.AnyAsync(r => r.Id == booking.ResourceId))
            throw new DomainException("ResourceNotFound", "Resource does not exist.");

        if (booking.EndTime <= booking.StartTime)
            throw new DomainException("InvalidTimeRange", "EndTime must be after StartTime.");

        //Filters bookings for the same resource
        //Checks overlap logic
        //Asks: does any such booking exists?
        var overlapExists = await _context.Bookings.AnyAsync(b => b.ResourceId == booking.ResourceId && BookingOverlap.DoBookingsOverlap(booking.StartTime, booking.EndTime, b.StartTime, b.EndTime));

        if (overlapExists)
            throw new DomainException("BookingOverlap", "Resource is already booked for this time range.");

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return new BookingResponseDto
        {
            Id = booking.Id,
            ResourceId = booking.ResourceId,
            StartTime = booking.StartTime,
            EndTime = booking.EndTime
        };
    }
}
