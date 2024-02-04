using eniyisinerede.API.Models;
using eniyisinerede.API.Repository;
using eniyisinerede.API.RequestModels.City;
using eniyisinerede.API.ResponseModels.City;

namespace eniyisinerede.API.Service;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<CreatedCityResponse> CreateAsync(CreateCityRequest request)
    {
        var city= new City
        {
            Name = request.Name,
            CountryId = request.CountryId,
            CreatedAt = DateTime.UtcNow
        };
        await _cityRepository.CreateAsync(city);
        return new CreatedCityResponse
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId,
            CreatedAt = city.CreatedAt,
            UpdatedAt = city.UpdatedAt
        };
    }

    public async Task DeleteAsync(int id)
    {
        var result=await _cityRepository.DeleteAsync(id);
        if(result==0)
            throw new Exception("City not found");
    }

    public async Task<List<CityResponse>> GetAllAsync()
    {
        var cities = await _cityRepository.GetAllAsync();
        List<CityResponse> responseModel = new();
        foreach (var city in cities)
        {
            responseModel.Add(new CityResponse
            {
                Id = city.Id,
                Name = city.Name,
                CountryId = city.CountryId,
                CreatedAt = city.CreatedAt,
                UpdatedAt = city.UpdatedAt
            });
        }
        return responseModel;
    }

    public async Task<CityResponse> GetByIdAsync(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city == null)
            throw new Exception("City not found");
        return new CityResponse
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId,
            CreatedAt = city.CreatedAt,
            UpdatedAt = city.UpdatedAt
        };
    }

    public async Task<UpdatedCityResponse> UpdateAsync(int id, UpdateCityRequest request)
    {
        var result = await _cityRepository.UpdateAsync(new City
        {
            Id = id,
            Name = request.Name,
            CountryId = request.CountryId
        });
        return new UpdatedCityResponse
        {
            Id = result.Id,
            Name = result.Name,
            CountryId = result.CountryId,
            CreatedAt = result.CreatedAt,
            UpdatedAt = result.UpdatedAt
        };
    }
}
