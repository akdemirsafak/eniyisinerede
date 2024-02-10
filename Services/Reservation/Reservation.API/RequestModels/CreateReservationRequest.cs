namespace Reservation.API.RequestModels;

public record CreateReservationRequest(
    Guid PlaceId,
    DateTime DateAndTime,
    string? Notes,
    string PhoneNumber,
    int NumberOfPerson
  );