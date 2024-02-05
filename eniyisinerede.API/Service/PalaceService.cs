using eniyisinerede.API.Mappers.Palaces;
using eniyisinerede.API.Repository;
using eniyisinerede.API.RequestModels.Palace;
using eniyisinerede.API.ResponseModels.Palace;

namespace eniyisinerede.API.Service;

public class PalaceService : IPalaceService
{
    private readonly IPalaceRepository _palaceRepository;
    PalaceMapper _palaceMapper = new PalaceMapper();

    public PalaceService(IPalaceRepository palaceRepository)
    {
        _palaceRepository = palaceRepository;
    }

    public async Task<CreatedPalaceResponse> CreateAsync(CreatePalaceRequest createPalaceRequest)
    {
        var palace= _palaceMapper.CreatePalaceRequestToPalace(createPalaceRequest);
        var createdPalace = await _palaceRepository.CreateAsync(palace);
        return _palaceMapper.PalaceToCreatedPalaceResponse(createdPalace);
    }

    public async Task DeleteAsync(int id)
    {
        var affectedRowCount =await _palaceRepository.DeleteAsync(id);
        if (affectedRowCount == 0)
        {
            throw new Exception("No record found");
        }
    }

    public async Task<List<PalaceResponse>> GetAllAsync()
    {
        var palaces = await _palaceRepository.GetAllAsync();
        return _palaceMapper.PalacesToPalaceListResponse(palaces);
    }

    public async Task<PalaceResponse> GetByIdAsync(int id)
    {
        var palace = await _palaceRepository.GetByIdAsync(id);
        if (palace == null)
        {
            throw new Exception("Record not found.");
        }
        return _palaceMapper.PalaceToPalaceResponse(palace);
    }

    public async Task<UpdatedPalaceResponse> UpdateAsync(int id, UpdatePalaceRequest updatePalaceRequest)
    {
        var palace= _palaceMapper.UpdatePalaceRequestToPalace(updatePalaceRequest);
        palace.Id = id;
        var updatedPalace = await _palaceRepository.UpdateAsync(palace);
        if (updatedPalace == null)
        {
            throw new Exception("Record not found.");
        }
        return _palaceMapper.PalaceToUpdatedPalaceResponse(updatedPalace);
    }
}
