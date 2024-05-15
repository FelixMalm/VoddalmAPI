using Blazored.LocalStorage;
using BlazorWasmAuthentication.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace BlazorWasmAuthentication.Handlers
{
    public class AuthenticationHandler : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtHandler;

        public AuthenticationHandler(ILocalStorageService localStorage, JwtSecurityTokenHandler jwtHandler)
        {
            this.localStorage = localStorage;
            jwtHandler = new JwtSecurityTokenHandler();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var savedToken = await localStorage.GetItemAsync<string>("accessToken");

            if (savedToken == null)
            {
                return new AuthenticationState(user);
            }

            var tokenContent = jwtHandler.ReadJwtToken(savedToken);

            if (tokenContent.ValidTo < DateTime.Now)
            {
                return new AuthenticationState(user);
            }

            var claims = await GetClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            return new AuthenticationState(user);
        }
        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }
        public async Task LoggedOut()
        {
            await localStorage.RemoveItemAsync("accessToken");
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authState);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var savedToken = await localStorage.GetItemAsync<string>("accessToken");
            var tokenContent = jwtHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }

        //private readonly IAuthenticationService _authenticationService;
        //private readonly IConfiguration _configuration;
        //private readonly AuthenticationStateProvider _authenticationStateProvider; // Commented out the dependency

        //public AuthenticationHandler(IAuthenticationService authenticationService, IConfiguration configuration, AuthenticationStateProvider authenticationStateProvider) // Commented out the dependency
        //{
        //    _authenticationService = authenticationService;
        //    _configuration = configuration;
        //    _authenticationStateProvider = authenticationStateProvider; // Commented out the dependency
        //}

        //protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //{
        //    var jwt = await _authenticationService.GetJwtAsync();
        //    var isToServer = request.RequestUri?.AbsoluteUri.StartsWith(_configuration["ServerUrl"] ?? "") ?? false;

        //    if (isToServer && !string.IsNullOrEmpty(jwt))
        //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        //    var response = await base.SendAsync(request, cancellationToken);

        //    if (response.StatusCode == HttpStatusCode.Unauthorized) // Commented out the code relying on AuthenticationStateProvider
        //    {
        //        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        //        var user = authState.User;

        //        // Check if the user has the required role to access the resource
        //        if (!user.IsInRole("Admin"))
        //        {
        //            // Redirect the user to a different page or display an access denied message
        //            // You can also customize the response here as needed
        //            response.StatusCode = HttpStatusCode.Forbidden;
        //            response.ReasonPhrase = "Access Denied";
        //            return response;
        //        }
        //    }
        //    return response;
        //}
    }
}
