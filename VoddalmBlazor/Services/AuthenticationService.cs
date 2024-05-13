using Blazored.SessionStorage;
using VoddalmBlazor.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.IO;

namespace BlazorWasmAuthentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly System.Net.Http.IHttpClientFactory _factory;
        private readonly ISessionStorageService _sessionStorageService;

        private const string JWT_KEY = nameof(JWT_KEY);
        private const string REFRESH_KEY = nameof(REFRESH_KEY);

        private string? _jwtCache;

        public event Action<string?>? LoginChange;

        public AuthenticationService(System.Net.Http.IHttpClientFactory factory, ISessionStorageService sessionStorageService)
        {
            _factory = factory;
            _sessionStorageService = sessionStorageService;
        }

        public async ValueTask<string> GetJwtAsync()
        {
            if (string.IsNullOrEmpty(_jwtCache))
                _jwtCache = await _sessionStorageService.GetItemAsync<string>(JWT_KEY);

            return _jwtCache;
        }

        public async Task LogoutAsync()
        {
            var response = await _factory.CreateClient("ServerApi").DeleteAsync("api/Account/revoke");

            await _sessionStorageService.RemoveItemAsync(JWT_KEY);
            await _sessionStorageService.RemoveItemAsync(REFRESH_KEY);

            _jwtCache = null;

            await Console.Out.WriteLineAsync($"Revoke gave response {response.StatusCode}");

            LoginChange?.Invoke(null);
        }

        private static string GetUsername(string token)
        {
            var jwt = new JwtSecurityToken(token);

            return jwt.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        }

        public async Task<DateTime> LoginAsync(LoginModel model)
        {
            var response = await _factory.CreateClient("ServerApi").PostAsync("api/Account/login",
                                                        JsonContent.Create(model));

            if (!response.IsSuccessStatusCode)
                throw new UnauthorizedAccessException("Login failed.");

            var content = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (content == null)
                throw new InvalidDataException();

            await _sessionStorageService.SetItemAsync(JWT_KEY, content.Token);
            await _sessionStorageService.SetItemAsync(REFRESH_KEY, content.RefreshToken);

            LoginChange?.Invoke(GetUsername(content.Token));

            return content.Expiration;
        }

        public async Task<bool> RefreshAsync()
        {
            var model = new RefreshModel
            {
                AccessToken = await _sessionStorageService.GetItemAsync<string>(JWT_KEY),
                RefreshToken = await _sessionStorageService.GetItemAsync<string>(REFRESH_KEY)
            };

            var response = await _factory.CreateClient("ServerApi").PostAsync("api/Account/refresh",
                                                        JsonContent.Create(model));

            if (!response.IsSuccessStatusCode)
            {
                await LogoutAsync();

                return false;
            }

            var content = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (content == null)
                throw new InvalidDataException();

            await _sessionStorageService.SetItemAsync(JWT_KEY, content.Token);
            await _sessionStorageService.SetItemAsync(REFRESH_KEY, content.RefreshToken);

            _jwtCache = content.Token;

            return true;
        }
        // Inside AuthenticationService.cs

        public async Task RegisterAsync(RegisterModel model)
        {
            var response = await _factory.CreateClient("ServerApi").PostAsync("api/Account/register",
                                                            JsonContent.Create(model));

            if (!response.IsSuccessStatusCode)
                throw new Exception("Registration failed.");

            // Optionally, you can handle any additional logic here after successful registration
        }
    }
}
