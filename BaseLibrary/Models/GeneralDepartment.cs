using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class GeneralDepartment : BaseModel
    {
        [JsonIgnore]
        public List<Department>? Departments { get; set; }
    }
}