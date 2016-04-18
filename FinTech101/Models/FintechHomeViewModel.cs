using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinTech101.Models
{
    public class FintechHomeViewModel
    {
        public SelectList StockEntityTypes;
        public SelectList StockEntities;
        public SelectList SetActiveYears_From;
        public SelectList SetActiveYears_To;
        public int SetMinYear;
        public int SetMaxYear;
        public ValueTextModel SelectedSET;
    }
}