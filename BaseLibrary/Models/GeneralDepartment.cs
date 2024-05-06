namespace BaseLibrary.Models
{
    public class GeneralDepartment : BaseModel
    {
        // en till många relation med Deptartment
        public List<Department>? Departments { get; set; }
    }
}