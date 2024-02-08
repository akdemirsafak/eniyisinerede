using System.ComponentModel.DataAnnotations;

namespace Location.API.Models;
public class Country : BaseModel
{
    [Required, Length(1, 32)]
    public string Name { get; set; }
    public string? Code { get; set; }
}
