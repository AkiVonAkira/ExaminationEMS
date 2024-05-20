using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class Employee : BaseModel
    {
        [Required]
        public string? SocialSecurityNumber { get; set; } = string.Empty;

        [Required]
        public string? FileNumber { get; set; } = string.Empty;

        [Required]
        public string? JobTitle { get; set; } = string.Empty;

        [Required]
        public string? Address { get; set; } = string.Empty;

        [Required, DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; } = string.Empty; // We need string for ex. "+(46) 7...."

        [Required]
        public string? Photo { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        //Relation: En till många relation till Section

        public Section? Section { get; set; }
        public int SectionId { get; set; }

        public Town? Town { get; set; }
        public int TownId { get; set; }
    }
}