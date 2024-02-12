using Location.Model.RequestModels.City;
using Location.Model.ResponseModels.City;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Cities.Create;

public record CreateCityCommand(CreateCityRequest Model) : IRequest<ApiResponse<CreatedCityResponse>>;