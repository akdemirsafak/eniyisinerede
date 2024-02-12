using Location.Core.Repositories;
using Location.Model.ResponseModels.Country;
using Location.Service.Mappers.Countries;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Countries.Create;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, ApiResponse<CreatedCountryResponse>>
{
    private readonly ICountryRepository _countryRepository;
    CountryMapper _countryMapper = new();
    public CreateCountryCommandHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ApiResponse<CreatedCountryResponse>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country= _countryMapper.CreateCountryRequestToCountry(request.Model);

        var createdCountry = await _countryRepository.CreateAsync(country);
        var response=_countryMapper.CountryToCreatedCountryResponse(createdCountry);

        return ApiResponse<CreatedCountryResponse>.Success(response, 201);
    }
}
