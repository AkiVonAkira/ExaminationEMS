using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class Overtime : OtherBaseModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int NumberOfDays => (EndDate - StartDate).Days;

        // Många till en relation till overtime type
        public OvertimeType? OvertimeType { get; set; }

        [Required]
        public int OvertimeTypeId { get; set; }
    }
}