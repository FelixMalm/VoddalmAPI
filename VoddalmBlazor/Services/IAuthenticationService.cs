using VoddalmBlazor.Models;
using VoddalmBlazor.Services.Base;


namespace BlazorWasmAuthentication.Services
{
    //Author Felix Malm
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginDTO Model);
        

        public Task Logout();
    }
}