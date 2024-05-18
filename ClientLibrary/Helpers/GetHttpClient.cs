using BaseLibrary.DTOs;

namespace ClientLibrary.Helpers
{
    public class GetHttpClient(IHttpClientFactory httpClientFactory, LocalDataStrorage localStrorage)
    {
        public const string HeadKey = "Authorization";

        public async Task<HttpClient> GetPrivateHttpClient()
        {
            var client = httpClientFactory.CreateClient("ServerApiClient");
            var stringToken = await localStrorage.GetToken();

            if (string.IsNullOrEmpty(stringToken)) return client;

            var deserializeToken = Serializations.DeserializeJson<UserSession>(stringToken);

            if (deserializeToken == null)
            {
                return client;
            }

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", deserializeToken.Token);
            return client;
        }

        public async Task<HttpClient> GetPublicHttpClient()
        {
            var client = httpClientFactory.CreateClient("ServerApiClient");
            client.DefaultRequestHeaders.Remove(HeadKey);
            return client;
        }
    }
}