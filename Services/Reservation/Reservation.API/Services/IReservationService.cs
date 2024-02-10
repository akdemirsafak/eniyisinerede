using Reservation.API.RequestModels;
using Reservation.API.ResponseModels;
using SharedLibrary.Dtos;

namespace Reservation.API.Services;

public interface IReservationService
{
    Task<ApiResponse<List<ReservationResponse>>> GetAllAsync();
    Task<ApiResponse<ReservationResponse>> GetByIdAsync(Guid id);
    Task<ApiResponse<CreatedReservationResponse>> CreateAsync(CreateReservationRequest createReservationRequest);
    Task<ApiResponse<UpdatedReservationResponse>> UpdateAsync(Guid id, UpdateReservationRequest updateReservationRequest);
    Task<ApiResponse<NoContent>> CancellAsync(Guid id);
    Task<ApiResponse<NoContent>> DeleteAsync(Guid id);
}
