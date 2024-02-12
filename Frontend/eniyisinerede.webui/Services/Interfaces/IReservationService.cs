using eniyisinerede.webui.ViewModels.Reservations;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IReservationService
{
    Task<List<ReservationViewModel>> GetAllAsync();
    Task<ReservationViewModel> GetByIdAsync(string id);
    Task<bool> CreateAsync(CreateReservationViewModel createReservationViewModel);
    Task<bool> UpdateAsync(string id, UpdateReservationViewModel updateReservationViewModel);
    Task<bool> CancellReservationAsync(string id);
}
