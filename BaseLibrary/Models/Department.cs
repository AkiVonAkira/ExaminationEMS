namespace BaseLibrary.Models
{
    public class Department : BaseEntity
    {
        // många till en relation med General Department
        public GeneralDepartment? GeneralDepartment { get; set; }

        public int GeneralDepartmentId { get; set; }

        // en till många relation med Section
        public List<Section>? Sections { get; set; }
    }
}