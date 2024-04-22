using System;
namespace BaseLibrary.Models
{
    public class Employee : BaseEntity
    {
        public string? SocialSecurityNumberID { get; set; }

        public string? JobTitle { get; set; }

        public string? Adress { get; set; }

        public int PhoneNumber { get; set; }

        public Guid Photo { get; set; }

        public string? Description { get; set; }

        //Relation: En till många relation
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        public Department? Department { get; set; }
        public int DepartmentId { get; set; }

        public Section? Section { get; set; }
        public int SectionId { get; set; }

        public City? City { get; set; }
        public int CityId { get; set; }
    }
}


