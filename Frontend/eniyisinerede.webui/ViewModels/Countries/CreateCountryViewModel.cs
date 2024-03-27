using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Countries;

public class CreateCountryViewModel
{
    [Required]
    [Length(1, 32, ErrorMessage = "Ülke adı 1-32 karakter aralığında olmalıdır.")]
    public string Name { get; set; }
    public string? Code { get; set; }
}
