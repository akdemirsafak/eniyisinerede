namespace Location.API.Models;

public class City : BaseModel
{
    public string Name { get; set; }
    public int CountryId { get; set; }
}
