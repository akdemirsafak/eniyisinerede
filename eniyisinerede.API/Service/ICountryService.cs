using eniyisinerede.API.RequestModels;
using eniyisinerede.API.ResponseModels;

namespace eniyisinerede.API.Service;

public interface ICountryService
{
    Task<List<CountryResponse>> GetAllAsync();
    Task<CountryResponse> GetByIdAsync(int id);
    Task<CreatedCountryResponse> CreateAsync(CreateCountryRequest request);
    Task<UpdatedCountryResponse> UpdateAsync(int id, UpdateCountryRequest request);
    Task DeleteAsync(int id);

}