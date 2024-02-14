using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Cities;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services;

public class CityService : ICityService
{
    private readonly HttpClient _httpClient;

    public CityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CityViewModel> CreateAsync(CreateCityViewModel createCityViewModel)
    {
        var requestResponse = await _httpClient.PostAsJsonAsync("city", createCityViewModel);
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<CityViewModel>>();

        return responseContent.Data;
    }

    public async Task<List<CityViewModel>> GetAllAsync()
    {
        var requestResponse=await _httpClient.GetAsync("city");
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<List<CityViewModel>>>();
        return responseContent.Data;

    }

    public async Task<CityViewModel> GetByIdAsync(int id)
    {
        var requestResponse=await _httpClient.GetAsync($"city/{id}");
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<CityViewModel>>();
        return responseContent.Data;

    }

    public async Task<CityViewModel> UpdateAsync(UpdateCityViewModel updateCityViewModel)
    {
        var requestResponse = await _httpClient.PutAsJsonAsync($"city/{updateCityViewModel.Id}", updateCityViewModel);

        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<CityViewModel>>();
        return responseContent.Data;
    }
}
