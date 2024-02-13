using eniyisinerede.webui.ViewModels.Countries;

namespace eniyisinerede.webui.Services.Interfaces;

public interface ICountryService
{
    Task<CountryViewModel> GetByIdAsync(int countryId);
    Task<List<CountryViewModel>> GetAllAsync();
    Task<CountryViewModel> CreateAsync(CreateCountryViewModel createCountryViewModel);
    Task<CountryViewModel> UpdateAsync(UpdateCountryViewModel updateCountryViewModel);
    Task<bool> DeleteAsync(int countryId);

}
