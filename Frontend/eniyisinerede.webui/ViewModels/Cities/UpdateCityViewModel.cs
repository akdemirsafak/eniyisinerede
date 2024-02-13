using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Cities;

public class UpdateCityViewModel
{
    [Required]
    public int Id { get; set; }
    [Required, Length(1, 32)]
    public string Name { get; set; }
    [Required]
    public int CountryId { get; set; }

}
