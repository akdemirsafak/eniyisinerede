namespace eniyisinerede.webui.ViewModels.Reservations;

public class ReservationViewModel
{
    public string Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public string? Notes { get; set; }
    public string PhoneNumber { get; set; }
    public string Status { get; set; }
    public int StatusId { get; set; }
    public string PlaceId { get; set; }
    public int NumberOfPerson { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedById { get; set; }
}