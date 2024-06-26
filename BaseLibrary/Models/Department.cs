﻿using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class Department : BaseModel
    {
        // många till en relation med General Department
        public GeneralDepartment? GeneralDepartment { get; set; }

        public int GeneralDepartmentId { get; set; }

        // en till många relation med Section
        [JsonIgnore]
        public List<Section>? Sections { get; set; }
    }
}