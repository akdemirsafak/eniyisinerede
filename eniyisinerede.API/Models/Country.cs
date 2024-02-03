using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.API.Models;

public class Country : BaseModel
{
    [Required]
    [Length(1,32)]
    public string Name { get; set; }
    public string? Code { get; set; }
    public IList<City> City { get; set; }
}
