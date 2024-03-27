using Microsoft.AspNetCore.Http;

namespace SharedLibrary.Services
{
    public class IdentitySharedService : IIdentitySharedService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentitySharedService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
