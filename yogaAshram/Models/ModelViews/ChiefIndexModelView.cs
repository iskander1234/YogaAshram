using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class ChiefIndexModelView
    {
        public Employee Employee { get; set; }
        public CheckPasswordModelView CheckPassword { get; set; } = new CheckPasswordModelView();

        
    }
}
