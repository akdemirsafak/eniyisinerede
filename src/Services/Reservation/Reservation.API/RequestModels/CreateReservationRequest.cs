using System.ComponentModel.DataAnnotations;

namespace Reservation.API.RequestModels;

public record CreateReservationRequest(
    string PlaceId,
    DateTime DateAndTime,
    string? Notes,
    string PhoneNumber,
    int NumberOfPerson
  );