﻿namespace eniyisinerede.API.ResponseModels.Country;

public class UpdatedCountryResponse : BaseResponseModel
{
    public string Name { get; set; }
    public string? Code { get; set; }
}