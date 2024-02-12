using Location.Core.Repositories;
using Location.Model.ResponseModels.City;
using Location.Service.Mappers.Cities;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Cities.Create;

public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, ApiResponse<CreatedCityResponse>>
{
    private readonly ICityRepository _cityRepository;
    CityMapper mapper = new CityMapper();

    public CreateCityCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ApiResponse<CreatedCityResponse>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var city= mapper.CreateCityRequestToCity(request.Model);
        var createdCity=await _cityRepository.CreateAsync(city);
        return ApiResponse<CreatedCityResponse>.Success(mapper.CityToCreatedCityResponse(createdCity), 201);
    }
}
