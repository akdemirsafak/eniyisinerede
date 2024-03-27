using Location.Core.Repositories;
using Location.Model.ResponseModels.City;
using Location.Service.Mappers.Cities;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Cities.Get
{
    internal class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, ApiResponse<List<CityResponse>>>
    {
        private readonly ICityRepository _cityRepository;
        CityMapper mapper = new CityMapper();

        public GetCitiesQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }


        public async Task<ApiResponse<List<CityResponse>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetAllAsync();

            return ApiResponse<List<CityResponse>>.Success(mapper.CitiesToCityListResponse(cities));
        }
    }
}
