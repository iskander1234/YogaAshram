using System.Collections.Generic;

namespace yogaAshram.Models.HelperModels
{
    public class AttendanceHistoryShow
    {
        public string Name { get; set; }
        public string  Group { get; set; }
        public List<int> Days { get; set; }
        
    }
}