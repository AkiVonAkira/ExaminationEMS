using System.Text.Json;

namespace ClientLibrary.Helpers
{
    public static class Serializations
    {
        public static string Serialize<T>(T modelObject)
        {
            // Omvandlar ett objekt till JSON-format.
            return JsonSerializer.Serialize(modelObject);
        }

        public static T Deserialize<T>(string jsonString)
        {
            // Omvandlar JSON till ett specifikt objekt.
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public static IList<T> DeserializeList<T>(string jsonString)
        {
            // Omvandlar JSON till en lista av objekt av en given typ. 
            return JsonSerializer.Deserialize<IList<T>>(jsonString);
        }

    }
}
