using Newtonsoft.Json;

//Author Felix Malm

namespace VoddalmBlazor.Services.Extensions
{
    public class LoginResponse
    {
        [Newtonsoft.Json.JsonProperty("token", Required = Newtonsoft.Json.Required.Always)]
        public string Token { get; set; }
    }
}