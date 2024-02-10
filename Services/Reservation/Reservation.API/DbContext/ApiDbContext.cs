using Microsoft.EntityFrameworkCore;

namespace Reservation.API.DbContext;

public class ApiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Reservation.API.Entity.Reservation> Reservations { get; set; }

}