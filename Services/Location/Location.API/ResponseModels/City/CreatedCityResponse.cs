namespace Location.API.ResponseModels.City;

public class CreatedCityResponse : BaseResponseModel
{
    public string Name { get; set; }
    public int CountryId { get; set; }
}
