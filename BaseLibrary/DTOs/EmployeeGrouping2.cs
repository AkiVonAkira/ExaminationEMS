using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class EmployeeGrouping2
    {
        [Required]
        public string JobTitle { get; set; } = string.Empty;

        [Required, Range(1, 99999, ErrorMessage = "You Must Select a Town")]
        public int TownId { get; set; }

        [Required, Range(1, 99999, ErrorMessage = "You Must Select a Section")]
        public int SectionId { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
