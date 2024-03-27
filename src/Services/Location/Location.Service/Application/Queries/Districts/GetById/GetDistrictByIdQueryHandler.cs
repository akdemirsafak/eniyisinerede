using Location.Core.Repositories;
using Location.Model.ResponseModels.District;
using Location.Service.Mappers.Districts;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Districts.GetById;

public class GetDistrictByIdQueryHandler : IRequestHandler<GetDistrictByIdQuery, ApiResponse<DistrictResponse>>
{
    private readonly IDistrictRepository _districtRepository;
    DistrictMapper _districtMapper = new DistrictMapper();
    public GetDistrictByIdQueryHandler(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    async Task<ApiResponse<DistrictResponse>> IRequestHandler<GetDistrictByIdQuery, ApiResponse<DistrictResponse>>.Handle(GetDistrictByIdQuery request, CancellationToken cancellationToken)
    {
        var district= await _districtRepository.GetByIdAsync(request.id);
        if (district == null)
            throw new Exception("District not found");
        return ApiResponse<DistrictResponse>.Success(_districtMapper.DistrictToDistrictResponse(district));
    }
}
