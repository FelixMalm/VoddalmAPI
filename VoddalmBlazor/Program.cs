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

namespace VoddalmBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<AuthenticationHandler>();

            // Replace ServerAuthenticationStateProvider with RemoteAuthenticationStateProvider
            //builder.Services.AddScoped<AuthenticationStateProvider, RemoteAuthenticationStateProvider>();

            builder.Services.AddHttpClient("ServerApi", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? "https://localhost:7046/");
            }).AddHttpMessageHandler<AuthenticationHandler>();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddBlazoredSessionStorage();

            await builder.Build().RunAsync();
        }
    }
}
