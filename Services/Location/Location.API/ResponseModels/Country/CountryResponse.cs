namespace Location.API.ResponseModels.Country;

public class CountryResponse : BaseResponseModel
{
    public string Name { get; set; }
    public string? Code { get; set; }
}