using System;
using System.Collections.Generic;

namespace yogaAshram.Models
{
    public class ClientsMembership
    {
        public long Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public DateTime FirstDateOfLesson { get; set; }
        public long ClientId { get; set; }
        public virtual Client Client { get; set; }
        
        public long MembershipId { get; set; }
        public virtual Membership Membership { get; set; }
    }
}