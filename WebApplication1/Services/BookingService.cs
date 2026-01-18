using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Errors;
using WebApplication1.Models;
using WebApplication1.Services;
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

        var overlapExists = await _context.Bookings.AnyAsync(b =>
        b.ResourceId == booking.ResourceId &&
        booking.StartTime < b.EndTime &&
        booking.EndTime > b.StartTime);

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
