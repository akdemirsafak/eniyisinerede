using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Cities.Delete;

public record DeleteCityCommand(int id) : IRequest<ApiResponse<NoContent>>;
