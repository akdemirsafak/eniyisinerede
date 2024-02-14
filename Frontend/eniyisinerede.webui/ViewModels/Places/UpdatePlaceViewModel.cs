using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Places;

public class UpdatePlaceViewModel
{
    [Required]
    public string Id { get; set; }
    [Required, Length(1, 32)]
    public string Name { get; set; }
    public string? Description { get; set; }
    [Required, Length(1, 128)]
    public string Address { get; set; }
    public string? PhotoUrl { get; set; }
}
