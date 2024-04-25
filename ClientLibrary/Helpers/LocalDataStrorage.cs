using Blazored.LocalStorage;

namespace ClientLibrary.Helpers
{
    public class LocalDataStrorage(ILocalStorageService localStorage)
    {
        // Namnet på nyckeln för att lagra autentiserings-token lokalt.
        private const string StorageKey = "authentication-token";

        // för att hämta autentiserings-token från lokal lagring.
        public async Task<string> GetToken()
        {
            // Hämta autentiserings-token som en sträng från lokal lagring.
            return await localStorage.GetItemAsStringAsync(StorageKey);
        }

        // för att ställa in autentiserings-token i lokal lagring.
        public async Task SetToken(string token)
        {
            // Spara autentiserings-token som en sträng i lokal lagring.
            await localStorage.SetItemAsStringAsync(StorageKey, token);
        }

        // för att ta bort autentiserings-token från lokal lagring.
        public async Task RemoveToken()
        {
            // Ta bort autentiserings-token från lokal lagring.
            await localStorage.RemoveItemAsync(StorageKey);
        }
    }
}