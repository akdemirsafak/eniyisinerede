using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Cities;
using eniyisinerede.webui.ViewModels.Countries;
using SharedLibrary.Dtos;
using System.Text;
using System.Text.Json;

namespace eniyisinerede.webui.Services;

public class CountryService : ICountryService
{
    private readonly HttpClient _httpClient;


    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;

    }

    public async Task<CountryViewModel> CreateAsync(CreateCountryViewModel createCountryViewModel)
    {
        var request= new HttpRequestMessage(HttpMethod.Post, "api/country");
        var requestContent = new StringContent(JsonSerializer.Serialize(createCountryViewModel), Encoding.UTF8, "application/json");
        var requestResult = await _httpClient.SendAsync(request);
        if (requestResult.IsSuccessStatusCode)
        {
            var responseContent = await requestResult.Content.ReadAsStringAsync();
            var countryViewModel = JsonSerializer.Deserialize<CountryViewModel>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return countryViewModel;
        }
        return null;
    }

    public async Task<bool> DeleteAsync(int countryId)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"country/{countryId}");
        var requestResult = await _httpClient.SendAsync(request);

        if (!requestResult.IsSuccessStatusCode)
            return false;

        var responseContent = await requestResult.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<ApiResponse<NoContent>>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (response.StatusCode == StatusCodes.Status204NoContent)
            return true;

        return false;
    }


    public async Task<List<CountryViewModel>> GetAllAsync()
    {
        var countries = await _httpClient.GetAsync("country");
        if (!countries.IsSuccessStatusCode)
            return null;
        var countryViewModel = await countries.Content.ReadFromJsonAsync<ApiResponse<List<CountryViewModel>>>();
        return countryViewModel.Data;
    }


    public async Task<CountryViewModel> GetByIdAsync(int id)
    {
        var requestResponse=await _httpClient.GetAsync($"country/{id}");
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<CountryViewModel>>();
        return responseContent.Data;
    }

    public async Task<CountryViewModel> UpdateAsync(UpdateCountryViewModel updateCountryViewModel)
    {
        var country = new CountryViewModel
        {
            Code = updateCountryViewModel.Code,
            Name = updateCountryViewModel.Name
        };
        var request= await _httpClient.PutAsJsonAsync($"country/{updateCountryViewModel.Id}", country);
        if (!request.IsSuccessStatusCode)
            return null;
        var requestContent = await request.Content.ReadFromJsonAsync<ApiResponse<CountryViewModel>>();

        if (requestContent.StatusCode != StatusCodes.Status200OK)
            return null;

        return requestContent.Data;
    }
}
