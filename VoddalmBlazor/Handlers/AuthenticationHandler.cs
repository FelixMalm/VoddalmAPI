using BlazorWasmAuthentication.Services;
// using Microsoft.AspNetCore.Components.Authorization; // Commented out the dependency
using System.Net;
using System.Net.Http.Headers;

namespace BlazorWasmAuthentication.Handlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        // private readonly AuthenticationStateProvider _authenticationStateProvider; // Commented out the dependency

        public AuthenticationHandler(IAuthenticationService authenticationService, IConfiguration configuration/*, AuthenticationStateProvider authenticationStateProvider*/) // Commented out the dependency
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
            // _authenticationStateProvider = authenticationStateProvider; // Commented out the dependency
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwt = await _authenticationService.GetJwtAsync();
            var isToServer = request.RequestUri?.AbsoluteUri.StartsWith(_configuration["ServerUrl"] ?? "") ?? false;

            if (isToServer && !string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var response = await base.SendAsync(request, cancellationToken);

            // if (response.StatusCode == HttpStatusCode.Unauthorized) // Commented out the code relying on AuthenticationStateProvider
            //{
            //    var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            //    var user = authState.User;

            //    // Check if the user has the required role to access the resource
            //    if (!user.IsInRole("Admin"))
            //    {
            //        // Redirect the user to a different page or display an access denied message
            //        // You can also customize the response here as needed
            //        response.StatusCode = HttpStatusCode.Forbidden;
            //        response.ReasonPhrase = "Access Denied";
            //        return response;
            //    }
            //}
            return response;
        }
    }
}