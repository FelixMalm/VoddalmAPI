using BlazorWasmAuthentication.Handlers;
using BlazorWasmAuthentication.Services;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using VoddalmBlazor.Services.Base;

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
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }

    //public class Program
    //{
    //    public static async Task Main(string[] args)
    //    {
    //        var builder = WebAssemblyHostBuilder.CreateDefault(args);
    //        builder.RootComponents.Add<App>("#app");
    //        builder.RootComponents.Add<HeadOutlet>("head::after");

    //        builder.Services.AddScoped<AuthenticationHandler>();

    //        // Replace ServerAuthenticationStateProvider with RemoteAuthenticationStateProvider
    //        builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationHandler>();
    //        builder.Services.AddAuthorizationCore();

    //        builder.Services.AddHttpClient("ServerApi", client =>
    //        {
    //            client.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? "https://localhost:7046/");
    //        }).AddHttpMessageHandler<AuthenticationHandler>();

    //        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

    //        builder.Services.AddBlazoredSessionStorage();
    //        builder.Services.AddBlazoredLocalStorage();

    //        await builder.Build().RunAsync();
    //    }
    //}
}
