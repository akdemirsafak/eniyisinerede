﻿namespace eniyisinerede.API.ResponseModels.District;

public class DistrictResponse : BaseResponseModel
{
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public int CityId { get; set; }
}
