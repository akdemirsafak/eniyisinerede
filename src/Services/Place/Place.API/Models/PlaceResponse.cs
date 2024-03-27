namespace Place.API.Models;

public class PlaceResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }
    public string PhotoUrl { get; set; }
}
