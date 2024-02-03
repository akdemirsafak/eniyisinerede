namespace eniyisinerede.API.Models;

public class District:BaseModel
{
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public City City { get; set; }
    public IList<Palace> Palaces { get; set; }
}
