using AnahoneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

using AppContext = AnahoneAPI.Data.AppContext;

namespace AnahoneAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LookingDonorControlle(AppContext context) : ControllerBase
{
    private readonly AppContext _context = context;

    // GET: api/LookingForDonors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LookingForDonor>>> GetLookingForDonors()
    {
        return await _context.LookingForDonors.ToListAsync();
    }

    // GET: api/LookingForDonors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LookingForDonor>> GetLookingForDonor(int id)
    {
        var lookingForDonor = await _context.LookingForDonors.FindAsync(id);

        if (lookingForDonor == null)
        {
            return NotFound();
        }

        return lookingForDonor;
    }

    // PUT: api/LookingForDonors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLookingForDonor(int id, LookingForDonor lookingForDonor)
    {
        if (id != lookingForDonor.DonorID)
        {
            return BadRequest();
        }

        _context.Entry(lookingForDonor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LookingForDonorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw; // Rethrow to surface the exception
            }
        }

        return NoContent();
    }

    // POST: api/LookingForDonors
    [HttpPost]
    public async Task<ActionResult<LookingForDonor>> PostLookingForDonor(LookingForDonor lookingForDonor)
    {
        try
        {
            _context.LookingForDonors.Add(lookingForDonor);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            // Handle potential database constraint violations
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }

        return CreatedAtAction("GetLookingForDonor", new { id = lookingForDonor.DonorID }, lookingForDonor);
    }

    // DELETE: api/LookingForDonors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLookingForDonor(int id)
    {
        var lookingForDonor = await _context.LookingForDonors.FindAsync(id);
        if (lookingForDonor == null)
        {
            return NotFound();
        }

        _context.LookingForDonors.Remove(lookingForDonor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LookingForDonorExists(int id)
    {
        return _context.LookingForDonors.Any(e => e.DonorID == id);
    }
}
    
