using Location.API.RequestModels.City;
using Location.API.ResponseModels.City;

namespace Location.API.Services;


public interface ICityService
{
    Task<List<CityResponse>> GetAllAsync();
    Task<CityResponse> GetByIdAsync(int id);
    Task<CreatedCityResponse> CreateAsync(CreateCityRequest request);
    Task<UpdatedCityResponse> UpdateAsync(int id, UpdateCityRequest request);
    Task DeleteAsync(int id);
}
