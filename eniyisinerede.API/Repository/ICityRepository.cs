using eniyisinerede.API.Models;

namespace eniyisinerede.API.Repository;

public interface ICityRepository
{
    Task<List<City>> GetAllAsync();
    Task<City> GetByIdAsync(int id);
    Task<City> CreateAsync(City city);
    Task<City> UpdateAsync(City city);
    Task<int> DeleteAsync(int id);
}
