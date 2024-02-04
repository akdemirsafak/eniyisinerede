using eniyisinerede.API.Models;
using eniyisinerede.API.Repository;
using eniyisinerede.API.RequestModels;
using eniyisinerede.API.ResponseModels;

namespace eniyisinerede.API.Service;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<CreatedCountryResponse> CreateAsync(CreateCountryRequest request)
    {
        var country=new Country
        {
            Name = request.Name,
            Code = request.Code,
            CreatedAt = DateTime.UtcNow
        };
        var createdCountry = await _countryRepository.CreateAsync(country);
        return new CreatedCountryResponse
        {
            Id = createdCountry.Id,
            Name = createdCountry.Name,
            Code = createdCountry.Code,
            CreatedAt = createdCountry.CreatedAt,
            UpdatedAt = createdCountry.UpdatedAt
        };
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
        var countryResponses = new List<CountryResponse>();
        countries.ForEach(country =>
        {
            countryResponses.Add(new CountryResponse
            {
                Id = country.Id,
                Name = country.Name,
                Code = country.Code,
                CreatedAt = country.CreatedAt,
                UpdatedAt = country.UpdatedAt
            });
        });
        return countryResponses;
    }

    public async Task<CountryResponse> GetByIdAsync(int id)
    {
        var country = await _countryRepository.GetByIdAsync(id);
        return new CountryResponse
        {
            Id = country.Id,
            Name = country.Name,
            Code = country.Code,
            CreatedAt = country.CreatedAt,
            UpdatedAt = country.UpdatedAt
        };
    }

    public async Task<UpdatedCountryResponse> UpdateAsync(int id, UpdateCountryRequest request)
    {
        var updatedCountry = await _countryRepository.UpdateAsync(new Country
        {
            Id = id,
            Name = request.Name,
            Code = request.Code,
            UpdatedAt= DateTime.UtcNow
        });
        return new UpdatedCountryResponse
        {
            Id = updatedCountry.Id,
            Name = updatedCountry.Name,
            Code = updatedCountry.Code,
            CreatedAt = updatedCountry.CreatedAt,
            UpdatedAt = updatedCountry.UpdatedAt
        };
    }
}