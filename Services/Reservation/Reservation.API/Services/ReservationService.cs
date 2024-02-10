using AutoMapper;
using Reservation.API.Repositories;
using Reservation.API.RequestModels;
using Reservation.API.ResponseModels;
using SharedLibrary.Dtos;

namespace Reservation.API.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<NoContent>> CancellAsync(Guid id)
    {
        await _reservationRepository.CancellAsync(id);
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<CreatedReservationResponse>> CreateAsync(CreateReservationRequest createReservationRequest)
    {
        var reservation= _mapper.Map<Entity.Reservation>(createReservationRequest);

        await _reservationRepository.CreateAsync(reservation);

        return ApiResponse<CreatedReservationResponse>.Success(_mapper.Map<CreatedReservationResponse>(reservation), 201);
    }

    public async Task<ApiResponse<NoContent>> DeleteAsync(Guid id)
    {
        await _reservationRepository.DeleteAsync(id);
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<List<ReservationResponse>>> GetAllAsync()
    {
        var reservations = await _reservationRepository.GetAllAsync();

        return ApiResponse<List<ReservationResponse>>.Success(_mapper.Map<List<ReservationResponse>>(reservations));
    }

    public async Task<ApiResponse<ReservationResponse>> GetByIdAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id);

        return ApiResponse<ReservationResponse>.Success(_mapper.Map<ReservationResponse>(reservation));
    }

    public async Task<ApiResponse<UpdatedReservationResponse>> UpdateAsync(Guid id, UpdateReservationRequest updateReservationRequest)
    {
        var reservation= _mapper.Map<Entity.Reservation>(updateReservationRequest);
        reservation.Id=id;

        await _reservationRepository.UpdateAsync(reservation);

        return ApiResponse<UpdatedReservationResponse>.Success(_mapper.Map<UpdatedReservationResponse>(reservation));
    }
}
