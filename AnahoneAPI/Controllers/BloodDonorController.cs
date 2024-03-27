using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppContext = AnahoneAPI.Data.AppContext;
using AnahoneAPI.Models;
namespace AnahoneAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BloodDonorController : ControllerBase
{
    private readonly AppContext _context; 

    public BloodDonorController(AppContext context)
    {
        _context = context;
    }

    // GET: api/BloodDonors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BloodDonor>>> GetBloodDonors()
    {
        return await _context.BloodDonors.ToListAsync();
    }

    // GET: api/BloodDonors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BloodDonor>> GetBloodDonor(int id)
    {
        var bloodDonor = await _context.BloodDonors.FindAsync(id);

        if (bloodDonor == null)
        {
            return NotFound();
        }

        return bloodDonor;
    }

    // PUT: api/BloodDonors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBloodDonor(int id, BloodDonor bloodDonor)
    {
        if (id != bloodDonor.DonorID)
        {
            return BadRequest();
        }

        _context.Entry(bloodDonor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BloodDonorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/BloodDonors
    [HttpPost]
    public async Task<ActionResult<BloodDonor>> PostBloodDonor(BloodDonor bloodDonor)
    {
        _context.BloodDonors.Add(bloodDonor);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetBloodDonor", new { id = bloodDonor.DonorID }, bloodDonor);
    }
    
    // DELETE: api/BloodDonors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBloodDonor(int id)
    {
        var bloodDonor = await _context.BloodDonors.FindAsync(id);
        if (bloodDonor == null)
        {
            return NotFound();
        }

        _context.BloodDonors.Remove(bloodDonor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    

    private bool BloodDonorExists(int id)
    {
        return _context.BloodDonors.Any(e => e.DonorID == id);
    }
}
