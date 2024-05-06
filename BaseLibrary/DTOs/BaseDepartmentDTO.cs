using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class BaseDepartmentDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(3)]
        public string? Name { get; set; }
    }
}
