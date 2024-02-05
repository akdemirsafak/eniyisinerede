using Location.API.Mappers.Cities;
using Location.API.Repositories;
using Location.API.RequestModels.City;
using Location.API.ResponseModels.City;

namespace Location.API.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    CityMapper mapper = new CityMapper();
    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<CreatedCityResponse> CreateAsync(CreateCityRequest request)
    {
        var city= mapper.CreateCityRequestToCity(request);
        var createdCity=await _cityRepository.CreateAsync(city);
        return mapper.CityToCreatedCityResponse(createdCity);
    }

    public async Task DeleteAsync(int id)
    {
        var result=await _cityRepository.DeleteAsync(id);
        if (result == 0)
            throw new Exception("City not found");
    }

    public async Task<List<CityResponse>> GetAllAsync()
    {
        var cities = await _cityRepository.GetAllAsync();

        return mapper.CitiesToCityListResponse(cities);
    }

    public async Task<CityResponse> GetByIdAsync(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city == null)
            throw new Exception("City not found");
        return mapper.CityToCityResponse(city);
    }

    public async Task<UpdatedCityResponse> UpdateAsync(int id, UpdateCityRequest request)
    {
        var city = mapper.UpdateCityRequestToCity(request);
        city.Id = id;
        var result = await _cityRepository.UpdateAsync(city);
        return mapper.CityToUpdatedCityResponse(result);
    }
}
