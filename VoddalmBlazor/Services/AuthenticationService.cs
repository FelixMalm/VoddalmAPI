//using Blazored.LocalStorage;
//using VoddalmBlazor.Services.Base;
//using Microsoft.AspNetCore.Components.Authorization;
//using BlazorWasmAuthentication.Handlers;
//using Newtonsoft.Json;
//using System.Net.Http;
//using System.Text;
//using VoddalmBlazor.Services.Extensions;

//namespace BlazorWasmAuthentication.Services
//{
//    public class AuthenticationService : IAuthenticationService
//    {
//        private readonly IClient httpClient;
//        private readonly ILocalStorageService localStorage;
//        private readonly AuthenticationStateProvider authenticationStateProvider;

//        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authentciationStateProvider)
//        {
//            this.httpClient = httpClient;
//            this.localStorage = localStorage;
//            this.authenticationStateProvider = authentciationStateProvider;
//        }

//        public async Task<bool> AuthenticateAsync(LoginDTO Model)
//        {
//            //var response = await httpClient.CustomLoginAsync(Model);
//            var response = await httpClient.LoginAsync(Model);

//            await localStorage.SetItemAsync("accesToken", response.Token);

//            await ((AuthenticationHandler)authenticationStateProvider).LoggedIn();

//            return true;
//        }

//        public async Task Logout()
//        {
//            await ((AuthenticationHandler)authenticationStateProvider).LoggedOut();
//        }
//    }
//}