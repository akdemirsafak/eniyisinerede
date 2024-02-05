using Location.API.Models;

namespace Location.API.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetAllAsync();
    Task<Country> GetByIdAsync(int id);
    Task<Country> CreateAsync(Country country);
    Task<Country> UpdateAsync(Country country);
    Task<int> DeleteAsync(int id);
}