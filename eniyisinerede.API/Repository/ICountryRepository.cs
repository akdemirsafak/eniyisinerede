using eniyisinerede.API.Models;

namespace eniyisinerede.API.Repository;

public interface ICountryRepository
{
    Task<List<Country>> GetAllAsync();
    Task<Country> GetByIdAsync(int id);
    Task<Country> CreateAsync(Country country);
    Task<Country> UpdateAsync(Country country);
    Task<int> DeleteAsync(int id);
}