namespace Location.Model.RequestModels.District;

public record UpdateDistrictRequest(string Name,
    string? ZipCode,
    int CityId);
