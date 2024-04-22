using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class Relationship
    {
        //Relation: En till många relation
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}