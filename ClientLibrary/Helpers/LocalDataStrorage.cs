using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Helpers
{
    public class LocalDataStrorage
    {
        // Namnet på nyckeln för att lagra autentiserings-token lokalt.
        private const string StorageKey = "authentication-token";

        // för att hämta autentiserings-token från lokal lagring.
        public static async Task<string> GetToken(ILocalStorageService localStorage)
        {
            // Hämta autentiserings-token som en sträng från lokal lagring.
            return await localStorage.GetItemAsStringAsync(StorageKey);
        }

        // för att ställa in autentiserings-token i lokal lagring.
        public static async Task SetToken(ILocalStorageService localStorage, string token)
        {
            // Spara autentiserings-token som en sträng i lokal lagring.
            await localStorage.SetItemAsStringAsync(StorageKey, token);
        }

        // för att ta bort autentiserings-token från lokal lagring.
        public static async Task RemoveToken(ILocalStorageService localStorage)
        {
            // Ta bort autentiserings-token från lokal lagring.
            await localStorage.RemoveItemAsync(StorageKey);
        }
    }
}
