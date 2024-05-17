﻿using Blazored.LocalStorage;
using VoddalmBlazor.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWasmAuthentication.Handlers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using VoddalmBlazor.Services.Extensions;

namespace BlazorWasmAuthentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginDTO loginModel)
        {
            var response = await httpClient.LoginAsync(loginModel);
            await localStorage.SetItemAsync("accessToken", response.Token);
            await ((AuthenticationHandler)authenticationStateProvider).LoggedIn();
            return true;
        }




        public async Task Logout()
        {
            await ((AuthenticationHandler)authenticationStateProvider).LoggedOut();
        }
    }
}
