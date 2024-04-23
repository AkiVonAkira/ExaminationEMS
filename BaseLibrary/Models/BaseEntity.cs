using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        //Relation: En till många relation
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}