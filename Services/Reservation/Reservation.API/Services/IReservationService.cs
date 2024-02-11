using Reservation.API.RequestModels;
using Reservation.API.ResponseModels;
using SharedLibrary.Dtos;

namespace Reservation.API.Services;

public interface IReservationService
{
    Task<ApiResponse<List<ReservationResponse>>> GetAllAsync();
    Task<ApiResponse<ReservationResponse>> GetByIdAsync(string id);
    Task<ApiResponse<CreatedReservationResponse>> CreateAsync(CreateReservationRequest createReservationRequest);
    Task<ApiResponse<UpdatedReservationResponse>> UpdateAsync(string id, UpdateReservationRequest updateReservationRequest);
    Task<ApiResponse<ReservationResponse>> CancellAsync(string id);
    Task<ApiResponse<NoContent>> DeleteAsync(string id);
}
