using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dynamic;
using Rdl;

namespace TableToRdlc.Report
{
    public class TableBase
    {
        /// <summary>
        /// 生成的table占用的宽度(mm)
        /// </summary>
        public double TotalWidht { get; internal set; }

        public NewTablix Table
        {
            get;
            set;
        }


        public ColumnCollection Columns
        {
            get;
            set;
        }

        public CornerRowCollection Rows
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public TableBase()
        {
            Table = new NewTablix
                        {
                            Name = Name ?? "Table_" + Guid.NewGuid().ToString().Replace("-", ""),
                            Style = new Style { Border = new Border { Style = "Solid" }.Create() }
                        };
            Columns = new ColumnCollection();
            Rows = new CornerRowCollection();
        }


        public virtual void Create()
        {
            var row = CreateRow(6);
            row.Cells.Add(CreateCell("",null,null,true));
            var body = new TablixBodyEx
                           {
                               Columns = new ColumnCollection { new TablixColumnEx() { Width = "0.6in" } },
                               Rows = new RowCollection() { row }
                           };
            Table.TotalWidht = this.TotalWidht;
            Table.TablixCorner = new TablixCornerEx() { Rows = this.Rows };
            Table.TablixBody = body;
            Table.TablixColumnHierarchy = CreateTablixColumnHierarchy();
            Table.TablixRowHierarchy = CreateTablixRowHierarchy();
        }

        private TablixHierarchyType CreateTablixColumnHierarchy()
        {
            var members = CreateMs(new TablixMembersType(), true, false);
            var hie = new TablixHierarchy { TablixMembers = new TablixMembersType[] { members } };
            return hie.Create();
        }

        private TablixHierarchyType CreateTablixRowHierarchy()
        {
            var members = CreateMs(new TablixMembersType(), true, true);
            var hie = new TablixHierarchy { TablixMembers = new TablixMembersType[] { members } };
            return hie.Create();
        }

        int _level = 0;
        public TablixMembersType CreateMs(TablixMembersType parent, bool isStart, bool isRow)
        {
            if (isStart)
            {
                _level = 0;
            }
            var limit = isRow ? this.Columns.Count : this.Rows.Count;
            var tablixMember = new TablixMember();
            if ((!isRow && _level == limit - 1) || (isRow && _level==0))
            {
                tablixMember.Visibility = new Visibility() {Hidden = "true"}.Create();
                var group = new Group { GroupExpressions = new GroupExpressionsType() {GroupExpression=new string[]{""} } };
                tablixMember.Group = group.Create(isRow?"RowGroup":"ColumnGroup");
            }

            var heaer = new TablixHeader();
            var contents = new CellContents() { Textbox = CreateTextbox("",true) }.Create();
            heaer.CellContents = new CellContentsType[] { contents };
            string size = isRow ? this.Columns[_level].Width : this.Rows[_level].Height;
            heaer.Size = new string[] { size };
            tablixMember.TablixHeader = heaer.Create();


            _level++;
            if (_level < limit)
            {
                tablixMember.TablixMembers = CreateMs(new TablixMembersType(), false, isRow);
            }
            parent.TablixMember = new TablixMemberType[] { tablixMember.Create() };

            return parent;
        }



        public TablixRowEx CreateRow(double height)
        {
            var row = new TablixRowEx();
            //row.TablixCells = CreateTableCells();
            row.Height = height + "mm";
            return row;
        }

        public TablixColumnEx CreateColumn(double width)
        {
            var column = new TablixColumnEx { Width = width + "mm" };
            return column;
        }


        public TablixCell CreateCell(string fieldName, uint? colSpan, uint? rowSpan,bool hidden)
        {
            TextboxType textbox = null;
            if (hidden)
            {
                textbox = CreateTextbox(fieldName, true);
            }
            else
            {
                textbox = CreateTextbox(fieldName);
            }
            var cellContents = new CellContents() { Textbox = textbox };
            if (colSpan != null && colSpan > 1)
            {
                cellContents.ColSpan = colSpan;
            }
            if (rowSpan != null && rowSpan > 1)
            {
                cellContents.RowSpan = rowSpan;
            }

            var cell = new TablixCell
                           {
                               CellContents = cellContents.Create(),
                               IsEmpty = false,
                               HasSetValue = true
                           };
            
            return cell;
        }

         public TablixCell CreateCell(string fieldName, uint? colSpan, uint? rowSpan)
         {
             return CreateCell(fieldName, colSpan, rowSpan, false);
         }


         private TablixCell CreateCell(string fieldName)
         {
             return CreateCell(fieldName, null, null);
         }


        

        private Rdl.TextboxType CreateTextbox(string fieldName,bool hidden)
        {
            Textbox box = new Textbox();
            var style = new Style
            {
                FontSize = "9pt",
                FontWeight = "Bold",
                FontFamily = "宋体"
            };
            box.Paragraphs = Common.Report.RdlGenerator.CreateParagraphs(fieldName, style.Create());
            if (hidden)
            {
                box.Visibility = new Visibility() { Hidden = "true" }.Create();
            }
            
            box.Style = new Style
            {
                Border = new Border { Style = "Solid" }.Create()
            }.Create();
            box.CanGrow = true;
            string name = "Header_" + Seed;
            Seed++;
            return box.Create(name);
        }

        public Rdl.TextboxType CreateTextbox(string fieldName)
        {
            return CreateTextbox(fieldName, false);
        }

        protected int Seed;

    }
}
