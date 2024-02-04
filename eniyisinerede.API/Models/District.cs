namespace eniyisinerede.API.Models;

public class District : BaseModel
{
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public int CityId { get; set; }
}
