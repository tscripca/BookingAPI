using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingAPI.Data;
using BookingAPI.Models;
using System.Linq;

namespace BookingAPI.Controllers;

[ApiController]
[Route("api/resources")]
public class ResourcesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ResourcesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Resource resource)
    {
        _context.Resources.Add(resource);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = resource.Id }, resource);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var resource = await _context.Resources.FindAsync(id);

        if (resource == null)
            return NotFound();

        return Ok(resource);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var resources = await _context.Resources
            .OrderBy(r => r.Name)
            .ToListAsync();

        return Ok(resources);
    }
}
