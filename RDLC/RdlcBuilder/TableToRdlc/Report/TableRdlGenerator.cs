using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Rdl;
using System.Collections;
using Common.Dynamic;

namespace Common.Report
{
    public class TableRdlGenerator
    {
        private IDictionary<string, string> m_fields;

        public IDictionary<string, string> Fields
        {
            get { return m_fields; }
            set { m_fields = value; }
        }
        public string TableName;
        public RdlGenerator Parent;
        public bool ShowHeader=true;
        public bool ShowDetails=true;
        

        public TableRdlGenerator()
        {
        }


        public TableRdlGenerator(RdlGenerator parent, string name)
        {
            this.Parent = parent;
            this.TableName = name;
        }

        public Rdl.TablixType CreateTable()
        {
            Tablix table = new Tablix();
            table.Style = new Style { Border = new Border { Style = "Solid" }.Create() }.Create();
            table.TablixBody = new TablixBody().Create();
            TablixBody tableBody = new TablixBody();
            tableBody.TablixColumns = new TablixColumnsType[] { CreateTablixColumns() };

            TablixRows rows = new TablixRows();
            List<TablixRowType> rowList = new List<TablixRowType>();

            TablixMembersType m_rowHierarchy = new TablixMembersType();
            List<TablixMemberType> members = new List<TablixMemberType>();
            if (ShowHeader)
            {
                rowList.Add( CreateHeaderTableRow());
                TablixMember m = new TablixMember();
                m.KeepWithGroup = TablixMemberTypeKeepWithGroup.After;
                members.Add(m.Create());
            }
            if (ShowDetails)
            {
                rowList.Add(CreateTableRow());

                //设置为详细
                TablixMember m = new TablixMember();
                GroupType g = new GroupType();
                g.Name = "详细信息";
                m.Group = g;

                TablixMembersType childMembers = new TablixMembersType();
                TablixMember childMember = new TablixMember();
                childMembers.TablixMember = new TablixMemberType[] { childMember.Create() };
                m.TablixMembers=childMembers;
                members.Add(m.Create());
            }
            rows.TablixRow = rowList.ToArray();

            //<TablixRowHierarchy>
            m_rowHierarchy.TablixMember = members.ToArray();
            TablixHierarchy rowHierarchy = new TablixHierarchy();
            rowHierarchy.TablixMembers = new TablixMembersType[] { m_rowHierarchy };
            table.TablixRowHierarchy = rowHierarchy.Create();

            //if (Parent.Grouping!=null)
            //{
            //    table.TableGroups = CreateTableGroups();
            //}
            tableBody.TablixRows = new TablixRowsType[]{ rows.Create()};
            table.TablixBody = tableBody.Create();

            //<TablixColumnHierarchy>
            table.TablixColumnHierarchy = CreateTablixColumnHierarchy();
            table.Top = "0.2mm";
            table.Left = Parent.LeftMargin.ToString() + "mm";
            return table.Create(TableName);
        }

        public TablixHierarchyType CreateTablixColumnHierarchy()
        {
            TablixMembersType main = new TablixMembersType();
            List<TablixMemberType> members = new List<TablixMemberType>();
            foreach (var f in m_fields)
            {
                TablixMember m = new TablixMember();
                members.Add(m.Create());
            }
            main.TablixMember = members.ToArray();
            TablixHierarchy hie = new TablixHierarchy();
            hie.TablixMembers = new TablixMembersType[] { main };
            return hie.Create();
        }

        private Rdl.TablixRowType CreateHeaderTableRow()
        {
            TablixRow row = new TablixRow();
            row.Height = "4.6mm";
            row.TablixCells = CreateHeaderTableCells();
            return row.Create();
        }

        private Rdl.TablixCellsType CreateHeaderTableCells()
        {
            Rdl.TablixCellsType headerTableCells = new Rdl.TablixCellsType();
           
            TablixCellType[] cells= new Rdl.TablixCellType[m_fields.Count];
            int i = 0;
            foreach (var f in m_fields)
            {
                cells[i] = CreateHeaderTableCell(f.Key);
                i++;
            }
            headerTableCells.Items = cells;
            return headerTableCells;
        }

        private Rdl.TablixCellType CreateHeaderTableCell(string fieldName)
        {
            TablixCell cell = new TablixCell();
            //cell.CellContents
            CellContents contents = new CellContents();
            contents.Textbox = CreateHeaderTableCellTextbox(fieldName);
            cell.CellContents = contents.Create();
            return cell.Create();
        }


        private Rdl.TextboxType CreateHeaderTableCellTextbox(string fieldName)
        {
            Textbox box = new Textbox();
            var style=new Style
            {
                FontSize = "9pt",
                FontWeight = "Bold",
                FontFamily="宋体"
            };
            box.Paragraphs = RdlGenerator.CreateParagraphs(fieldName, style.Create());

            box.Style = new Style
            {
                Border = new Border { Style = "Solid" }.Create()
            }.Create(); 
            box.CanGrow = true;
            return box.Create(m_fields[fieldName] + "_Header");
        }


        private Rdl.TablixRowType CreateTableRow()
        {
            // 此处设置宽度为最小值0.69mm [2008-7-30]
            //tableRow.Items = new object[] { CreateTableCells(), "0.69mm" };
            TablixRow row = new TablixRow();
            
            row.TablixCells = CreateTableCells();
            row.Height = "4.6mm";
            return row.Create();
            //tableRow.Items = new object[] { CreateTableCells(), "4.6mm" };
        }

        private Rdl.TablixCellsType CreateTableCells()
        {
            Rdl.TablixCellsType tableCells = new Rdl.TablixCellsType();
            TablixCellType[] cells=new TablixCellType[m_fields.Count];
            int i = 0;
            foreach (var f in m_fields)
            {
                cells[i] = CreateTablixCell(i, f.Value);
                i++;
            }
            tableCells.Items = cells;
            
            return tableCells;
        }

        private Rdl.TablixCellType CreateTablixCell(int i, string fieldName)
        {
            TablixCell cell = new TablixCell();
            //cell.CellContents
           
            CellContents contents = new CellContents();
            contents.Textbox = CreateTableCellTextbox(i, fieldName);
            cell.CellContents = contents.Create();
            return cell.Create();
        }

        private Style CreateStyle()
        {
            Style style = new Style();
            style.FontSize = "9pt";
            style.TextAlign = "Left";
            style.FontFamily = "宋体";
            return style;
        }

        private Rdl.TextboxType CreateTableCellTextbox(int i,string fieldName)
        {
            var cellStyle = CreateStyle();
            var fontStyle = CreateStyle();

            Border bd = new Border();
            bd.Style = "Solid";
            cellStyle.Border = bd.Create();

            string value = "=Fields!" + fieldName + ".Value";
            if (Parent.TableCellRenderer != null)
            {
                Parent.TableCellRenderer(fieldName, cellStyle, fontStyle,value);
            }
            
            Textbox box = new Textbox();
            box.Paragraphs = RdlGenerator.CreateParagraphs(value, fontStyle.Create());
            box.Style = cellStyle.Create();
            box.CanGrow = true;
            return box.Create(fieldName);
        }


        private Rdl.TablixColumnsType CreateTablixColumns()
        {
            Rdl.TablixColumnsType TablixColumns = new Rdl.TablixColumnsType();
            TablixColumns.Items = new Rdl.TablixColumnType[m_fields.Count];
            double bodyWidth = Parent.A4Width - (Parent.LeftMargin + Parent.RightMargin);
            double[] widths = Parent.Widths;

            int customColumnCount = 0;
            double customColumnWidthTotal = 0.00;
            if (widths != null)
            {
                for (int i = 0; i < widths.Length; i++)
                {
                    if (widths != null && widths.Length > i)
                    {
                        double width = 0.01;

                        //如果是正数表示百分比，负数则为实际宽度
                        if (widths[i]>0)
                        {
                            width = bodyWidth * widths[i];
                        }
                        else
                        {
                            width = Math.Abs(widths[i]);
                        }
                        customColumnWidthTotal += width;
                        customColumnCount++;
                    }
                }
            }

            for (int i = 0; i < m_fields.Count; i++)
            {
                double width = bodyWidth / m_fields.Count;
                
                if (widths != null && widths.Length > i )
                {
                    //如果是正数表示百分比，负数则为实际宽度
                    if (widths[i] > 0)
                    {
                        width = bodyWidth * widths[i];
                    }
                    else
                    {
                        width = Math.Abs(widths[i]);
                    }
                }
                else if (customColumnCount>0)
                {
                    width = (bodyWidth - customColumnWidthTotal) / (m_fields.Count - customColumnCount);
                }
                
                TablixColumns.Items[i] = CreateTablixColumn(width.ToString() + "mm");
            }
            return TablixColumns;
        }

        private Rdl.TablixColumnType CreateTablixColumn(string width)
        {
            Rdl.TablixColumnType TablixColumn = new Rdl.TablixColumnType();
            TablixColumn.Items = new object[] { width };
            return TablixColumn;
        }
    }

}
