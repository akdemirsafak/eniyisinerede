using Location.Core.Repositories;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Districts.Delete;

public class DeleteDistrictCommandHandler : IRequestHandler<DeleteDistrictCommand, ApiResponse<NoContent>>
{
    private readonly IDistrictRepository _districtRepository;

    public DeleteDistrictCommandHandler(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<ApiResponse<NoContent>> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
    {

        var deleteResult= await _districtRepository.DeleteAsync(request.id);
        if (deleteResult == 0)
            throw new Exception("District not found");

        return ApiResponse<NoContent>.Success(204);
    }
}
