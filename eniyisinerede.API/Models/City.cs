using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.API.Models;

public class City:BaseModel
{
    [Required]
    [Length(1, 32)]
    public string Name { get; set; }
    public District County { get; set; }
}
