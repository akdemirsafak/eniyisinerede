using Location.API.RequestModels.District;
using Location.API.ResponseModels.District;

namespace Location.API.Services;


public interface IDistrictService
{
    Task<List<DistrictResponse>> GetAllAsync();
    Task<DistrictResponse> GetByIdAsync(int id);
    Task<CreatedDistrictResponse> CreateAsync(CreateDistrictRequest createDistrictRequest);
    Task<UpdatedDistrictResponse> UpdateAsync(int id, UpdateDistrictRequest updateDistrictRequest);
    Task DeleteAsync(int id);
}
