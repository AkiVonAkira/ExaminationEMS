using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Models
{
    public class Country
    {
        // en till många relation med City
        public List<City>? Cities { get; set; }
        
    }
}
