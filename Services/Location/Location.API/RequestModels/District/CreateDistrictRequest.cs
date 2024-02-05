namespace Location.API.RequestModels.District;
public record CreateDistrictRequest(string Name,
        string? ZipCode,
        int CityId);

