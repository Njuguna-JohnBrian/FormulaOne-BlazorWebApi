using FormulaOne.Server.Data;
using FormulaOne.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly ApiDbContext _context;

    public DriversController(ApiDbContext apiDbContext)
    {
        _context = apiDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Driver>>> GetDrivers()
    {
        var drivers = await _context.Drivers.ToListAsync();

        return Ok(drivers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> GetDriverDetails(int id)
    {
        var driver = await _context.Drivers.FirstOrDefaultAsync(dr => dr.Id == id);

        if (driver == null)
            return NotFound();

        return Ok(driver);
    }

    [HttpPost]
    public async Task<ActionResult> CreateDriver(Driver driver)
    {
        _context.Add(driver);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDriverDetails), driver, driver.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDriver(Driver driver, int id)
    {
        var driverExists = await _context.Drivers.FirstOrDefaultAsync(dr => dr.Id == driver.Id);

        if (driverExists == null)
            return NotFound();

        driverExists.Name = driver.Name;
        driverExists.RacingNb = driver.RacingNb;
        driverExists.Team = driver.Team;

        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var driverExists = await _context.Drivers.FirstOrDefaultAsync(dr => dr.Id == id);

        if (driverExists == null)
            return NotFound();

        _context.Remove(driverExists);

        return NoContent();
    }
}