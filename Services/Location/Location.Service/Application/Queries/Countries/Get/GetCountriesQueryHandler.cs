using Location.Core.Repositories;
using Location.Model.ResponseModels.Country;
using Location.Service.Mappers.Countries;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Countries.Get;

public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, ApiResponse<List<CountryResponse>>>
{
    private readonly ICountryRepository _countryRepository;
    CountryMapper _countryMapper = new();
    public GetCountriesQueryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ApiResponse<List<CountryResponse>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await _countryRepository.GetAllAsync();

        return ApiResponse<List<CountryResponse>>.Success(_countryMapper.CountriesToCountryListResponse(countries));
    }
}
