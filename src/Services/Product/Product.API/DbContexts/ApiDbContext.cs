using Microsoft.EntityFrameworkCore;

namespace Product.API.DbContexts;

public class ApiDbContext:DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
    {
    }
    public DbSet<Entities.Product> Products { get; set; }
}
