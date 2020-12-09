using System.ComponentModel.DataAnnotations.Schema;

namespace yogaAshram.Models
{
    public class ManagerEmployee
    {
        public long Id { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Employee Manager { get; set; }
        public long ManagerId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        public long EmployeeId { get; set; }
    }
}