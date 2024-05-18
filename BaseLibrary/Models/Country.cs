using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class Country : BaseModel
    {
        // en till många relation med City
        [JsonIgnore]
        public List<City>? Cities { get; set; }
    }
}