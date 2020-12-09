using System.Collections.Generic;

namespace yogaAshram.Models
{
    public class AttendanceCount
    {
        public long Id { get; set; }
        public int AttendingTimes { get; set; }
        public int AbsenceTimes { get; set; }
        public int FrozenTimes { get; set; }
    }
}