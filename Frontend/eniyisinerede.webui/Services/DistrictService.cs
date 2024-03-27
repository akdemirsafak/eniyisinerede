using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Districts;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services;

public class DistrictService : IDistrictService
{
    private readonly HttpClient _httpClient;

    public DistrictService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DistrictViewModel> CreateAsync(CreateDistrictViewModel district)
    {
        var requestResponse= await _httpClient.PostAsJsonAsync("district", district);

        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<DistrictViewModel>>();

        return responseContent.Data;
    }

    public async Task<List<DistrictViewModel>> GetAllAsync()
    {
        var requestResponse= await _httpClient.GetAsync("district");
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent= await requestResponse.Content.ReadFromJsonAsync<ApiResponse<List<DistrictViewModel>>>();
        return responseContent.Data;

    }

    public async Task<DistrictViewModel> GetByIdAsync(int id)
    {
        var requestResponse= await _httpClient.GetAsync($"district/{id}");
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<DistrictViewModel>>();
        return responseContent.Data;

    }

    //public Task<List<DistrictViewModel>> GetDistrictsByCityIdAsync(int cityId)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<DistrictViewModel> UpdateAsync(UpdateDistrictViewModel district)
    {
        var requestResponse = await _httpClient.PutAsJsonAsync($"district/{district.Id}", district);
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent= await requestResponse.Content.ReadFromJsonAsync<ApiResponse<DistrictViewModel>>();

        if (responseContent.Errors is not null)
            return null;

        return responseContent.Data;
    }
}
