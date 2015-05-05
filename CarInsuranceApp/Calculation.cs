using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsuranceApp
{
    public class Calculation
    {
        public int cover_type { get; set; }
        public int county { get; set; }
        public int pen_points { get; set; }
        public double eng_size { get; set; }
        public int year { get; set; }
        public int no_of_claims { get; set; }
        public int age { get; set; }
        public double total { get; set; }
    }
}
