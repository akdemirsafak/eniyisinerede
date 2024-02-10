using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Districts.Delete;

public record DeleteDistrictCommand(int id) : IRequest<ApiResponse<NoContent>>;

