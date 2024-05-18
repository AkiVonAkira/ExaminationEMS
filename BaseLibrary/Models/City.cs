using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class City : BaseModel
    {
        // en till många relation med City
        public Country? Country { get; set; }

        public int CountryId { get; set; }

        // en till många relation med Town
        [JsonIgnore]
        public List<Town>? Towns { get; set; }
    }
}