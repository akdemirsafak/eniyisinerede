using System.ComponentModel.DataAnnotations;

namespace Location.API.Models;

public class City : BaseModel
{
    [Required, Length(1, 32)]
    public string Name { get; set; }
    [Required]
    public int CountryId { get; set; }
}
