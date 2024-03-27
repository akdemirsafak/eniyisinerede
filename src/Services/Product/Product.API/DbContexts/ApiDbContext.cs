using Microsoft.EntityFrameworkCore;
using Product.API.Entities;

namespace Product.API.DbContexts;

public class ApiDbContext:DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
    {
    }
    public DbSet<Entities.Product> Products { get; set; }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {

        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IAuditableEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {

            if (entityEntry.State == EntityState.Added)
            {
                ((IAuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                ((IAuditableEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        
    }
}
