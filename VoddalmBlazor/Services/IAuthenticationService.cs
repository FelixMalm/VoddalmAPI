using VoddalmBlazor.Models;
using VoddalmBlazor.Services.Base;


namespace BlazorWasmAuthentication.Services
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginDTO Model);

        public Task Logout();
    }
}