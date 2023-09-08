using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Server.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
}