using eniyisinerede.API.RequestModels.City;
using eniyisinerede.API.ResponseModels.City;

namespace eniyisinerede.API.Service;

public interface ICityService
{
    Task<List<CityResponse>> GetAllAsync();
    Task<CityResponse> GetByIdAsync(int id);
    Task<CreatedCityResponse> CreateAsync(CreateCityRequest request);
    Task<UpdatedCityResponse> UpdateAsync(int id, UpdateCityRequest request);
    Task DeleteAsync(int id);
}
