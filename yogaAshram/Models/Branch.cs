using System.Collections.Generic;

namespace yogaAshram.Models
{
    public class Branch
    {
        public long Id { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        
        public long ?AdminId { get; set; }
        public virtual Employee Admin { get; set; }
        
     
    }
}