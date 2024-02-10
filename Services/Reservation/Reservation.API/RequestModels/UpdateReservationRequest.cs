namespace Reservation.API.RequestModels;

public record UpdateReservationRequest(
    Guid PlaceId,
    DateTime DateAndTime,
    string? Notes,
    string PhoneNumber,
    int NumberOfPerson
    );