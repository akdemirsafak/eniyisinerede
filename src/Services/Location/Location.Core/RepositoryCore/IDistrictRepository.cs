using Location.Core.Entities;

namespace Location.Core.Repositories;

public interface IDistrictRepository
{
    Task<List<District>> GetAllAsync();
    Task<District> GetByIdAsync(int id);
    Task<District> CreateAsync(District district);
    Task<District> UpdateAsync(District district);
    Task<int> DeleteAsync(int id);
}
