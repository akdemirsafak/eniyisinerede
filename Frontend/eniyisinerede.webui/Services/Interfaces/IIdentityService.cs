using eniyisinerede.webui.ViewModels.Auth;
using IdentityModel.Client;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IIdentityService
{
    Task<TokenResponse> GetAccessTokenByRefreshToken();
    Task RevokeRefreshToken(); //kullanıcı çıkışında token'ın silinmesi.
    Task<ApiResponse<bool>> SignInAsync(SignInInputModel loginInputModel);
}
