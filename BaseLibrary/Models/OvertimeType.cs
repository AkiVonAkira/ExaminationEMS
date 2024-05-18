using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class OvertimeType : BaseModel
    {
        // Många till en relation till vacation type
        [JsonIgnore]
        public List<Overtime>? Overtimes { get; set; }
    }
}