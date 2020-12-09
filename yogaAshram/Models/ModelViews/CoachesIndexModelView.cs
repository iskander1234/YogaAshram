using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class CoachesIndexModelView
    {
        public long? BranchId { get; set; }
        public string CoachName { get; set; }
        public CoachSelector[] Coaches { get; set; }
    }
}
