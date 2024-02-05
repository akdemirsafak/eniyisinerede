using eniyisinerede.API.Models;

namespace eniyisinerede.API.Repository;

public interface IDistrictRepository
{
    Task<List<District>> GetAllAsync();
    Task<District> GetByIdAsync(int id);
    Task<District> CreateAsync(District district);
    Task<District> UpdateAsync(District district);
    Task<int> DeleteAsync(int id);
}
