using Location.Core.Repositories;
using Location.Model.ResponseModels.District;
using Location.Service.Mappers.Districts;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Districts.Get;

public class GetDistrictsQueryHandler : IRequestHandler<GetDistrictsQuery, ApiResponse<List<DistrictResponse>>>
{
    private readonly IDistrictRepository _districtRepository;
    DistrictMapper mapper = new DistrictMapper();
    public GetDistrictsQueryHandler(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }
    public async Task<ApiResponse<List<DistrictResponse>>> Handle(GetDistrictsQuery request, CancellationToken cancellationToken)
    {
        var districts = await _districtRepository.GetAllAsync();
        return ApiResponse<List<DistrictResponse>>.Success(mapper.DistrictsToDistrictListResponse(districts));
    }
}
