namespace Reservation.API.Repositories;

public interface IReservationRepository
{
    Task<List<Reservation.API.Entity.Reservation>> GetAllAsync();
    Task<Reservation.API.Entity.Reservation> GetByIdAsync(Guid id);
    Task<Reservation.API.Entity.Reservation> CreateAsync(Reservation.API.Entity.Reservation reservation);
    Task<Reservation.API.Entity.Reservation> UpdateAsync(Reservation.API.Entity.Reservation reservation);
    Task DeleteAsync(Guid id);
    Task CancellAsync(Guid id);
}
