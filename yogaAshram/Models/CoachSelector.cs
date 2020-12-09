using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models
{
    public class CoachSelector
    {
        public Employee Coach { get; set; }
        public Group[] Groups { get; set; }
    }
}
