using Location.Model.ResponseModels.Country;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Countries.Get;

public record GetCountriesQuery() : IRequest<ApiResponse<List<CountryResponse>>>;