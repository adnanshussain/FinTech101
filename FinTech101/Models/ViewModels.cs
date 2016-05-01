using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FinTech101.Models
{
    public class Q4_1_Model
    {
        public DataTable Result { get; set; }
        public bool IsRangeEvent = false;
        public int DaysBefore = 3;
        public int DaysAfter = 3;
        public int SetID = 1;
        public int EventID = 0;
    }
}