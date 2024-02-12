using Location.Model.RequestModels.City;
using Location.Model.ResponseModels.City;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Cities.Update;

public record UpdateCityCommand(int id, UpdateCityRequest Model) : IRequest<ApiResponse<UpdatedCityResponse>>;
