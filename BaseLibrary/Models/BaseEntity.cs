﻿using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = string.Empty;
    }
}