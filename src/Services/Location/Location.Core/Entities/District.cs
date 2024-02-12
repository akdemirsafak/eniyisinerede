using System.ComponentModel.DataAnnotations;

namespace Location.Core.Entities;
public class District : BaseModel
{
    [Required, Length(1, 32)]
    public string Name { get; set; }
    [MaxLength(32)]
    public string? ZipCode { get; set; }
    [Required]
    public int CityId { get; set; }
}
