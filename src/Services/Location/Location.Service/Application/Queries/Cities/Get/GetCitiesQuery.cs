using Location.Model.ResponseModels.City;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Cities.Get;

public record GetCitiesQuery() : IRequest<ApiResponse<List<CityResponse>>>;