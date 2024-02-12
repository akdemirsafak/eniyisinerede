using eniyisinerede.webui.ViewModels.Places;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IPlaceService
{
    Task<List<PlaceViewModel>> GetAllAsync();
    Task<PlaceViewModel> GetByIdAsync(string id);
}
