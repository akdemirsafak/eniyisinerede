using eniyisinerede.webui.ViewModels.Districts;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IDistrictService
{
    //Task<List<DistrictViewModel>> GetDistrictsByCityIdAsync(int cityId);
    Task<List<DistrictViewModel>> GetAllAsync();
    Task<DistrictViewModel> GetByIdAsync(int id);
    Task<DistrictViewModel> CreateAsync(CreateDistrictViewModel district);
    Task<DistrictViewModel> UpdateAsync(UpdateDistrictViewModel district);
}
