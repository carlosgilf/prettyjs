using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableToRdlc.Report;
using Common.Dynamic;

namespace Common.Report
{
    public class SimpleTableReportBuilder : BaseReportBuilder
    {
        public SimpleTable Table;
        public override ReportItemsEx CreateReportItems()
        {
            var reportItems=base.CreateReportItems();
            if (Table != null)
            {
                reportItems.Textboxs = Table.ToReport();
            }
            return reportItems;
        }
    }
}
