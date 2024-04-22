using System;
using System.Text.Json.Serialization;

namespace BaseLibrary.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}

