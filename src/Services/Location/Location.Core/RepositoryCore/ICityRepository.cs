using Location.Core.Entities;

namespace Location.Core.Repositories;

public interface ICityRepository
{
    Task<List<City>> GetAllAsync();
    Task<City> GetByIdAsync(int id);
    Task<City> CreateAsync(City city);
    Task<City> UpdateAsync(City city);
    Task<int> DeleteAsync(int id);
}
