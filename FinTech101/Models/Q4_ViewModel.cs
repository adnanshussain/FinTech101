using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FinTech101.Models
{
    public class Q4_ViewModel
    {
        public String EntityName { get; set; }
        public DataTable ResultDataTable = new DataTable();
        public int EventStartsOnIndex { get; set; }
        public int EventEndsOnIndex { get; set; }
        public bool ActualEventStartClosingPriceWasZero { get; set; }
        public bool ActualEventEndClosingPriceWasZero { get; set; }
        public decimal ClosingPriceChangeBeforeEvent { get; set; }
        public decimal ClosingPriceChangeAfterEvent { get; set; }
        public bool IsRange { get; set; }
    }
}