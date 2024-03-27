using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Countries;
using SharedLibrary.Dtos;

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

        var clientResult=await _httpClient.PostAsJsonAsync("country", createCountryViewModel);
        if (!clientResult.IsSuccessStatusCode)
            return null;

        var responseContent = await clientResult.Content.ReadFromJsonAsync<ApiResponse<CountryViewModel>>();

        return responseContent.Data;
    }

    public async Task<bool> DeleteAsync(int countryId)
    {
        var requestResponse= await _httpClient.DeleteAsync($"country/{countryId}");

        if (!requestResponse.IsSuccessStatusCode)
            return false;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<NoContent>>();

        if (responseContent.Errors is not null)
            return false;

        return true;
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
        var request= await _httpClient.PutAsJsonAsync($"country/{updateCountryViewModel.Id}", updateCountryViewModel);
        if (!request.IsSuccessStatusCode)
            return null;
        var requestContent = await request.Content.ReadFromJsonAsync<ApiResponse<CountryViewModel>>();

        if (requestContent.Errors is not null)
            return null;

        return requestContent.Data;
    }
}
