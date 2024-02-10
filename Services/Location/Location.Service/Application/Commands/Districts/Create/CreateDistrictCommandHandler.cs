using Location.Core.Entities;
using Location.Core.Repositories;
using Location.Model.ResponseModels.District;
using Location.Service.Mappers.Districts;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Districts.Create;

public class CreateDistrictCommandHandler : IRequestHandler<CreateDistrictCommand, ApiResponse<CreatedDistrictResponse>>
{
    private readonly IDistrictRepository _districtRepository;
    DistrictMapper _districtMapper = new DistrictMapper();
    public CreateDistrictCommandHandler(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<ApiResponse<CreatedDistrictResponse>> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
    {
        District district = _districtMapper.CreateDistrictRequestToDistrict(request.Model);
        var createResult=await _districtRepository.CreateAsync(district);
        return ApiResponse<CreatedDistrictResponse>.Success(_districtMapper.DistrictToCreatedDistrictResponse(createResult), 201);
    }
}
