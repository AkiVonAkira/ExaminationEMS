using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System.Net.Http.Json;

namespace ClientLibrary.Services.Implementations
{
    public class GenericServiceImplementations<T>(GetHttpClient getHttpClient) : IGenericServiceInterface<T>
    {
        // delete (id)
        public async Task<GeneralResponse> DeleteById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.DeleteAsync($"{baseUrl}/delete/{id}");
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        // read all
        public async Task<List<T>> GetAll(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<T>>($"{baseUrl}/all");
            return results!;
        }

        // read single (by id)
        public async Task<T> GetById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<T>($"{baseUrl}/singleget/{id}");
            return result!;
        }

        // create
        public async Task<GeneralResponse> Insert(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}/add", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        // update (model)
        public async Task<GeneralResponse> Update(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PutAsJsonAsync($"{baseUrl}/update", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
    }
}