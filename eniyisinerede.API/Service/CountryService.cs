using eniyisinerede.API.Mappers.Countries;
using eniyisinerede.API.Repository;
using eniyisinerede.API.RequestModels;
using eniyisinerede.API.ResponseModels;

namespace eniyisinerede.API.Service;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;
    CountryMapper mapper = new CountryMapper();
    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<CreatedCountryResponse> CreateAsync(CreateCountryRequest request)
    {
        var country= mapper.CreateCountryRequestToCountry(request);

        var createdCountry = await _countryRepository.CreateAsync(country);

        return mapper.CountryToCreatedCountryResponse(createdCountry);
    }

    public async Task DeleteAsync(int id)
    {
        var result = await _countryRepository.DeleteAsync(id);
        if (result == 0)
        {
            throw new Exception("Country not found");
        }
    }

    public async Task<List<CountryResponse>> GetAllAsync()
    {
        var countries = await _countryRepository.GetAllAsync();

        return mapper.CountriesToCountryListResponse(countries);

    }

    public async Task<CountryResponse> GetByIdAsync(int id)
    {
        var country = await _countryRepository.GetByIdAsync(id);
        if (country is null)
            throw new Exception("Country not found");

        return mapper.CountryToCountryResponse(country);
    }

    public async Task<UpdatedCountryResponse> UpdateAsync(int id, UpdateCountryRequest request)
    {
        var country= mapper.UpdateCountryRequestToCountry(request);
        country.Id = id;
        var updatedCountry = await _countryRepository.UpdateAsync(country);
        return mapper.CountryToUpdatedCountryResponse(updatedCountry);
    }
}