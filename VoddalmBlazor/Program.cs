using BlazorWasmAuthentication.Handlers;
using BlazorWasmAuthentication.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using VoddalmBlazor.Services.Base;

//Author Felix Malm

namespace VoddalmBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7046/") });

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<AuthenticationHandler>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<AuthenticationHandler>());
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<IClient, Client>();
            //builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}