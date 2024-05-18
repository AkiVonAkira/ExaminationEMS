using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = string.Empty;
    }
}