using ChartsSignalRAndBlazor.Server.Data;
using ChartsSignalRAndBlazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChartsSignalRAndBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonelController : ControllerBase
{
    private readonly SatisDbContext _context;

    public PersonelController(SatisDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var personels = await _context.Personellers.ToListAsync();
        
        return Ok(personels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var personel = await _context.Personellers.FirstOrDefaultAsync(x => x.Id == id);

        return Ok(personel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Personeller personeller)
    {
        _context.Add(personeller);
        await _context.SaveChangesAsync();

        return Ok(personeller.Id);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Personeller personeller)
    {
        _context.Entry(personeller).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var personel = new Personeller { Id = id };
        _context.Remove(personel);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
