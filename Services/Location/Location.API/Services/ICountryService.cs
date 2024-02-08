using Location.API.RequestModels.Country;
using Location.API.ResponseModels.Country;
using SharedLibrary.Dtos;

namespace Location.API.Services;


public interface ICountryService
{
    Task<ApiResponse<List<CountryResponse>>> GetAllAsync();
    Task<ApiResponse<CountryResponse>> GetByIdAsync(int id);
    Task<ApiResponse<CreatedCountryResponse>> CreateAsync(CreateCountryRequest request);
    Task<ApiResponse<UpdatedCountryResponse>> UpdateAsync(int id, UpdateCountryRequest request);
    Task<ApiResponse<NoContent>> DeleteAsync(int id);

}