using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Reservations;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services;

public class ReservationService : IReservationService
{
    private readonly HttpClient _httpClient;

    public ReservationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> CancellReservationAsync(string id)
    {

        var requestResponse = await _httpClient.PutAsync($"reservation/CancellReservation/{id}",null);

        if (!requestResponse.IsSuccessStatusCode)
            return false;
        var responseContent= await requestResponse.Content.ReadFromJsonAsync<ApiResponse<ReservationViewModel>>();
        if (responseContent.Errors is not null)
            return false;
        return true;

    }

    public async Task<ReservationViewModel> CreateAsync(CreateReservationViewModel createReservationViewModel)
    {

        var clientResult=await _httpClient.PostAsJsonAsync("reservation", createReservationViewModel);
        if (!clientResult.IsSuccessStatusCode)
            return null;

        var responseContent = await clientResult.Content.ReadFromJsonAsync<ApiResponse<ReservationViewModel>>();

        return responseContent.Data;

    }

    public async Task<List<ReservationViewModel>> GetAllAsync()
    {
        var requestResponse= await _httpClient.GetAsync("reservation");
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var result = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<List<ReservationViewModel>>>();
        return result.Data;
    }

    public async Task<ReservationViewModel> GetByIdAsync(string id)
    {
        var requestResponse = await _httpClient.GetAsync($"reservation/{id}");
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var result = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<ReservationViewModel>>();
        return result.Data;
    }

    public async Task<ReservationViewModel> UpdateAsync(UpdateReservationViewModel updateReservationViewModel)
    {
        var requestResponse= await _httpClient.PutAsJsonAsync($"reservation/{updateReservationViewModel.Id}", updateReservationViewModel);

        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<ReservationViewModel>>();

        if (responseContent.Errors is not null)
            return null;

        return responseContent.Data;
    }
}
