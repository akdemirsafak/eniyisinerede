namespace Location.API.ResponseModels.Country;

public class CreatedCountryResponse : BaseResponseModel
{
    public string Name { get; set; }
    public string? Code { get; set; }
}