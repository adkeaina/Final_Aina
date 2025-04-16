using Entertainment.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Entertainment.API.Controllers;

[ApiController]
[Route("api/")]
public class EntertainmentController : ControllerBase
{
    private EntertainmentDbContext _context;
    
    public EntertainmentController(EntertainmentDbContext context)
    {
        _context = context;
    }

    [HttpGet("entertainers")]
    public IActionResult GetEntertainers()
    {
        var result = _context.Entertainers
            .Select(e => new
            {
                e.EntertainerId,
                e.EntStageName,
                BookingsCount = _context.Engagements.Count(en => en.EntertainerId == e.EntertainerId),
                LastBookingDate = _context.Engagements
                    .Where(en => en.EntertainerId == e.EntertainerId)
                    .OrderByDescending(en => en.StartDate)
                    .Select(en => en.StartDate)
                    .FirstOrDefault()
            })
            .ToList();

        return Ok(result);
    }

    [HttpGet("entertainers/{entertainerId}")]
    public IActionResult GetEntertainer(int entertainerId)
    {
        return Ok(_context.Entertainers.Find(entertainerId));
    }

    [HttpPost("entertainers")]
    public IActionResult AddEntertainer([FromBody] Entertainer newEnt)
    {
        if (string.IsNullOrWhiteSpace(newEnt.EntStageName) ||
            string.IsNullOrWhiteSpace(newEnt.EntSsn) ||
            string.IsNullOrWhiteSpace(newEnt.EntEmailAddress) ||
            newEnt.DateEntered == null)
        {
            return BadRequest("Stage Name, SSN, Email Address, and Date Entered are required.");
        }

        int maxId = _context.Entertainers.Any()
            ? _context.Entertainers.Max(e => e.EntertainerId)
            : 0;

        newEnt.EntertainerId = maxId + 1;

        _context.Entertainers.Add(newEnt);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetEntertainer), new { entertainerId = newEnt.EntertainerId }, newEnt);
    }

    [HttpPut("entertainers/{entertainerId}")]
    public IActionResult UpdateEntertainer(int entertainerId, [FromBody] Entertainer updatedEnt)
    {
        var existing = _context.Entertainers.Find(entertainerId);
        if (existing == null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(updatedEnt.EntStageName) ||
            string.IsNullOrWhiteSpace(updatedEnt.EntSsn) ||
            string.IsNullOrWhiteSpace(updatedEnt.EntEmailAddress) ||
            updatedEnt.DateEntered == null)
        {
            return BadRequest("Stage Name, SSN, Email Address, and Date Entered are required.");
        }

        // Update fields
        existing.EntStageName = updatedEnt.EntStageName;
        existing.EntSsn = updatedEnt.EntSsn;
        existing.EntStreetAddress = updatedEnt.EntStreetAddress;
        existing.EntCity = updatedEnt.EntCity;
        existing.EntState = updatedEnt.EntState;
        existing.EntZipCode = updatedEnt.EntZipCode;
        existing.EntPhoneNumber = updatedEnt.EntPhoneNumber;
        existing.EntWebPage = updatedEnt.EntWebPage;
        existing.EntEmailAddress = updatedEnt.EntEmailAddress;
        existing.DateEntered = updatedEnt.DateEntered;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("entertainers/{entertainerId}")]
    public IActionResult DeleteEntertainer(int entertainerId)
    {
        var entertainer = _context.Entertainers.Find(entertainerId);
        if (entertainer == null)
            return NotFound();

        _context.Entertainers.Remove(entertainer);
        _context.SaveChanges();
        return NoContent();
    }
}