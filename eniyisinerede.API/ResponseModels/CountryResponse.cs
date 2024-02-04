namespace eniyisinerede.API.ResponseModels;

public class CountryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Code { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}