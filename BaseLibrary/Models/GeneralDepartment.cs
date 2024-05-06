namespace BaseLibrary.Models
{
    public class GeneralDepartment : BaseEntity
    {
        // en till många relation med Deptartment
        public List<Department>? Departments { get; set; }
    }
}