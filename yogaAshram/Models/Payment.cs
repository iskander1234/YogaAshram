using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models
{
    public enum PaymentType
    {
        Pay,
        Surcharge//(Доплата)
    }
    public class Payment
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public long CreatorId { get; set; }
        public long ClientsMembershipId { get; set; }
        public int Debts { get; set; } = 0;
        public int CashSum { get; set; } = 0;
        public int CardSum { get; set; } = 0;
        public int TotalSum
        {
            get
            {
                return CashSum + CardSum;
            }
        }
        public DateTime CateringDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public virtual ClientsMembership ClientsMembership { get; set; }
        public virtual Employee Creator { get; set; }
        public PaymentType Type { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch  { get; set; }
    }
}
