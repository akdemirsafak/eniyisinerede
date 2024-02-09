using Location.API.Models;
using Location.API.RequestModels.District;
using Location.API.ResponseModels.District;
using Riok.Mapperly.Abstractions;

namespace Location.Service.Mappers.Districts;

[Mapper]
public partial class DistrictMapper
{
    public partial DistrictResponse DistrictToDistrictResponse(District district);
    public partial List<DistrictResponse> DistrictsToDistrictListResponse(List<District> districts);


    public partial District CreateDistrictRequestToDistrict(CreateDistrictRequest createDistrictRequest);
    public partial CreatedDistrictResponse DistrictToCreatedDistrictResponse(District district);


    public partial UpdatedDistrictResponse DistrictToUpdatedDistrictResponse(District district);
    public partial District UpdateDistrictRequestToDistrict(UpdateDistrictRequest updateDistrictRequest);

}
