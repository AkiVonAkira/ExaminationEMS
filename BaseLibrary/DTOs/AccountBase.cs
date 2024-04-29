using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class AccountBase
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        [Required]
        public string? Email { get; set; }

        [StringLength(100, ErrorMessage = "Must be at least 5 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
    }
}