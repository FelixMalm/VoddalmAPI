using Newtonsoft.Json;
namespace VoddalmBlazor.Services.Extensions
{
    public class LoginResponse
    {
        [Newtonsoft.Json.JsonProperty("token", Required = Newtonsoft.Json.Required.Always)]
        public string Token { get; set; }

        // Include other properties if necessary
    }
}
