namespace eniyisinerede.webui.ViewModels.Reservations;

public class UpdateReservationViewModel
{
    public string Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public string? Notes { get; set; }
    public string PhoneNumber { get; set; }
    public int StatusId { get; set; }
    public string PlaceId { get; set; }
    public int NumberOfPerson { get; set; }
}
