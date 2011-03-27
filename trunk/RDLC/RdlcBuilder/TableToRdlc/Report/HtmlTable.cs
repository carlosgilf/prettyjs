using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Report.Rdlc.Enums;
using HtmlAgilityPack;
using Common.Dynamic;
using Rdl;
namespace TableToRdlc.Report
{
    public class HtmlTable : TableBase
    {
        public string TableHtml;
        public override void Create()
        {
            Genrator();
            base.Create();
        }

       

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
                var tdNodes = tr.SelectNodes("td");
                var row = new CornerRowEx();
                var cellCount = 0;
                //var height = tr.GetAttributeValue("height", "");
                var iHeight = this.ConvertUnit(tr.GetAttributeValue("height", ""));

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
                    
                    var cell = this.CreateCornerCell(td, (uint)colSpan, (uint)rowSpan);
                    if (rowSpan == 1)
                    {
                        if (cell.CellContents.Textbox.DHeight > iHeight)
                        {
                            iHeight = cell.CellContents.Textbox.DHeight;
                        }
                        
                        //var tdHeight = tr.GetAttributeValue("height", "");
                        //if (!string.IsNullOrEmpty(tdHeight))
                        //{
                        //    height = tdHeight;
                        //}
                    }
                    if (colSpan == 1)
                    {
                        //var width = td.GetAttributeValue("width", "");
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

        private TextboxEx CreateTextboxEx(string fieldName, bool hidden)
        {
            var style = new StyleEx() { FontSize = "9pt", FontFamily = "宋体" };
            var parap = new ParagraphEx
                            {
                                Style = style,
                                TextRun = new TextRunEx()
                                {
                                    Value = new LocIDStringWithDataTypeAttribute { Value = fieldName },
                                    Style = style
                                }
                            };

            var box = new TextboxEx
            {
                Paragraph = parap,
                CanGrow = true,
                Name = "Header_" + Seed,
                Style = new StyleEx
                {
                    Border = new Border { Style = "Solid" }
                }
            };
            if (hidden)
            {
                box.Visibility = new Visibility() { Hidden = "true" };
            }

            Seed++;
            return box;
        }

        static readonly string[] _aligns = new string[] { "center", "left", "right" };
        static readonly string[] _valigns = new string[] { "middle", "top", "bottom" };
        static readonly  string[] units=new string[]{"in","mm","cm","pt","pc"};

        private TextboxEx CreateTextboxEx(HtmlNode td)
        {
            var text = td.InnerText.Trim();
            var textbox = CreateTextboxEx(text, false);
            var styles = StyleParser(td.GetAttributeValue("style", ""));

            var height = td.GetAttributeValue("height", "");
            if (styles.ContainsKey("height"))
            {
                height = styles["height"];
            }
            if (!string.IsNullOrWhiteSpace(height))
            {
                var dHeight = ConvertUnit(height);
                if (dHeight > 0)
                {
                    textbox.DHeight = dHeight;
                    textbox.Height = dHeight + "mm";
                }
            }
           

            var width = td.GetAttributeValue("width", "");
            if (styles.ContainsKey("width"))
            {
                width = styles["width"];
            }
            if (!string.IsNullOrWhiteSpace(width))
            {
                var dwidth = ConvertUnit(width);
                if (dwidth > 0)
                {
                    textbox.DWidth = dwidth;
                    textbox.Width = dwidth + "mm";
                }
            }


            var align = td.GetAttributeValue("align", "").ToLower();
            if (styles.ContainsKey("text-align"))
            {
                align = styles["text-align"];
            }
            if (!string.IsNullOrWhiteSpace(align) && _aligns.Contains(align))
            {
                textbox.Paragraph.TextRun.Style.TextAlign = ToCasl(align);
            }

            var valign = td.GetAttributeValue("valign", "middle");
            if (styles.ContainsKey("vertical-align"))
            {
                valign = styles["vertical-align"];
            }
            if (!string.IsNullOrWhiteSpace(valign) && _valigns.Contains(valign))
            {
                textbox.Paragraph.TextRun.Style.VerticalAlign =  ToCasl(valign);
                textbox.Style.VerticalAlign = ToCasl(valign);
            }

            if (styles.ContainsKey("color"))
            {
                textbox.Paragraph.TextRun.Style.Color = styles["color"];
            }

            if (styles.ContainsKey("font-family"))
            {
                textbox.Paragraph.TextRun.Style.FontFamily = ToCasl(styles["font-family"]);
            }

            if (styles.ContainsKey("font-size"))
            {
                var size = styles["font-size"];
                if (size.EndsWith("px"))
                {
                    size = ConvertUnit(size) + "mm";
                    textbox.Paragraph.TextRun.Style.FontSize = size;
                }
                else
                {
                    foreach (var unit in units)
                    {
                        if (size.EndsWith(unit))
                        {
                            textbox.Paragraph.TextRun.Style.FontSize = size;
                            break;
                        }
                    }
                }
            }

            if (styles.ContainsKey("font-weight"))
            {
                textbox.Paragraph.TextRun.Style.FontWeight = ToCasl(styles["font-weight"]);
            }
            if (styles.ContainsKey("font-style"))
            {
                var fontStyle = ToCasl(styles["font-style"]);
                if (fontStyle == "Italic")
                {
                    textbox.Paragraph.TextRun.Style.FontStyle = "Italic";
                }
            }
            if (styles.ContainsKey("text-decoration"))
            {
                var decoration = ToCasl(styles["text-decoration"]);
                if ("Underline,Overline,LineThrough".Split(',').Contains(decoration))
                {
                    textbox.Paragraph.TextRun.Style.TextDecoration = decoration;
                }
            }
            return textbox;
        }

        protected  string ToCasl(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return val;
            }
            return val.Substring(0, 1).ToUpper() + val.Substring(1, val.Length - 1).ToLower();
        }

        public Dictionary<string, string> StyleParser(string style)
        {
            var result = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(style))
            {
                var parts = style.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var part in parts)
                {
                    var nameValues = part.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (nameValues.Length == 2)
                    {
                        result[nameValues[0].Trim().ToLower()] = nameValues[1].Trim().ToLower();
                    }
                }
            }

            return result;
        }

        public TablixCornerCell CreateCornerCell(HtmlNode td, uint? colSpan, uint? rowSpan)
        {
            var cellContents = new CellContentsEx() { Textbox = this.CreateTextboxEx(td) };
            if (colSpan != null && colSpan > 1)
            {
                cellContents.ColSpan = colSpan;
            }
            if (rowSpan != null && rowSpan > 1)
            {
                cellContents.RowSpan = rowSpan;
            }

            var cell = new TablixCornerCell
            {
                CellContents = cellContents,
                ShouldEmpty = false,
                HasSetValue = true
            };
            return cell;
        }


        public TablixCornerCell CreateCornerCell(string fieldName, uint? colSpan, uint? rowSpan)
        {
            var cellContents = new CellContentsEx() { Textbox = this.CreateTextboxEx(fieldName, false) };
            if (colSpan != null && colSpan > 1)
            {
                cellContents.ColSpan = colSpan;
            }
            if (rowSpan != null && rowSpan > 1)
            {
                cellContents.RowSpan = rowSpan;
            }

            var cell = new TablixCornerCell
            {
                CellContents = cellContents,
                ShouldEmpty = false,
                HasSetValue = true
            };
            return cell;
        }

        public double ConvertUnit(string length)
        {
            if (string.IsNullOrEmpty(length))
            {
                return 0;
            }
            length = length.Trim();
            double result = 0;
            if (length.EndsWith("px", StringComparison.CurrentCultureIgnoreCase))
            {
                length = length.Remove(length.Length - 2, 2);
            }
            var value = double.TryParse(length, out result) ? result : 0;

            var unit = new System.Web.UI.WebControls.Unit(value, System.Web.UI.WebControls.UnitType.Pixel);
            return MeasureTools.UnitToMillimeters(unit);
        }

    }
}

