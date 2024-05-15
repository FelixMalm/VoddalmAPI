using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VoddalmBlazor.Services.Base;

namespace VoddalmBlazor.Services.Extensions
{
    public static class ClientExtensions
    {
        public static async Task<LoginResponse> CustomLoginAsync(this IClient client, LoginDTO model)
        {
            var url = "https://localhost:7046/api/Account/login";
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.HttpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseData);

            return loginResponse;
        }
    }
}

