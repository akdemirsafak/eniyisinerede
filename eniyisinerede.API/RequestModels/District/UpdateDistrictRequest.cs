namespace eniyisinerede.API.RequestModels.District;

public record UpdateDistrictRequest(string Name, 
    string? ZipCode,
    int CityId);
