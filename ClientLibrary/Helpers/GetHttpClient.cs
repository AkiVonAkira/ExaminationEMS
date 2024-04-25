using BaseLibrary.DTOs;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Helpers
{
    public class GetHttpClient(IHttpClientFactory httpClientFactory, LocalDataStrorage localStrorage)
    {
        public const string HeadKey = "Authorization";

        public async Task<HttpClient> GetPrivateHttpClient()
        {
            var client = httpClientFactory.CreateClient("SystemApiClient");
            var stringToken = await localStrorage.GetToken();
           
            var deserializeToken = Serializations.DeserializesJsonString<UserSession>(stringToken);   

            if(deserializeToken == null)
            {
                return client;
            }

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", deserializeToken.Token);    
        }
    }
}
