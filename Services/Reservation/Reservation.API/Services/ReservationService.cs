using Reservation.API.Entity;
using Reservation.API.Mapper;
using Reservation.API.Repositories;
using Reservation.API.RequestModels;
using Reservation.API.ResponseModels;
using SharedLibrary.Dtos;

namespace Reservation.API.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    ReservationMapper _mapper=new();

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<ApiResponse<NoContent>> CancellAsync(Guid id)
    {
        var reservation= await _reservationRepository.GetByIdAsync(id);
        reservation.Status = ReservationStatus.Cancelled;
        await _reservationRepository.UpdateAsync(reservation);
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<CreatedReservationResponse>> CreateAsync(CreateReservationRequest createReservationRequest)
    {
        var reservation= _mapper.CreateReservationRequestToReservation(createReservationRequest);
        reservation.Status = ReservationStatus.Pending;
        await _reservationRepository.CreateAsync(reservation);

        var response=_mapper.ReservationToCreatedReservationResponse(reservation);
        response.StatusId = (int)reservation.Status;

        return ApiResponse<CreatedReservationResponse>.Success(response, 201);
    }

    public async Task<ApiResponse<NoContent>> DeleteAsync(Guid id)
    {
        await _reservationRepository.DeleteAsync(id);
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<List<ReservationResponse>>> GetAllAsync()
    {
        var reservations = await _reservationRepository.GetAllAsync();

        var response=_mapper.ReservationsToReservationListResponse(reservations);
        foreach (var item in response)
        {
            item.StatusId = (int)reservations.FirstOrDefault(x => x.Id == item.Id).Status;
        }

        return ApiResponse<List<ReservationResponse>>.Success(response);
    }

    public async Task<ApiResponse<ReservationResponse>> GetByIdAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id);
        var response=_mapper.ReservationToReservationResponse(reservation);
        response.StatusId = (int)reservation.Status;

        return ApiResponse<ReservationResponse>.Success(response);
    }

    public async Task<ApiResponse<UpdatedReservationResponse>> UpdateAsync(Guid id, UpdateReservationRequest updateReservationRequest)
    {
        var reservation= await _reservationRepository.GetByIdAsync(id);

        reservation.DateAndTime = updateReservationRequest.DateAndTime;
        reservation.Notes = updateReservationRequest.Notes;
        reservation.NumberOfPerson = updateReservationRequest.NumberOfPerson;
        reservation.PhoneNumber = updateReservationRequest.PhoneNumber;
        reservation.PlaceId = updateReservationRequest.PlaceId;



        await _reservationRepository.UpdateAsync(reservation);

        var response=_mapper.ReservationToUpdatedReservationResponse(reservation);
        response.StatusId = (int)reservation.Status;

        return ApiResponse<UpdatedReservationResponse>.Success(response);
    }
}
