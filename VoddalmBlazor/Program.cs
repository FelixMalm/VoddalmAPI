using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasmAuthentication.Handlers;
using BlazorWasmAuthentication.Services;
using Blazored.SessionStorage;
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

            //builder.Services.AddAuthenticationCore();
            //builder.Services.AddHttpClient("YourAPI", client => client.BaseAddress = new Uri("https://localhost:7046/"));

            builder.Services.AddScoped<AuthenticationHandler>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddHttpClient("ServerApi", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? "https://localhost:7046/");
            }).AddHttpMessageHandler<AuthenticationHandler>();

            builder.Services.AddBlazoredSessionStorage();


            await builder.Build().RunAsync();
        }

    }
}