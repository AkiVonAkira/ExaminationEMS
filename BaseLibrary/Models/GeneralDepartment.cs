using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class GeneralDepartment : BaseModel
    {
        [JsonIgnore]
        // en till många relation med Deptartment
        public List<Department>? Departments { get; set; }
    }
}