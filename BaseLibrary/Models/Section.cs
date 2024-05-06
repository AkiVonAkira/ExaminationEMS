namespace BaseLibrary.Models
{
    public class Section : BaseEntity
    {
        // många till en relation med Department
        public Department? Department { get; set; }

        public int DepartmentId { get; set; }

        // en till många relation med Employee
        public List<Employee>? Employees { get; set; }
    }
}