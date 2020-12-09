using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models
{
    public class PaymentSelector
    {
        public Client Client { get; set; }
        public int Amount { get; set; }
        public Payment[] Payments { get; set; }
        public PaymentSelector SetAmount()
        {
            if (Payments is null)
                Payments = new Payment[0] { };
            foreach (var item in Payments)
            {
                Amount += item.CardSum + item.CashSum;
            }
            return this;
        }
    }
}
