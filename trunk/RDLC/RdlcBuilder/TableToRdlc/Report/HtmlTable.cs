using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Report.Rdlc.Enums;
using HtmlAgilityPack;
using Common.Dynamic;
using Rdl;
namespace Common.Report
{
    public class HtmlTable : TableBase
    {
        public string TableHtml;
        public override void Create()
        {
            Genrator();
            base.Create();
        }

        TextBoxBuilder tbBuilder = new TextBoxBuilder();

        private void Genrator()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(TableHtml);
            HtmlNode hnTable = doc.DocumentNode.SelectSingleNode("//table");
            var trNodes = hnTable.SelectNodes("tr");
            int maxRowCellCount = 0;
            int rowIndex = 0;
            var widths = new double[50];

            var emptyTds = new List<string>();
            foreach (var tr in trNodes)
            {
                var tdNodes = tr.SelectNodes("th|td");
                var row = new CornerRowEx();
                var cellCount = 0;

                var iHeight = RdlUtils.ConvertUnit(tr.GetAttributeValue("height", ""));

                var computed = false;
                for (int i = 0; i < maxRowCellCount; i++)
                {
                    var cell = new TablixCornerCell();
                    if (emptyTds.Contains(i + "_" + rowIndex))
                    {
                        cell.ShouldEmpty = true;
                    }
                    else
                    {
                        cell.ShouldEmpty = false;
                        if (!computed)
                        {
                            cellCount = i;
                            computed = true;
                        }
                    }
                    row.Cells.Add(cell);
                }
                foreach (var td in tdNodes)
                {
                    var colSpan = td.GetAttributeValue("colspan", 1);
                    var rowSpan = td.GetAttributeValue("rowspan", 1);

                    var cell = tbBuilder.CreateCornerCell(td, (uint)colSpan, (uint)rowSpan);
                    if (rowSpan == 1)
                    {
                        if (cell.CellContents.Textbox.DHeight > iHeight)
                        {
                            iHeight = cell.CellContents.Textbox.DHeight;
                        }
                    }
                    if (colSpan == 1)
                    {
                        var width = cell.CellContents.Textbox.DWidth;
                        if (width > widths[cellCount])
                        {
                            widths[cellCount] = width;
                        }
                    }

                    if (rowIndex == 0)
                    {
                        row.Cells.Add(cell);
                    }
                    if (rowSpan > 1 || colSpan > 1)
                    {
                        for (int y = rowIndex; y < rowIndex + rowSpan; y++)
                        {
                            for (int x = cellCount; x < cellCount + colSpan; x++)
                            {
                                //本身不算在内
                                if (y == rowIndex && x == cellCount)
                                    continue;

                                //计算占位空TextBox
                                if (y == rowIndex)
                                {
                                    if (rowIndex == 0)
                                    {
                                        row.Cells.Add(new TablixCornerCell());
                                    }
                                    else
                                    {
                                        row.Cells[x] = new TablixCornerCell();
                                    }
                                }
                                emptyTds.Add(x.ToString() + "_" + y.ToString());
                            }
                        }
                    }

                    cellCount += colSpan;

                    if (rowIndex > 0)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            var c = row.Cells[i];
                            if (c.ShouldEmpty == false && c.HasSetValue == false)
                            {
                                row.Cells[i] = cell;
                                break;
                            }
                        }
                    }
                }
                if (cellCount > maxRowCellCount)
                {
                    maxRowCellCount = cellCount;
                }
                rowIndex++;
                //var iHeight = ConvertUnit(height);
                iHeight = (iHeight == 0 ? 6 : iHeight);
                TotalHeight += iHeight;
                row.Height = iHeight + "mm";
                this.Rows.Add(row);
            }

            for (var i = 0; i < maxRowCellCount; i++)
            {
                var width = widths[i];
                if (width == 0)
                {
                    width = 20;
                }
                TotalWidht += width;
                var column = this.CreateColumn(width);
                this.Columns.Add(column);
            }
        }



    }
}

