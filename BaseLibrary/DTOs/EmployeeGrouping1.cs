﻿using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class EmployeeGrouping1
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Photo { get; set; } = string.Empty;

        [Required]
        public string SocialSecurityNumberId { get; set; } = string.Empty;

        [Required]
        public string FileNumber { get; set; } = string.Empty;
    }
}
