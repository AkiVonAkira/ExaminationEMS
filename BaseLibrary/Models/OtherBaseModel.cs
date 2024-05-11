using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class OtherBaseModel
    {
        public int Id { get; set; }

        [Required]
        public string SocialSecurityNumberId { get; set; } = string.Empty;

        [Required]
        public string FileNumber { get; set; } = string.Empty;

        public string? Other { get; set; }
    }
}