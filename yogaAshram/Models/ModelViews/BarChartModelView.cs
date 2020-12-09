using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class BarChartModelView
    {
        public BarChartColumn[] Columns { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int MaxY { get; set; }
        public int Step { get; set; }
    }
}
