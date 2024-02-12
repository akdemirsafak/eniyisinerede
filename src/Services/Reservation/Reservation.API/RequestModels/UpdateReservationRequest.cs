using System.ComponentModel.DataAnnotations;

namespace Reservation.API.RequestModels;

public record UpdateReservationRequest(
    string PlaceId,
    DateTime DateAndTime,
    string? Notes,
    string PhoneNumber,
    int NumberOfPerson,
    [AllowedValues(1, 2, 3)] int StatusId
    );