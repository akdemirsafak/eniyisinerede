using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Users;

namespace eniyisinerede.webui.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserViewModel> GetUserAsync()
    {
        return await _httpClient.GetFromJsonAsync<UserViewModel>("/api/user/getuser"); //casesensitive değildir. BURASI IDENTITYSERVER4 CONTROLLER'DA BELIRLEDIGIMIZ ENDPOINT
        //Burada req. token eklemedik.Bunun yerine handle edeceğiz ve otomatik eklemesini sağlayacağız.
    }
}
