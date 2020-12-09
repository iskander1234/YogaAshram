using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class PaymentCreateModelView
    {
        public string Comment { get; set; } 
        [Remote(action: "CheckClient", controller: "Validation")]
        public long ClientId { get; set; }
        [Remote(action: "CheckPaymentType", controller: "Validation")]
        public PaymentType Type { get; set; }
        public int CashSum { get; set; }
        public int CardSum { get; set; }
        public Client Client { get; set; }
        public long BranchId { get; set; }
    }
}
