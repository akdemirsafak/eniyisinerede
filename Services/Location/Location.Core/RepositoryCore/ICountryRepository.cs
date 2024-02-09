using Location.Core.Entities;

namespace Location.Core.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetAllAsync();
    Task<Country> GetByIdAsync(int id);
    Task<Country> CreateAsync(Country country);
    Task<Country> UpdateAsync(Country country);
    Task<int> DeleteAsync(int id);
}