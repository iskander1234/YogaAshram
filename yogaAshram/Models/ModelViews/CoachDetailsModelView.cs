using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class CoachDetailsModelView
    {
        public Employee Coach { get; set; }
        public PaymentSelector[] Payments { get; set; }
        public List<Group> Groups { get; set; }
        public long? GroupId { get; set; }
    }
}
