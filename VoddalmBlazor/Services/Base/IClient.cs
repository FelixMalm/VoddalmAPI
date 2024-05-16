//Author Felix Malm

namespace VoddalmBlazor.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}