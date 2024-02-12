namespace Location.Model.ResponseModels.District;

public class UpdatedDistrictResponse : BaseResponseModel
{
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public int CityId { get; set; }
}
