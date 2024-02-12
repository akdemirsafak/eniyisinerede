using eniyisinerede.API.RequestModels.District;
using eniyisinerede.API.ResponseModels.District;

namespace eniyisinerede.API.Service;

public interface IDistrictService
{
    Task<List<DistrictResponse>> GetAllAsync();
    Task<DistrictResponse> GetByIdAsync(int id);
    Task<CreatedDistrictResponse> CreateAsync(CreateDistrictRequest createDistrictRequest);
    Task<UpdatedDistrictResponse> UpdateAsync(int id, UpdateDistrictRequest updateDistrictRequest);
    Task DeleteAsync(int id);
}
