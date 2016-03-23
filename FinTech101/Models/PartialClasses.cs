using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTech101.Models
{
    public partial class SP_MonthsInWhichCompaniesWereUpAndDownResult
    {
        public String CompanyName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public decimal YearsActive { get; set; }
    }
}