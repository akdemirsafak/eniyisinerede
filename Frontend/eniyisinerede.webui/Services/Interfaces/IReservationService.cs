using eniyisinerede.webui.ViewModels.Reservations;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IReservationService
{
    Task<List<ReservationViewModel>> GetAllAsync();
    Task<ReservationViewModel> GetByIdAsync(string id);
    Task<ReservationViewModel> CreateAsync(CreateReservationViewModel createReservationViewModel);
    Task<ReservationViewModel> UpdateAsync(UpdateReservationViewModel updateReservationViewModel);
    Task<bool> CancellReservationAsync(string id);
}
