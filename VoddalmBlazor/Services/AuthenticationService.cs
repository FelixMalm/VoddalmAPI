using Blazored.LocalStorage;
using VoddalmBlazor.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWasmAuthentication.Handlers;

namespace BlazorWasmAuthentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authentciationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authentciationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginDTO Model)
        {
            var response = await httpClient.LoginAsync(Model);

            await localStorage.SetItemAsync("accesToken", response.Token);

            await ((AuthenticationHandler)authenticationStateProvider).LoggedIn();

            return true;
        }

        public async Task Logout()
        {
            await((AuthenticationHandler)authenticationStateProvider).LoggedOut();
        }

        //private readonly IHttpClientFactory _factory;
        //private readonly ILocalStorageService _localStorageService;

        //private const string JWT_KEY = nameof(JWT_KEY);
        //private const string REFRESH_KEY = nameof(REFRESH_KEY);

        //private string? _jwtCache;

        //public event Action<string?>? LoginChange;

        //public AuthenticationService(IHttpClientFactory factory, ILocalStorageService localStorageService)
        //{
        //    _factory = factory;
        //    _localStorageService = localStorageService;
        //}

        //public async ValueTask<string> GetJwtAsync()
        //{
        //    if (string.IsNullOrEmpty(_jwtCache))
        //        _jwtCache = await _localStorageService.GetItemAsync<string>(JWT_KEY);

        //    return _jwtCache;
        //}

        //public async Task LogoutAsync()
        //{
        //    var response = await _factory.CreateClient("ServerApi").DeleteAsync("api/Account/revoke");

        //    await _localStorageService.RemoveItemAsync(JWT_KEY);
        //    await _localStorageService.RemoveItemAsync(REFRESH_KEY);

        //    _jwtCache = null;

        //    await Console.Out.WriteLineAsync($"Revoke gave response {response.StatusCode}");

        //    LoginChange?.Invoke(null);
        //}

        //private static string GetUsername(string token)
        //{
        //    var jwt = new JwtSecurityToken(token);

        //    return jwt.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        //}

        //public async Task<DateTime> LoginAsync(LoginModel model)
        //{
        //    var response = await _factory.CreateClient("ServerApi").PostAsync("api/Account/login",
        //                                                    JsonContent.Create(model));

        //    if (!response.IsSuccessStatusCode)
        //        throw new UnauthorizedAccessException("Login failed.");

        //    var content = await response.Content.ReadFromJsonAsync<LoginResponse>();

        //    if (content == null)
        //        throw new InvalidDataException();

        //    await _localStorageService.SetItemAsync(JWT_KEY, content.Token);
        //    await _localStorageService.SetItemAsync(REFRESH_KEY, content.RefreshToken);

        //    LoginChange?.Invoke(GetUsername(content.Token));

        //    return content.Expiration;
        //}

        //public async Task<bool> RefreshAsync()
        //{
        //    var model = new RefreshModel
        //    {
        //        AccessToken = await _localStorageService.GetItemAsync<string>(JWT_KEY),
        //        RefreshToken = await _localStorageService.GetItemAsync<string>(REFRESH_KEY)
        //    };

        //    var response = await _factory.CreateClient("ServerApi").PostAsync("api/Account/refresh",
        //                                                    JsonContent.Create(model));

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        await LogoutAsync();

        //        return false;
        //    }

        //    var content = await response.Content.ReadFromJsonAsync<LoginResponse>();

        //    if (content == null)
        //        throw new InvalidDataException();

        //    await _localStorageService.SetItemAsync(JWT_KEY, content.Token);
        //    await _localStorageService.SetItemAsync(REFRESH_KEY, content.RefreshToken);

        //    _jwtCache = content.Token;

        //    return true;
        //}

        //public async Task RegisterAsync(RegisterModel model)
        //{
        //    var response = await _factory.CreateClient("ServerApi").PostAsync("api/Account/register",
        //                                                    JsonContent.Create(model));

        //    if (!response.IsSuccessStatusCode)
        //        throw new Exception("Registration failed.");

        //    // Optionally, you can handle any additional logic here after successful registration
        //}
    }
}
