using System.Collections.Generic;

namespace yogaAshram.Models.ModelViews.Transactions
{
    public class TransactionIndexModel
    {
        public List<Payment> Payments { get; set; }
        public List<Withdrawal> Withdrawals { get; set; }
        public CurrentSum CurrentSum { get; set; }
        public long  BranchId { get; set; }
        
      
    }
}
