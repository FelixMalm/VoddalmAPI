//Author Felix Malm

using System.Net.Http;

namespace VoddalmBlazor.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}