using eniyisinerede.API.RequestModels.Palace;
using eniyisinerede.API.ResponseModels.Palace;

namespace eniyisinerede.API.Service;

public interface IPalaceService
{
    Task<List<PalaceResponse>> GetAllAsync();
    Task<PalaceResponse> GetByIdAsync(int id);
    Task<CreatedPalaceResponse> CreateAsync(CreatePalaceRequest createPalaceRequest);
    Task<UpdatedPalaceResponse> UpdateAsync(int id, UpdatePalaceRequest updatePalaceRequest);
    Task DeleteAsync(int id);
}
