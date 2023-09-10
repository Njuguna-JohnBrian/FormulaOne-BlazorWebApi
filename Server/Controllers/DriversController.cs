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
}