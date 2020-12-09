using System;
using System.Collections.Generic;

namespace yogaAshram.Models
{
    public class CalendarEvent
    {
        public long Id { get; set; } 
        public virtual Group Group { get; set; }
        public long GroupId { get; set; }
        public int NumberClients { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public DayOfWeek DayOfWeek { get; set; } 
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeFinish { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}