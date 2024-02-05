using Location.API.RequestModels.Country;
using Location.API.ResponseModels.Country;

namespace Location.API.Services;


public interface ICountryService
{
    Task<List<CountryResponse>> GetAllAsync();
    Task<CountryResponse> GetByIdAsync(int id);
    Task<CreatedCountryResponse> CreateAsync(CreateCountryRequest request);
    Task<UpdatedCountryResponse> UpdateAsync(int id, UpdateCountryRequest request);
    Task DeleteAsync(int id);

}