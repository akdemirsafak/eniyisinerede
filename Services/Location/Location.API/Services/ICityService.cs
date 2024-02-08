using Location.API.RequestModels.City;
using Location.API.ResponseModels.City;
using SharedLibrary.Dtos;

namespace Location.API.Services;


public interface ICityService
{
    Task<ApiResponse<List<CityResponse>>> GetAllAsync();
    Task<ApiResponse<CityResponse>> GetByIdAsync(int id);
    Task<ApiResponse<CreatedCityResponse>> CreateAsync(CreateCityRequest request);
    Task<ApiResponse<UpdatedCityResponse>> UpdateAsync(int id, UpdateCityRequest request);
    Task<ApiResponse<NoContent>> DeleteAsync(int id);
}
