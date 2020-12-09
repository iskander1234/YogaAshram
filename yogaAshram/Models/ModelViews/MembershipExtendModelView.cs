using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class MembershipExtendModelView : PaymentCreateModelView
    {
      
        public long MembershipId { get; set; }
        public long GroupId { get; set; }
        public DateTime Date { get; set; }
    }
}
