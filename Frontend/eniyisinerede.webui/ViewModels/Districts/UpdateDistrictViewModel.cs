using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Districts;

public class UpdateDistrictViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name required")]
    [Length(1, 32, ErrorMessage = "Name must be 1-32 character between")]
    [Display(Name = "Ad")]
    public string Name { get; set; }
    [Display(Name = "Zip kodu")]
    [MaxLength(10, ErrorMessage = "Zip code must be 10 character")]
    public string? ZipCode { get; set; }
    public int CityId { get; set; }
}
