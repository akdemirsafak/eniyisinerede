using Location.Core.Repositories;
using Location.Model.ResponseModels.District;
using Location.Service.Mappers.Districts;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Districts.Update;

public class UpdateDistrictCommandHandler : IRequestHandler<UpdateDistrictCommand, ApiResponse<UpdatedDistrictResponse>>
{
    private readonly IDistrictRepository _districtRepository;
    DistrictMapper _districtMapper = new DistrictMapper();
    public UpdateDistrictCommandHandler(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<ApiResponse<UpdatedDistrictResponse>> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
    {
        var district= _districtMapper.UpdateDistrictRequestToDistrict(request.Model);
        district.Id = request.id;
        district.UpdatedAt = DateTime.UtcNow;
        var updateResult= await _districtRepository.UpdateAsync(district);
        return ApiResponse<UpdatedDistrictResponse>.Success(_districtMapper.DistrictToUpdatedDistrictResponse(updateResult));
    }
}
