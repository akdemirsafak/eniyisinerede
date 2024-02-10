using Location.Model.ResponseModels.City;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Cities.GetById;

public record GetCityByIdQuery(int id) : IRequest<ApiResponse<CityResponse>>;