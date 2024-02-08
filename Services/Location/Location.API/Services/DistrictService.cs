using Location.API.Mappers.Districts;
using Location.API.Models;
using Location.API.Repositories;
using Location.API.RequestModels.District;
using Location.API.ResponseModels.District;
using SharedLibrary.Dtos;

namespace Location.API.Services;


public class DistrictService : IDistrictService
{
    private readonly IDistrictRepository _districtRepository;
    DistrictMapper _districtMapper = new DistrictMapper();

    public DistrictService(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<ApiResponse<CreatedDistrictResponse>> CreateAsync(CreateDistrictRequest createDistrictRequest)
    {
        District district = _districtMapper.CreateDistrictRequestToDistrict(createDistrictRequest);
        var createResult=await _districtRepository.CreateAsync(district);
        return ApiResponse<CreatedDistrictResponse>.Success(_districtMapper.DistrictToCreatedDistrictResponse(createResult), 201);
    }

    public async Task<ApiResponse<NoContent>> DeleteAsync(int id)
    {
        var deleteResult= await _districtRepository.DeleteAsync(id);
        if (deleteResult == 0)
        {
            throw new Exception("District not found");
        }
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<List<DistrictResponse>>> GetAllAsync()
    {
        var districts = await _districtRepository.GetAllAsync();
        return ApiResponse<List<DistrictResponse>>.Success(_districtMapper.DistrictsToDistrictListResponse(districts));
    }

    public async Task<ApiResponse<DistrictResponse>> GetByIdAsync(int id)
    {
        var district= await _districtRepository.GetByIdAsync(id);
        if (district == null)
        {
            throw new Exception("District not found");
        }
        return ApiResponse<DistrictResponse>.Success(_districtMapper.DistrictToDistrictResponse(district));
    }

    public async Task<ApiResponse<UpdatedDistrictResponse>> UpdateAsync(int id, UpdateDistrictRequest updateDistrictRequest)
    {
        var district= _districtMapper.UpdateDistrictRequestToDistrict(updateDistrictRequest);
        district.Id = id;
        district.UpdatedAt = DateTime.UtcNow;
        var updateResult= await _districtRepository.UpdateAsync(district);
        return ApiResponse<UpdatedDistrictResponse>.Success(_districtMapper.DistrictToUpdatedDistrictResponse(updateResult));
    }

}
