using Microsoft.EntityFrameworkCore;
using Reservation.API.DbContext;
using Reservation.API.Entity;

namespace Reservation.API.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly ApiDbContext _dbContext;

    public ReservationRepository(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CancellAsync(Guid id)
    {
        var reservation= await _dbContext.Reservations.SingleOrDefaultAsync(x=>x.Id==id);
        reservation.Status = ReservationStatus.Cancelled;
        _dbContext.Reservations.Update(reservation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Entity.Reservation> CreateAsync(Entity.Reservation reservation)
    {
        await _dbContext.AddAsync(reservation);
        await _dbContext.SaveChangesAsync();
        return reservation;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _dbContext.Reservations.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<Entity.Reservation>> GetAllAsync()
    {
        var reservations = await _dbContext.Reservations.ToListAsync();
        return reservations;
    }

    public async Task<Entity.Reservation> GetByIdAsync(Guid id)
    {
        return await _dbContext.Reservations.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Entity.Reservation> UpdateAsync(Entity.Reservation reservation)
    {
        _dbContext.Reservations.Update(reservation);
        await _dbContext.SaveChangesAsync();
        return reservation;
    }
}
