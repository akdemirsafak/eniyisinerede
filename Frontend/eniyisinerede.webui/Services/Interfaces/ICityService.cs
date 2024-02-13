using eniyisinerede.webui.ViewModels.Cities;

namespace eniyisinerede.webui.Services.Interfaces;

public interface ICityService
{
    Task<CityViewModel> GetByIdAsync(int id);
    Task<CityViewModel> CreateAsync(CreateCityViewModel createCityViewModel);
    Task<CityViewModel> UpdateAsync(UpdateCityViewModel updateCityViewModel);
    Task<List<CityViewModel>> GetAllAsync();
}
