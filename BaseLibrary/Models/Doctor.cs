using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class Doctor : OtherBaseModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string MedicalDiagnose { get; set; } = string.Empty;

        [Required]
        public string MedicalRecommendation { get; set; } = string.Empty;
    }
}