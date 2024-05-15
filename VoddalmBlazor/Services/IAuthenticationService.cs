using VoddalmBlazor.Models;

namespace BlazorWasmAuthentication.Services
{
    public interface IAuthenticationService
    {
        event Action<string?>? LoginChange;

        ValueTask<string> GetJwtAsync();
        Task<DateTime> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<bool> RefreshAsync();
        Task RegisterAsync(RegisterModel model);
        Task<string?> GetCurrentUserEmailAsync();
        Task<string> GetAccessToken();
    }
}