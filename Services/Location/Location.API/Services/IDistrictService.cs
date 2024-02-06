using Location.API.RequestModels.District;
using Location.API.ResponseModels.District;
using SharedLibrary.Dtos;

namespace Location.API.Services;


public interface IDistrictService
{
    Task<ApiResponse<List<DistrictResponse>>> GetAllAsync();
    Task<ApiResponse<DistrictResponse>> GetByIdAsync(int id);
    Task<ApiResponse<CreatedDistrictResponse>> CreateAsync(CreateDistrictRequest createDistrictRequest);
    Task<ApiResponse<UpdatedDistrictResponse>> UpdateAsync(int id, UpdateDistrictRequest updateDistrictRequest);
    Task<ApiResponse<NoContent>> DeleteAsync(int id);
}
