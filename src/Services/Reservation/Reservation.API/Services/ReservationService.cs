using MongoDB.Driver;
using Reservation.API.Mapper;
using Reservation.API.Models;
using Reservation.API.Mongo;
using Reservation.API.RequestModels;
using Reservation.API.ResponseModels;
using SharedLibrary.Dtos;

namespace Reservation.API.Services;

public class ReservationService : IReservationService
{
    ReservationMapper _mapper = new();
    private readonly IMongoCollection<Models.Reservation> _reservationCollection;

    public ReservationService(IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _reservationCollection = database.GetCollection<Models.Reservation>(databaseSettings.CollectionName);
    }


    public async Task<ApiResponse<ReservationResponse>> CancellAsync(string id)
    {

        var reservation = await _reservationCollection.Find(x => x.Id == id).SingleOrDefaultAsync();
        reservation.Status = ReservationStatus.Cancelled;
        reservation.UpdatedAt = DateTime.UtcNow;

        var updateResult = await _reservationCollection.ReplaceOneAsync(x => x.Id == id, reservation);
        if (updateResult.ModifiedCount == 0)
            return ApiResponse<ReservationResponse>.Fail("Place could not be updated", 500);

        var response=_mapper.ReservationToReservationResponse(reservation);
        response.StatusId = (int)reservation.Status;

        return ApiResponse<ReservationResponse>.Success(response);
    }

    public async Task<ApiResponse<CreatedReservationResponse>> CreateAsync(CreateReservationRequest createReservationRequest)
    {
        var reservation = _mapper.CreateReservationRequestToReservation(createReservationRequest);
        reservation.Status = ReservationStatus.Pending;
        reservation.CreatedAt = DateTime.UtcNow;
        await _reservationCollection.InsertOneAsync(reservation);

        var response=_mapper.ReservationToCreatedReservationResponse(reservation);
        response.StatusId = (int)reservation.Status;

        return ApiResponse<CreatedReservationResponse>.Success(response, 201);
    }

    public async Task<ApiResponse<NoContent>> DeleteAsync(string id)
    {
        await _reservationCollection.DeleteOneAsync(x => x.Id == id);
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<List<ReservationResponse>>> GetAllAsync()
    {

        var reservations = await _reservationCollection.Find(reservation => true).ToListAsync();
        
        var response = _mapper.ReservationsToReservationListResponse(reservations);
        foreach (var item in response)
            item.StatusId = (int)reservations.FirstOrDefault(x => x.Id == item.Id).Status;
        //StatusId

        return ApiResponse<List<ReservationResponse>>.Success(response);
    }

    public async Task<ApiResponse<ReservationResponse>> GetByIdAsync(string id)
    {
        var reservation = await _reservationCollection.Find(x => x.Id == id).SingleOrDefaultAsync();
        if (reservation is null)
            return ApiResponse<ReservationResponse>.Fail("Reservation NotFound", 400);

        var response = _mapper.ReservationToReservationResponse(reservation);
        response.StatusId = (int)reservation.Status;

        return ApiResponse<ReservationResponse>.Success(response, 200);
    }

    public async Task<ApiResponse<UpdatedReservationResponse>> UpdateAsync(string id, UpdateReservationRequest updateReservationRequest)
    {
        var reservation = await _reservationCollection.Find(x => x.Id == id).SingleOrDefaultAsync();

        reservation.DateAndTime = updateReservationRequest.DateAndTime;
        reservation.Notes = updateReservationRequest.Notes;
        reservation.NumberOfPerson = updateReservationRequest.NumberOfPerson;
        reservation.PhoneNumber = updateReservationRequest.PhoneNumber;
        reservation.PlaceId = updateReservationRequest.PlaceId;
        reservation.UpdatedAt = DateTime.UtcNow;
        reservation.Status = (ReservationStatus)updateReservationRequest.StatusId;

        var updateResult = await _reservationCollection.ReplaceOneAsync(x => x.Id == id, reservation);
        if (updateResult.ModifiedCount == 0)
            return ApiResponse<UpdatedReservationResponse>.Fail("Cannot update reservation.", 500);

        var response = _mapper.ReservationToUpdatedReservationResponse(reservation);
        response.StatusId = (int)reservation.Status;

        return ApiResponse<UpdatedReservationResponse>.Success(response);

    }
}
