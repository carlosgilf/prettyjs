using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dynamic;
using HtmlAgilityPack;
using Rdl;

namespace TableToRdlc.Report
{
    public class TextBoxBuilder
    {
        static readonly string[] _aligns = new string[] { "center", "left", "right" };
        static readonly string[] _valigns = new string[] { "middle", "top", "bottom" };
        static readonly string[] units = new string[] { "in", "mm", "cm", "pt", "pc" };

        HtmlNode td;
        Dictionary<string, string> styles = new Dictionary<string, string>();

        public string SetStyle(string attrName, string styleName, string defValue, System.Action<string> action)
        {
            if (defValue == null)
            {
                defValue = "";
            }
            string value = defValue;
            if (!string.IsNullOrWhiteSpace(styleName) && styles.ContainsKey(styleName))
            {
                value = styles[styleName] == "" ? defValue : styles[styleName];
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(attrName))
                {
                    value = td.GetAttributeValue(attrName, defValue);
                }
            }
            if (!string.IsNullOrWhiteSpace(value) && action != null)
            {
                action(value);
            }
            return value;
        }

        public string SetStyle(string attrName, System.Action<string> action)
        {
            return SetStyle(attrName, attrName, "", action);
        }

        public TextboxEx CreateTextboxEx(HtmlNode td)
        {
            this.td = td;
            var text = td.InnerText.Trim().Replace("&nbsp;", " ");
            var textbox = CreateTextboxEx(text, false);
            this.styles = RdlUtils.StyleParser(td.GetAttributeValue("style", ""));

            SetStyle("height", (style) =>
            {
                var dHeight = RdlUtils.ConvertUnit(style);
                if (dHeight > 0)
                {
                    textbox.DHeight = dHeight;
                    textbox.Height = dHeight + "mm";
                }
            });

            SetStyle("width", (style) =>
            {
                var dHeight = RdlUtils.ConvertUnit(style);
                if (dHeight > 0)
                {
                    textbox.DHeight = dHeight;
                    textbox.Height = dHeight + "mm";
                }
            });


            SetStyle("align", "text-align", "", (style) =>
            {
                if (_aligns.Contains(style))
                {
                    textbox.Paragraph.TextRun.Style.TextAlign = RdlUtils.ToCasl(style);
                }
            });

            SetStyle("valign", "vertical-align", "middle", (style) =>
            {
                if (_valigns.Contains(style))
                {
                    textbox.Paragraph.TextRun.Style.VerticalAlign = RdlUtils.ToCasl(style);
                    textbox.Style.VerticalAlign = RdlUtils.ToCasl(style);
                }
            });

            SetStyle("color", (style) =>
            {
                textbox.Paragraph.TextRun.Style.Color = style;
            });

            SetStyle("font-family", (style) =>
            {
                textbox.Paragraph.TextRun.Style.FontFamily = RdlUtils.ToCasl(styles["font-family"]);
            });

            SetStyle("font-size", (size) =>
            {
                if (size.EndsWith("px"))
                {
                    size = RdlUtils.ConvertUnit(size) + "mm";
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
            });

            SetStyle("font-weight", (style) =>
            {
                textbox.Paragraph.TextRun.Style.FontWeight = RdlUtils.ToCasl(style);
            });

            SetStyle("font-style", (style) =>
            {
                if (style == "italic")
                {
                    textbox.Paragraph.TextRun.Style.FontStyle = "Italic";
                }
            });

            SetStyle("text-decoration", (style) =>
            {
                var decoration = RdlUtils.ToCasl(style);
                if ("Underline,Overline,LineThrough".Split(',').Contains(decoration))
                {
                    textbox.Paragraph.TextRun.Style.TextDecoration = decoration;
                }
            });

            SetStyle("bgcolor", "background-color", "", (style) =>
            {
                textbox.Paragraph.TextRun.Style.BackgroundColor = style;
                textbox.Paragraph.Style.BackgroundColor = style;
                textbox.Style.BackgroundColor = style;
            });

            string defLeft = "";
            if (textbox.Style.TextAlign == "Left" || string.IsNullOrWhiteSpace(textbox.Style.TextAlign))
            {
                defLeft = "2px";
            }

            string defTop = "";
            if (textbox.Style.VerticalAlign == "Top" || string.IsNullOrWhiteSpace(textbox.Style.TextAlign))
            {
                defTop = "2px";
            }

            SetStyle("", "padding-top", defTop, (style) =>
            {
                textbox.Style.PaddingTop =RdlUtils.ToMM(style);
            });
            SetStyle("", "padding-left", defLeft, (style) =>
            {
                textbox.Style.PaddingLeft = RdlUtils.ToMM(style);
            });
            SetStyle("", "padding-bottom", "", (style) =>
            {
                textbox.Style.PaddingBottom = RdlUtils.ToMM(style);
            });
            SetStyle("", "padding-right", "", (style) =>
            {
                textbox.Style.PaddingRight = RdlUtils.ToMM(style);
            });

            return textbox;
        }

        public TablixCornerCell CreateCornerCell(HtmlNode td, uint? colSpan, uint? rowSpan)
        {
            var cellContents = new CellContentsEx() { Textbox = CreateTextboxEx(td) };
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
            var cellContents = new CellContentsEx() { Textbox = CreateTextboxEx(fieldName, false) };
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
        int Seed = 0;
        public TextboxEx CreateTextboxEx(string fieldName, bool hidden)
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
                Name = "textbox_" + Seed,
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
    }
}
