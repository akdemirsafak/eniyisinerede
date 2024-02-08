using Location.API.Mappers.Cities;
using Location.API.Repositories;
using Location.API.RequestModels.City;
using Location.API.ResponseModels.City;
using SharedLibrary.Dtos;

namespace Location.API.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    CityMapper mapper = new CityMapper();
    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ApiResponse<CreatedCityResponse>> CreateAsync(CreateCityRequest request)
    {
        var city= mapper.CreateCityRequestToCity(request);
        var createdCity=await _cityRepository.CreateAsync(city);
        return ApiResponse<CreatedCityResponse>.Success(mapper.CityToCreatedCityResponse(createdCity), 201);
    }

    public async Task<ApiResponse<NoContent>> DeleteAsync(int id)
    {
        var result=await _cityRepository.DeleteAsync(id);
        if (result == 0)
            throw new Exception("City not found");
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<List<CityResponse>>> GetAllAsync()
    {
        var cities = await _cityRepository.GetAllAsync();

        return ApiResponse<List<CityResponse>>.Success(mapper.CitiesToCityListResponse(cities));
    }

    public async Task<ApiResponse<CityResponse>> GetByIdAsync(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city == null)
            throw new Exception("City not found");
        return ApiResponse<CityResponse>.Success(mapper.CityToCityResponse(city));
    }

    public async Task<ApiResponse<UpdatedCityResponse>> UpdateAsync(int id, UpdateCityRequest request)
    {
        var city = mapper.UpdateCityRequestToCity(request);
        city.Id = id;
        var result = await _cityRepository.UpdateAsync(city);

        return ApiResponse<UpdatedCityResponse>.Success(mapper.CityToUpdatedCityResponse(result));
    }
}
