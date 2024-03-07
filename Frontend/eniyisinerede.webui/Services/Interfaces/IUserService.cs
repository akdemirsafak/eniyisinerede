using eniyisinerede.webui.ViewModels.Users;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IUserService
{
    Task<UserViewModel> GetUserAsync();
}
