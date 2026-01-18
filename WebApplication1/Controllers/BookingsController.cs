using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingAPI.Data;
using BookingAPI.Dtos;
using BookingAPI.Errors;
using BookingAPI.Models;
using BookingAPI.Services;

namespace BookingAPI.Controllers;

[ApiController]
[Route("api/bookings")]

public class BookingsController : ControllerBase
{
    private int CurrentUserId => 1;
    private readonly AppDbContext _context;
    private readonly IBookingService _bookingService;

    //CONSTRUCTOR INJECTION
    public BookingsController(AppDbContext context, IBookingService bookingService)
    {
        _context = context;
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookingCreateDto dto)
    {
        try
        {
            var result = await _bookingService.CreateAsync(dto, CurrentUserId);
            return Ok(result);
        }
        catch (DomainException ex)
        {
            ModelState.AddModelError(ex.Code, ex.Message);
            return ValidationProblem(ModelState);
        }
    }
    //This endpoint does not:
    // - enforce business rules
    // - make decisions
    // - mutate state
    [HttpGet]
    public async Task<IActionResult> GetForCurrentUser()
    {
        var bookings = await _context.Bookings
            .Where(b => b.UserId == CurrentUserId)
            .OrderBy(b => b.StartTime)
            //projection happens in the query, entities never leave the backend.
            .Select(b => new BookingReadDto
            {
                Id = b.Id,
                ResourceId = b.ResourceId,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
            }
            )
            .ToListAsync();

        return Ok(bookings);
    }
    //This endpoint does not:
    // - enforce business rules
    // - make decisions
    // - mutate state
    [HttpGet("resource/{resourceId}")]
    public async Task<IActionResult> GetByResource(int resourceId)
    {
        var bookings = await _context.Bookings
            .Where(b => b.ResourceId == resourceId)
            .OrderBy(b => b.StartTime)
            .Select(b => new BookingReadDto
            {
                Id = b.Id,
                ResourceId = b.ResourceId,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
            }
            )
            .ToListAsync();

        return Ok(bookings);
    }
}