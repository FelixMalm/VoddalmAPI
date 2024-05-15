using VoddalmBlazor.Models;
using VoddalmBlazor.Services.Base;

namespace BlazorWasmAuthentication.Services
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginDTO Model);
        public Task Logout();

        //event Action<string?>? LoginChange;
        //ValueTask<string> GetJwtAsync();
        //Task<DateTime> LoginAsync(LoginModel model);
        //Task LogoutAsync();
        //Task<bool> RefreshAsync();
        //Task RegisterAsync(RegisterModel model);
    }
}