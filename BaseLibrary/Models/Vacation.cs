using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class Vacation : OtherBaseModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int NumberOfDays { get; set; }

        public DateTime EndDate => StartDate.AddDays(NumberOfDays);

        // Många till en relation till vacation type
        public VacationType? VacationType { get; set; }

        [Required]
        public int VacationTypeId { get; set; }
    }
}