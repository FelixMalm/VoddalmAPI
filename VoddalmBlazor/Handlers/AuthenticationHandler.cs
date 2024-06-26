﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

//Author Felix Malm o Kim Jonssson

namespace BlazorWasmAuthentication.Handlers
{
    public class AuthenticationHandler : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtHandler;

        public AuthenticationHandler(ILocalStorageService localStorage, JwtSecurityTokenHandler jwtHandler)
        {
            this.localStorage = localStorage;
            this.jwtHandler = jwtHandler;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var savedToken = await localStorage.GetItemAsync<string>("accessToken");

            if (savedToken == null)
            {
                return new AuthenticationState(user);
            }

            try
            {
                var tokenContent = jwtHandler.ReadJwtToken(savedToken);

                if (tokenContent.ValidTo < DateTime.Now)
                {
                    return new AuthenticationState(user);
                }

                var claims = await GetClaims();
                user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

                return new AuthenticationState(user);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error reading JWT token: {ex.Message}");
                return new AuthenticationState(user);
            }
        }

        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LoggedOut()
        {
            await localStorage.RemoveItemAsync("accessToken");
            await localStorage.RemoveItemAsync("userId");
            await localStorage.RemoveItemAsync("email");
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
    }
}
