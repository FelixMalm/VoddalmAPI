using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace VoddalmBlazor.Services.Base
{
    public class BaseHttpService
    {
        private readonly ILocalStorageService localStorage;
        private readonly IClient client;

        public BaseHttpService(ILocalStorageService localStorage, IClient client)
        {
            this.localStorage = localStorage;
            this.client = client;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid> { Message = "Validation Errors", ValidationErros = apiException.Response, Success = false };
            }
            if (apiException.StatusCode == 404)
            {
                return new Response<Guid> { Message = "Nothing Found", Success = false };
            }
            return new Response<Guid> { Message = "Try again...", Success = false };
        }

        protected async Task GetBearerToken()
        {
            var token = await localStorage.GetItemAsync<string>("accesstoken");
            if (token != null)
            {
                client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
