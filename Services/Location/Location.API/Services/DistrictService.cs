using Location.API.Mappers.Districts;
using Location.API.Models;
using Location.API.Repositories;
using Location.API.RequestModels.District;
using Location.API.ResponseModels.District;

namespace Location.API.Services;


public class DistrictService : IDistrictService
{
    private readonly IDistrictRepository _districtRepository;
    DistrictMapper _districtMapper = new DistrictMapper();

    public DistrictService(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<CreatedDistrictResponse> CreateAsync(CreateDistrictRequest createDistrictRequest)
    {
        District district = _districtMapper.CreateDistrictRequestToDistrict(createDistrictRequest);
        var createResult=await _districtRepository.CreateAsync(district);
        return _districtMapper.DistrictToCreatedDistrictResponse(createResult);
    }

    public async Task DeleteAsync(int id)
    {
        var deleteResult= await _districtRepository.DeleteAsync(id);
        if (deleteResult == 0)
        {
            throw new Exception("District not found");
        }
    }

    public async Task<List<DistrictResponse>> GetAllAsync()
    {
        var districts = await _districtRepository.GetAllAsync();
        return _districtMapper.DistrictsToDistrictListResponse(districts);
    }

    public async Task<DistrictResponse> GetByIdAsync(int id)
    {
        var district= await _districtRepository.GetByIdAsync(id);
        if (district == null)
        {
            throw new Exception("District not found");
        }
        return _districtMapper.DistrictToDistrictResponse(district);
    }

    public async Task<UpdatedDistrictResponse> UpdateAsync(int id, UpdateDistrictRequest updateDistrictRequest)
    {
        var district= _districtMapper.UpdateDistrictRequestToDistrict(updateDistrictRequest);
        district.Id = id;
        district.UpdatedAt = DateTime.UtcNow;
        var updateResult= await _districtRepository.UpdateAsync(district);
        return _districtMapper.DistrictToUpdatedDistrictResponse(updateResult);
    }
}
