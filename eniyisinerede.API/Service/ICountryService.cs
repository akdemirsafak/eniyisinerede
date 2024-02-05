using eniyisinerede.API.RequestModels.Country;
using eniyisinerede.API.ResponseModels.Country;

namespace eniyisinerede.API.Service;

public interface ICountryService
{
    Task<List<CountryResponse>> GetAllAsync();
    Task<CountryResponse> GetByIdAsync(int id);
    Task<CreatedCountryResponse> CreateAsync(CreateCountryRequest request);
    Task<UpdatedCountryResponse> UpdateAsync(int id, UpdateCountryRequest request);
    Task DeleteAsync(int id);

}