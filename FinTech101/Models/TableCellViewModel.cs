using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTech101.Models
{
    public class TableRowViewModel
    {
        private List<TableCellViewModel> _tableCells = new List<TableCellViewModel>();

        public List<TableCellViewModel> TableCells
        {
            get { return (_tableCells); }
        }
    }

    public class TableCellViewModel
    {
        public String Text { get; set; }
        public String FontColor { get; set; }
        public String BackgroundColor { get; set; }
        public String FontWeight { get; set; }
        public int ColSpan { get; set; }
    }
}