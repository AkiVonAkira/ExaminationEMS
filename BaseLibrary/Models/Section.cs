using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class Section : BaseModel
    {
        // många till en relation med Department
        public Department? Department { get; set; }

        public int DepartmentId { get; set; }

        // en till många relation med Employee
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}