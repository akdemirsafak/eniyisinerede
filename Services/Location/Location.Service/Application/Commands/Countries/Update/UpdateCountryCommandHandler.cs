using Location.Core.Repositories;
using Location.Model.ResponseModels.Country;
using Location.Service.Mappers.Countries;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Countries.Update;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, ApiResponse<UpdatedCountryResponse>>
{
    private readonly ICountryRepository _countryRepository;
    CountryMapper _countryMapper = new();
    public UpdateCountryCommandHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ApiResponse<UpdatedCountryResponse>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country= _countryMapper.UpdateCountryRequestToCountry(request.Model);
        country.Id = request.id;
        var updatedCountry = await _countryRepository.UpdateAsync(country);

        return ApiResponse<UpdatedCountryResponse>.Success(_countryMapper.CountryToUpdatedCountryResponse(updatedCountry));
    }
}
