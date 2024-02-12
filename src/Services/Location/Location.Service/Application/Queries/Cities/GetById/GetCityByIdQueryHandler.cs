using Location.Core.Repositories;
using Location.Model.ResponseModels.City;
using Location.Service.Mappers.Cities;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Cities.GetById;

public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, ApiResponse<CityResponse>>
{
    private readonly ICityRepository _cityRepository;
    CityMapper mapper = new CityMapper();

    public GetCityByIdQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ApiResponse<CityResponse>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.id);
        if (city == null)
            throw new Exception("City not found");
        return ApiResponse<CityResponse>.Success(mapper.CityToCityResponse(city));
    }
}
