using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class PaymentEditModelView
    {
        public string Comment { get; set; }
        public long PaymentId { get; set; }
        [Remote(action: "CheckPaymentType", controller: "Validation")]
        public PaymentType Type { get; set; }
        public int? CashSum { get; set; }
        public int? CardSum { get; set; }
        public Payment Payment { get; set; }
    }
}
