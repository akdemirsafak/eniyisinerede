using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Countries.Delete;

public record DeleteCountryCommand(int id) : IRequest<ApiResponse<NoContent>>;