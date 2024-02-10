namespace Reservation.API.Entity;

public class Reservation : IAuditableEntity
{
    public Guid Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public string? Notes { get; set; }
    public string PhoneNumber { get; set; }
    public ReservationStatus Status { get; set; }

    public Guid PlaceId { get; set; }
    public int NumberOfPerson { get; set; }
    public DateTime? CreatedAt { get; set; }
    public Guid? CreatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedById { get; set; }
}
public enum ReservationStatus
{
    Pending=1,
    Confirmed,
    Cancelled
}
