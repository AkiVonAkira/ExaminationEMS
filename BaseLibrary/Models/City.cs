﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Models
{
   
    public class City : BaseEntity
    {
        // en till många relation med City
        public Country? Country { get; set; }
        public int CountryId { get; set; }
    }
}
