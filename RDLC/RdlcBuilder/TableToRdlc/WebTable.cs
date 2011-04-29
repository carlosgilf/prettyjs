using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Common.Dynamic;
using Common.Report;
using HtmlAgilityPack;
using System.IO;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

namespace TableToRdlc.Report
{
    public class WebTable
    {
        public List<TR> Rows = new List<TR>();
        public List<double> Columns = new List<double>();
        private bool Computed = false;


        public List<TextboxEx> ToReport()
        {
            return ToReport(10, 10);
        }


        private static string RenderControls(Control control)
        {
            control.Visible = true;
            control.EnableViewState = false;
            StringWriter output = new StringWriter();
            var m_pageHolder = new System.Web.UI.Page();
            var form = new System.Web.UI.HtmlControls.HtmlForm();
            form.Controls.Add(control);
            m_pageHolder.Controls.Add(form);
            HttpContext.Current.Server.Execute(m_pageHolder, output, false);
            return output.ToString();
        }

        public List<TextboxEx> ToReport(double initTop,double initLeft )
        {
            if (!Computed)
            {
                this.Computer();
            }
            var tbBuilder = new TextBoxBuilder();

            double currentHeight = initTop;
            var boxes = new List<TextboxEx>();
            foreach (var tr in Rows)
            {
                double height = tr.Height;
                
                foreach (var td in tr.Cells)
                {
                    double currentWidth = initLeft;
                    double tdHeight = 0;
                    double tdWidth = 0;

                    var txt = tbBuilder.CreateTextboxEx(td.Tag as HtmlNode);
                    for (int i = 0; i < td.ColSpan; i++)
                    {
                        tdWidth += Columns[i + td.ColumnIndex];
                    }

                    for (int i = 0; i < td.RowSpan; i++)
                    {
                        tdHeight += Rows[td.RowIndex + i].Height;
                    }
                 
                    for (int i = 0; i < td.ColumnIndex; i++)
                    {
                        currentWidth += Columns[i];
                    }
                    if (td.ColumnIndex>0)
                    {
                        txt.Style.LeftBorder = new Border { Style = "None" };
                    }

                    if (td.RowIndex > 0)
                    {
                        txt.Style.TopBorder = new Border { Style = "None" };
                    }
                    //if (td.ColSpan>1)
                    //{
                    //    currentWidth +=0.2;
                    //}
                    //if (td.RowSpan>1)
                    //{
                    //    currentHeight += 0.2;
                    //}

                    
                    
                    txt.Top = currentHeight + "mm";
                    txt.Left = currentWidth + "mm";
                    txt.CanGrow = false;
                    
                    txt.Width = tdWidth + "mm";
                    txt.Height = tdHeight + "mm";
                    boxes.Add(txt);
                }
                currentHeight += height;
            }
            return boxes;
        }

        public void Computer()
        {
            var columnCount = this.Columns.Count;
            var maxRowCellCount = columnCount;
            var rowCount = this.Rows.Count;

            var emptyTds = new List<Point>();


            var rowIndex = 0;
            foreach (var tr in Rows)
            {
                tr.RowIndex = rowIndex;
                var computed = false;

                //当前单元格的位置
                var currCellPos = 0;

                var tempRow = new TR();
                for (int i = 0; i < maxRowCellCount; i++)
                {
                    var cell = new TD();
                    if (emptyTds.Contains(new Point(i, rowIndex)))
                    {
                        cell.ShouldEmpty = true;
                    }
                    else
                    {
                        cell.ShouldEmpty = false;
                        if (!computed)
                        {
                            currCellPos = i;
                            computed = true;
                        }
                    }
                    cell.HasValue = false;
                    tempRow.Cells.Add(cell);
                }

                foreach (var td in tr.Cells)
                {
                    if (td == null)
                    {
                        continue;
                    }
                    td.RowIndex = rowIndex;


                    var colSpan = td.ColSpan;
                    var rowSpan = td.RowSpan;
                    if (rowSpan > 1 || colSpan > 1)
                    {
                        for (int y = rowIndex; y < rowIndex + rowSpan; y++)
                        {
                            for (int x = currCellPos; x < currCellPos + colSpan; x++)
                            {
                                //本身不算在内
                                if (y == rowIndex && x == currCellPos)
                                    continue;

                                //计算占位空TextBox
                                if (y == rowIndex)
                                {
                                    tempRow.Cells[x].ShouldEmpty = true;
                                }

                                emptyTds.Add(new Point { X = x, Y = y });
                            }
                        }
                    }


                    if (rowIndex > 0)
                    {
                        for (int i = 0; i < tempRow.Cells.Count; i++)
                        {
                            var c = tempRow.Cells[i];
                            if (c.ShouldEmpty == false && c.HasValue == false)
                            {
                                tempRow.Cells[i] = td;
                                td.ColumnIndex = i;

                                break;
                            }
                        }
                    }
                    else
                    {
                        td.ColumnIndex = currCellPos;
                    }
                    currCellPos += colSpan;

                }
                rowIndex++;
            }

            for (int i = 0; i < this.Columns.Count;i++ )
            {
                if (this.Columns[i] == 0)
                {
                    this.Columns[i] = 21;
                }
            }

            
            this.Computed = true;
        }

        public static WebTable HtmlToTable(Control control)
        {
            var html = RenderControls(control);
            return HtmlToTable(html);
        }

        public static WebTable HtmlToTable(string html)
        {
            var table = new WebTable();
            var widths = new double[100];

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var hnTable = doc.DocumentNode.SelectSingleNode("//table");
            var trNodes = hnTable.SelectNodes("tr");
            var maxCellCount = 0;
            foreach (var tr in trNodes)
            {
                var row = new TR();
                var cellCount = 0;
                var iHeight = RdlUtils.ConvertUnit(tr.GetAttributeValue("height", ""));
                var tdNodes = tr.SelectNodes("th|td");

                
                foreach (var td in tdNodes)
                {
                    var colSpan = td.GetAttributeValue("colspan", 1);
                    var rowSpan = td.GetAttributeValue("rowspan", 1);

                    var tdHeight = RdlUtils.ConvertUnit(td.GetAttributeValue("height", ""));
                    var tdWidth = RdlUtils.ConvertUnit(td.GetAttributeValue("width", ""));

                    if (tdWidth== 0)
                    {
                        tdWidth = 21;
                    }

                    if (rowSpan == 1)
                    {
                        if (tdHeight > iHeight)
                        {
                            iHeight = tdHeight;
                        }
                    }
                    if (colSpan == 1)
                    {
                        if (tdWidth > widths[cellCount])
                        {
                            widths[cellCount] = tdWidth;
                        }
                    }
                    var text = td.InnerText.Trim().Replace("&nbsp;", " ");

                    var font=new Font(new FontFamily("宋体") ,0.75F,FontStyle.Regular);
                    var size=System.Windows.Forms.TextRenderer.MeasureText(text, font);

                    //var ww=Common.Report.Rdlc.Enums.MeasureTools.UnitToMillimeters(new Unit(size.Width, UnitType.Pixel) );
                    //if (ww > tdWidth)
                    //{
                    //    var hh = Common.Report.Rdlc.Enums.MeasureTools.UnitToMillimeters(new Unit(size.Height, UnitType.Pixel));
                    //    tdHeight = Math.Ceiling(ww / tdWidth) * hh;
                    //    if (tdHeight > iHeight)
                    //    {
                    //        iHeight = tdHeight;
                    //    }
                    //}
                    

                    var cell = new TD(colSpan, rowSpan, text) { Tag = td };
                    row.Cells.Add(cell);
                    cellCount += colSpan;
                    if (maxCellCount < cellCount)
                    {
                        maxCellCount = cellCount;
                    }
                }
                iHeight = (iHeight == 0 ? 6 : iHeight);

               

                row.Height = iHeight;
                table.Rows.Add(row);
            }

            var columns = new List<double>();
            for (var i = 0; i < maxCellCount; i++)
            {
                columns.Add(widths[i]);
            }
            table.Columns = columns;
            return table;
        }
    }

    public class TD
    {
        public int ColSpan = 1;
        public int RowSpan = 1;

        public string Text;

        public object Tag;
        public TD()
        {
        }



        public TD(string text)
        {
            this.Text = text;
        }



        public TD(int colSpan, int rowSpan, string text)
        {
            ColSpan = colSpan;
            RowSpan = rowSpan;
            this.Text = text;
        }

        public TD(int colSpan, int rowSpan)
        {
            ColSpan = colSpan;
            RowSpan = rowSpan;
        }

        public int ColumnIndex
        {
            get;
            internal set;
        }

        public int RowIndex
        {
            get;
            internal set;
        }

        internal bool HasValue = true;
        internal bool ShouldEmpty = false;
    }

    public class TR
    {
        public List<TD> Cells = new List<TD>();
        public double Height = 0;

        public TR()
        {

        }

        public int RowIndex
        {
            get;
            internal set;
        }

        public TR(float Height)
        {
            this.Height = Height;
        }
    }

}
