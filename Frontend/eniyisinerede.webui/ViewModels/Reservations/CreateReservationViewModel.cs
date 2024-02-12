using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Reservations;

public class CreateReservationViewModel
{
    [Required]
    public DateTime DateAndTime { get; set; }
    public string? Notes { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string PlaceId { get; set; }
    [Required]
    public int NumberOfPerson { get; set; }
}
