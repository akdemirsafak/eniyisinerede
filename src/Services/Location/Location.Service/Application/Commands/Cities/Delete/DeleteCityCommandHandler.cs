using Location.Core.Repositories;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Cities.Delete;

public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, ApiResponse<NoContent>>
{
    private readonly ICityRepository _cityRepository;

    public DeleteCityCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ApiResponse<NoContent>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var result=await _cityRepository.DeleteAsync(request.id);
        if (result == 0)
            throw new Exception("City not found");
        return ApiResponse<NoContent>.Success(204);
    }
}
