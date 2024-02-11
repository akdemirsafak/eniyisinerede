using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Reservation.API.Models;

public class Reservation
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public string? Notes { get; set; }
    public string PhoneNumber { get; set; }
    public ReservationStatus Status { get; set; }
    public string PlaceId { get; set; }
    public int NumberOfPerson { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedById { get; set; }
}
public enum ReservationStatus
{
    Pending=1,
    Confirmed,
    Cancelled
}
