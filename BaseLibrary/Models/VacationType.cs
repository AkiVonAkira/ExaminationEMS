using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class VacationType : BaseModel
    {
        // Många till en relation till vacation
        [JsonIgnore]
        public List<Vacation>? Vacations { get; set; }
    }
}