using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class Town : BaseModel
    {
        // en till många relation med Employee
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }

        // många till en relation med City
        public City? City { get; set; }

        public int CityId { get; set; }
    }
}