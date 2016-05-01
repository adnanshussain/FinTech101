using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTech101.Models
{
    public class DateOrNumberOrSeID
    {
        public int seID { get; set; }
        public DateTime Date { get; set; }
        public String DoW { get; set; }
        public decimal? Value { get; set; } 
    }
}