using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Reservations;
using SharedLibrary.Dtos;
using System.Text;
using System.Text.Json;

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
        var request = new HttpRequestMessage(HttpMethod.Put, $"reservation/CancellReservation/{id}");
        var response = await _httpClient.SendAsync(request);
        //var response= await _httpClient.PutAsJsonAsync<ApiResponse<ReservationViewModel>>($"reservation/CancellReservation/{id}");
        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<ApiResponse<ReservationViewModel>>();
        return true;
    }

    public async Task<bool> CreateAsync(CreateReservationViewModel createReservationViewModel)
    {

        var request= new HttpRequestMessage(HttpMethod.Post, "reservation");
        request.Content = new StringContent(JsonSerializer.Serialize(createReservationViewModel), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);

        //var response = await _httpClient.PostAsAsync("reservation", createReservationViewModel);
        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<ApiResponse<ReservationViewModel>>();

        if (result.StatusCode != StatusCodes.Status201Created)
            return true;
        return false;
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

    public async Task<bool> UpdateAsync(UpdateReservationViewModel updateReservationViewModel)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"reservation/{updateReservationViewModel.Id}");
        request.Content = new StringContent(JsonSerializer.Serialize(updateReservationViewModel), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);

        //var requestResponse = await _httpClient.PutAsJsonAsync<ApiResponse<ReservationViewModel>>($"reservation/{id}", updateReservationViewModel);
        if (!response.IsSuccessStatusCode)
            return false;

        var content= await response.Content.ReadFromJsonAsync<ApiResponse<UpdateReservationViewModel>>();
        if (content.StatusCode != StatusCodes.Status200OK)
            return false;

        return true;

    }
}
