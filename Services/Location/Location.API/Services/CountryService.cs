using Location.API.Mappers.Countries;
using Location.API.Repositories;
using Location.API.RequestModels.Country;
using Location.API.ResponseModels.Country;
using SharedLibrary.Dtos;

namespace Location.API.Services;


public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;
    CountryMapper mapper = new CountryMapper();
    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ApiResponse<CreatedCountryResponse>> CreateAsync(CreateCountryRequest request)
    {
        var country= mapper.CreateCountryRequestToCountry(request);

        var createdCountry = await _countryRepository.CreateAsync(country);

        return ApiResponse<CreatedCountryResponse>.Success(mapper.CountryToCreatedCountryResponse(createdCountry), 201);
    }

    public async Task<ApiResponse<NoContent>> DeleteAsync(int id)
    {
        var result = await _countryRepository.DeleteAsync(id);
        if (result == 0)
            throw new Exception("Country not found");

        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<List<CountryResponse>>> GetAllAsync()
    {
        var countries = await _countryRepository.GetAllAsync();

        return ApiResponse<List<CountryResponse>>.Success(mapper.CountriesToCountryListResponse(countries));
    }

    public async Task<ApiResponse<CountryResponse>> GetByIdAsync(int id)
    {
        var country = await _countryRepository.GetByIdAsync(id);
        if (country is null)
            throw new Exception("Country not found");

        return ApiResponse<CountryResponse>.Success(mapper.CountryToCountryResponse(country));
    }

    public async Task<ApiResponse<UpdatedCountryResponse>> UpdateAsync(int id, UpdateCountryRequest request)
    {
        var country= mapper.UpdateCountryRequestToCountry(request);
        country.Id = id;
        var updatedCountry = await _countryRepository.UpdateAsync(country);

        return ApiResponse<UpdatedCountryResponse>.Success(mapper.CountryToUpdatedCountryResponse(updatedCountry));
    }
}