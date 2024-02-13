using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Places;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services;

public class PlaceService : IPlaceService
{
    private readonly HttpClient _httpClient;

    public PlaceService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PlaceViewModel>> GetAllAsync()
    {
        var httpResponse = await _httpClient.GetAsync("place");
        if (!httpResponse.IsSuccessStatusCode)
            return null;

        var placeViewModel = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<List<PlaceViewModel>>>();
        return placeViewModel.Data;
    }
    public async Task<PlaceViewModel> GetByIdAsync(string id)
    {
        var httpResponse = await _httpClient.GetAsync($"place/{id}");
        if (!httpResponse.IsSuccessStatusCode)
            return null;

        var placeViewModel = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<PlaceViewModel>>();
        return placeViewModel.Data;
    }
}
