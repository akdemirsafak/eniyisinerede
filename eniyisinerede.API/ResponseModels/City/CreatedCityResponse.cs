namespace eniyisinerede.API.ResponseModels.City;

public class CreatedCityResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
