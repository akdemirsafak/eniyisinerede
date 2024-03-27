using Location.Model.ResponseModels.Country;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Countries.GetById;

public record GetCountryByIdQuery(int id) : IRequest<ApiResponse<CountryResponse>>;