using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VoddalmBlazor;
using static VoddalmBlazor.Pages.AddHouse;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
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

            await builder.Build().RunAsync();
        }
    }
}

