using eniyisinerede.API.Models;

namespace eniyisinerede.API.Repository;

public interface IPalaceRepository
{
    Task<Palace> CreateAsync(Palace palace);
    Task<Palace> UpdateAsync(Palace palace);
    Task<Palace> GetByIdAsync(int id);
    Task<List<Palace>> GetAllAsync();
    Task<int> DeleteAsync(int id);
}
