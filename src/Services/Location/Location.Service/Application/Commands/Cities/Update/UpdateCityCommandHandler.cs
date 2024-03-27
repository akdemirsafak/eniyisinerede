using Location.Core.Repositories;
using Location.Model.ResponseModels.City;
using Location.Service.Mappers.Cities;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Cities.Update;

public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, ApiResponse<UpdatedCityResponse>>
{
    private readonly ICityRepository _cityRepository;
    CityMapper mapper = new CityMapper();
    public UpdateCityCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ApiResponse<UpdatedCityResponse>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = mapper.UpdateCityRequestToCity(request.Model);
        city.Id = request.id;
        var result = await _cityRepository.UpdateAsync(city);

        return ApiResponse<UpdatedCityResponse>.Success(mapper.CityToUpdatedCityResponse(result));
    }
}
