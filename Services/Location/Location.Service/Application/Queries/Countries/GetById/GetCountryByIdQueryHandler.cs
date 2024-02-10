using Location.Core.Repositories;
using Location.Model.ResponseModels.Country;
using Location.Service.Mappers.Countries;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Countries.GetById;

public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, ApiResponse<CountryResponse>>
{
    private readonly ICountryRepository _countryRepository;
    CountryMapper _countryMapper = new();
    public GetCountryByIdQueryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ApiResponse<CountryResponse>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetByIdAsync(request.id);
        if (country is null)
            throw new Exception("Country not found");

        return ApiResponse<CountryResponse>.Success(_countryMapper.CountryToCountryResponse(country));
    }
}
