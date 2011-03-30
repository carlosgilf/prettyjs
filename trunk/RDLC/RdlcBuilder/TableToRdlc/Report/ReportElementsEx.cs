using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rdl;
using System.Collections;

namespace Common.Dynamic
{

    public class RdlCollection<T, TType, TTypes> : ICollection<T>, IEnumerable, ICreator<TTypes>
        where T : ICreator<TType>
        where TType : IType, new()
        where TTypes : IType, new()
    {
        List<T> items = new List<T>();
        public List<T> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }

        public TTypes Create()
        {
            TTypes type = new TTypes();
            ArrayList items = new ArrayList();
            if (Items != null)
            {
                foreach (var r in Items)
                {
                    items.Add(r.Create());
                }
            }

            type.Items = items.ToArray();
            return type;
        }

        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }

        #region ICollection<T> 成员

        public void Add(T item)
        {
            Items.Add(item);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool Contains(T item)
        {
            return Items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return Items.Remove(item);
        }

        #endregion

        #region IEnumerable<T> 成员

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion
    }

    public class RowCollection : RdlCollection<TablixRowEx, TablixRowType, TablixRowsType>
    {

    }

    public class CellCollection : RdlCollection<TablixCell, TablixCellType, TablixCellsType>
    {
    }

    public class ColumnCollection : RdlCollection<TablixColumnEx, TablixColumnType, TablixColumnsType>
    {
    }

    public class TablixColumnEx : ICreator<TablixColumnType>
    {

        //jrt,原来是数组
        public string Width;
        public TablixColumnType Create()
        {
            TablixColumnType type = new TablixColumnType();
            ArrayList items = new ArrayList();
            if (Width != null)
            {
                items.AddRange(new string[] { Width });
            }

            type.Items = items.ToArray();
            return type;
        }

    }

    public class TablixRowEx : ICreator<TablixRowType>
    {
        public string Height;
        public CellCollection Cells=new CellCollection();
        public TablixRowType Create()
        {
            TablixRowType type = new TablixRowType();
            ArrayList items = new ArrayList();
            if (Height != null)
            {
                items.Add(Height);
            }

            if (Cells != null)
            {
                items.Add(Cells.Create());
            }
            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixBodyEx
    {
        public ColumnCollection Columns=new ColumnCollection();
        public RowCollection Rows=new RowCollection();
        public TablixBodyType Create()
        {
            TablixBodyType type = new TablixBodyType();
            ArrayList items = new ArrayList();
            if (Columns != null)
            {
                items.AddRange(new Object[]{Columns.Create()});
            }
            if (Rows != null)
            {
                items.AddRange(new Object[]{Rows.Create()});
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class CornerRowCollection : RdlCollection<CornerRowEx, TablixCornerRowType, TablixCornerRowsType>
    {
    }


    public class CornerRowEx : ICreator<TablixCornerRowType>
    {
        //记录用
        public string Height;
        //TablixCornerRow
        //public TablixCornerCellType[] TablixCornerCell;
        public List<TablixCornerCell> Cells=new List<TablixCornerCell>();
        public TablixCornerRowType Create()
        {
            var type = new TablixCornerRowType();
            var items = new ArrayList();
            if (Cells != null)
            {
                foreach (var item in Cells)
                {
                    items.Add(item.Create());
                }
                //items.AddRange(TablixCornerCell);
            }

            type.Items = items.ToArray();
            return type;
        }


    }

 

    public class TablixCornerEx : ICreator<TablixCornerType>
    {
        #region ICreator<TablixCornerType> 成员
        public CornerRowCollection Rows=new CornerRowCollection();
        
        //public TablixCornerRowsType[] TablixCornerRows;
        public TablixCornerType Create()
        {
            var type = new TablixCornerType();
            var items = new ArrayList();
            if (Rows != null)
            {
                items.AddRange(new object[]{Rows.Create()});
            }

            type.Items = items.ToArray();
            return type;
        }

        #endregion
    }


    public class NewTablix
    {
        /// <summary>
        /// 生成的table占用的宽度(mm)
        /// </summary>
        public double TotalWidht { get; internal set; }

        public double TotalHeight { get; internal set; }

        public string Name;
        public ActionInfoType ActionInfo;
        public string Bookmark;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public TablixTypeDataElementOutput? DataElementOutput;
        public string DataSetName;
        public StringLocIDType DocumentMapLabel;
        public FiltersType Filters;
        public bool? FixedColumnHeaders;
        public bool? FixedRowHeaders;
        public uint? GroupsBeforeRowHeaders;
        public string Height;
        public bool? KeepTogether;
        public TablixTypeLayoutDirection? LayoutDirection;
        public string Left;
        public string NoRowsMessage;
        public bool? OmitBorderOnPageBreak;
        public PageBreakType PageBreak;
        public bool? RepeatColumnHeaders;
        public bool? RepeatRowHeaders;
        public string RepeatWith;
        public SortExpressionsType SortExpressions;
        public Style Style;
        public TablixBodyEx TablixBody;
        public TablixHierarchyType TablixColumnHierarchy;
        public TablixCornerEx TablixCorner;
        public TablixHierarchyType TablixRowHierarchy;
        public StringLocIDType ToolTip;
        public string Top;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public TablixType Create()
        {
            TablixType type = new TablixType();
            type.Name = Name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType73.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType73.Bookmark);
                items.Add(Bookmark);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType73.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType73.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType73.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DataSetName != null)
            {
                itemsElementName.Add(ItemsChoiceType73.DataSetName);
                items.Add(DataSetName);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType73.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Filters != null)
            {
                itemsElementName.Add(ItemsChoiceType73.Filters);
                items.Add(Filters);
            }
            if (FixedColumnHeaders != null)
            {
                itemsElementName.Add(ItemsChoiceType73.FixedColumnHeaders);
                items.Add(FixedColumnHeaders);
            }
            if (FixedRowHeaders != null)
            {
                itemsElementName.Add(ItemsChoiceType73.FixedRowHeaders);
                items.Add(FixedRowHeaders);
            }
            if (GroupsBeforeRowHeaders != null)
            {
                itemsElementName.Add(ItemsChoiceType73.GroupsBeforeRowHeaders);
                items.Add(GroupsBeforeRowHeaders);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType73.Height);
                items.Add(Height);
            }
            if (KeepTogether != null)
            {
                itemsElementName.Add(ItemsChoiceType73.KeepTogether);
                items.Add(KeepTogether);
            }
            if (LayoutDirection != null)
            {
                itemsElementName.Add(ItemsChoiceType73.LayoutDirection);
                items.Add(LayoutDirection);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType73.Left);
                items.Add(Left);
            }
            if (NoRowsMessage != null)
            {
                itemsElementName.Add(ItemsChoiceType73.NoRowsMessage);
                items.Add(NoRowsMessage);
            }
            if (OmitBorderOnPageBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType73.OmitBorderOnPageBreak);
                items.Add(OmitBorderOnPageBreak);
            }
            if (PageBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType73.PageBreak);
                items.Add(PageBreak);
            }
            if (RepeatColumnHeaders != null)
            {
                itemsElementName.Add(ItemsChoiceType73.RepeatColumnHeaders);
                items.Add(RepeatColumnHeaders);
            }
            if (RepeatRowHeaders != null)
            {
                itemsElementName.Add(ItemsChoiceType73.RepeatRowHeaders);
                items.Add(RepeatRowHeaders);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType73.RepeatWith);
                items.Add(RepeatWith);
            }
            if (SortExpressions != null)
            {
                itemsElementName.Add(ItemsChoiceType73.SortExpressions);
                items.Add(SortExpressions);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType73.Style);
                items.Add(Style.Create());
            }
            if (TablixBody != null)
            {
                itemsElementName.Add(ItemsChoiceType73.TablixBody);
                items.Add(TablixBody.Create());
            }
            if (TablixColumnHierarchy != null)
            {
                itemsElementName.Add(ItemsChoiceType73.TablixColumnHierarchy);
                items.Add(TablixColumnHierarchy);
            }
            if (TablixCorner != null)
            {
                itemsElementName.Add(ItemsChoiceType73.TablixCorner);
                items.Add(TablixCorner.Create());
            }
            if (TablixRowHierarchy != null)
            {
                itemsElementName.Add(ItemsChoiceType73.TablixRowHierarchy);
                items.Add(TablixRowHierarchy);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType73.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType73.Top);
                items.Add(Top);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType73.Visibility);
                items.Add(Visibility);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType73.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType73.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType73[])itemsElementName.ToArray(typeof(ItemsChoiceType73));
            return type;
        }
    }


    public class ReportItemsEx
    {
        public ChartType[] Chart;
        public CustomReportItemType[] CustomReportItem;
        public GaugePanelType[] GaugePanel;
        public ImageType[] Image;
        public LineType[] Line;
        public RectangleType[] Rectangle;
        public SubreportType[] Subreport;
        //public TablixType[] Tablix;

        public List<NewTablix> Tablixs=new List<NewTablix>();

        public TextboxType[] Textbox;
        public ReportItemsType Create()
        {
            ReportItemsType type = new ReportItemsType();
            ArrayList items = new ArrayList();
            if (Chart != null)
            {
                items.AddRange(Chart);
            }
            if (CustomReportItem != null)
            {
                items.AddRange(CustomReportItem);
            }
            if (GaugePanel != null)
            {
                items.AddRange(GaugePanel);
            }
            if (Image != null)
            {
                items.AddRange(Image);
            }
            if (Line != null)
            {
                items.AddRange(Line);
            }
            if (Rectangle != null)
            {
                items.AddRange(Rectangle);
            }
            if (Subreport != null)
            {
                items.AddRange(Subreport);
            }
            if (Tablixs != null && Tablixs.Count>0)
            {
                foreach (var t in Tablixs)
                {
                    items.Add(t.Create());
                }
                //items.AddRange(Tablix);
            }
            if (Textbox != null)
            {
                items.AddRange(Textbox);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TextRunEx
    {
        public ActionInfoType ActionInfo;
        public string Label;
        public string MarkupType;
        public StyleEx Style;
        public string ToolTip;
        public LocIDStringWithDataTypeAttribute Value;
        public TextRunType Create()
        {
            TextRunType type = new TextRunType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType11.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Label != null)
            {
                itemsElementName.Add(ItemsChoiceType11.Label);
                items.Add(Label);
            }
            if (MarkupType != null)
            {
                itemsElementName.Add(ItemsChoiceType11.MarkupType);
                items.Add(MarkupType);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType11.Style);
                items.Add(Style.Create());
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType11.ToolTip);
                items.Add(ToolTip);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType11.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType11[])itemsElementName.ToArray(typeof(ItemsChoiceType11));
            return type;
        }
    }

    public class ParagraphEx
    {
        public string HangingIndent;
        public string LeftIndent;
        public uint? ListLevel;
        public ParagraphTypeListStyle? ListStyle;
        public string RightIndent;
        public string SpaceAfter;
        public string SpaceBefore;
        public StyleEx Style;
        //public TextRunsType TextRuns;
        public TextRunEx TextRun;

        public ParagraphType CreateParagraph()
        {
            ParagraphType type = new ParagraphType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (HangingIndent != null)
            {
                itemsElementName.Add(ItemsChoiceType12.HangingIndent);
                items.Add(HangingIndent);
            }
            if (LeftIndent != null)
            {
                itemsElementName.Add(ItemsChoiceType12.LeftIndent);
                items.Add(LeftIndent);
            }
            if (ListLevel != null)
            {
                itemsElementName.Add(ItemsChoiceType12.ListLevel);
                items.Add(ListLevel);
            }
            if (ListStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType12.ListStyle);
                items.Add(ListStyle);
            }
            if (RightIndent != null)
            {
                itemsElementName.Add(ItemsChoiceType12.RightIndent);
                items.Add(RightIndent);
            }
            if (SpaceAfter != null)
            {
                itemsElementName.Add(ItemsChoiceType12.SpaceAfter);
                items.Add(SpaceAfter);
            }
            if (SpaceBefore != null)
            {
                itemsElementName.Add(ItemsChoiceType12.SpaceBefore);
                items.Add(SpaceBefore);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType12.Style);
                items.Add(Style.Create());
            }
            //if (TextRuns != null)
            //{
            //    itemsElementName.Add(ItemsChoiceType12.TextRuns);
            //    items.Add(TextRuns);
            //}

            if (TextRun != null)
            {
                itemsElementName.Add(ItemsChoiceType12.TextRuns);
                var runs=new TextRunsType {TextRun = new TextRunType[] {TextRun.Create()}};
                items.Add(runs);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType12[])itemsElementName.ToArray(typeof(ItemsChoiceType12));
            return type;
        }

        public ParagraphsType Create()
        {
            var para = CreateParagraph();
            var paragraphs = new ParagraphsType {Paragraph = new ParagraphType[] {para}};
            return paragraphs;
        }
    }





    public class TextboxEx
    {
        public ActionInfoType ActionInfo;
        public string Bookmark;
        public bool? CanGrow;
        public bool? CanShrink;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public TextboxTypeDataElementOutput? DataElementOutput;
        public TextboxTypeDataElementStyle? DataElementStyle;
        public StringLocIDType DocumentMapLabel;
        public string Height;
        public string HideDuplicates;
        public bool? KeepTogether;
        public string Left;
        public ParagraphEx Paragraph;
        public string RepeatWith;
        public StyleEx Style;
        //public StyleType Style;
        public ToggleImageType ToggleImage;
        public StringLocIDType ToolTip;
        public string Top;
        public UserSortType UserSort;
        //public VisibilityType Visibility;
        public Visibility Visibility;
        public string Width;
        public uint? ZIndex;
        public string Name;

        //数字记录
        public double DHeight;
        public double DWidth;

        public TextboxType Create(string name)
        {
            TextboxType type = new TextboxType();
            type.Name = Name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType14.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Bookmark);
                items.Add(Bookmark);
            }
            if (CanGrow != null)
            {
                itemsElementName.Add(ItemsChoiceType14.CanGrow);
                items.Add(CanGrow);
            }
            if (CanShrink != null)
            {
                itemsElementName.Add(ItemsChoiceType14.CanShrink);
                items.Add(CanShrink);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType14.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType14.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType14.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DataElementStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType14.DataElementStyle);
                items.Add(DataElementStyle);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType14.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Height);
                items.Add(Height);
            }
            if (HideDuplicates != null)
            {
                itemsElementName.Add(ItemsChoiceType14.HideDuplicates);
                items.Add(HideDuplicates);
            }
            if (KeepTogether != null)
            {
                itemsElementName.Add(ItemsChoiceType14.KeepTogether);
                items.Add(KeepTogether);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Left);
                items.Add(Left);
            }
            if (Paragraph != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Paragraphs);
                items.Add(Paragraph.Create());
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType14.RepeatWith);
                items.Add(RepeatWith);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Style);
                items.Add(Style.Create());
            }
            if (ToggleImage != null)
            {
                itemsElementName.Add(ItemsChoiceType14.ToggleImage);
                items.Add(ToggleImage);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType14.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Top);
                items.Add(Top);
            }
            if (UserSort != null)
            {
                itemsElementName.Add(ItemsChoiceType14.UserSort);
                items.Add(UserSort);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Visibility);
                items.Add(Visibility.Create());
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType14.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType14[])itemsElementName.ToArray(typeof(ItemsChoiceType14));
            return type;
        }
    }


    public class StyleEx
    {
        public string BackgroundColor;
        public string BackgroundGradientEndColor;
        public string BackgroundGradientType;
        public string BackgroundHatchType;
        public BackgroundImageType BackgroundImage;
        public Border Border;
        public Border BottomBorder;
        public string Calendar;
        public string Color;
        public string Direction;
        public string FontFamily;
        public string FontSize;
        public string FontStyle;
        public string FontWeight;
        public string Format;
        public string Language;
        public Border LeftBorder;
        public string LineHeight;
        public string NumeralLanguage;
        public string NumeralVariant;
        public string PaddingBottom;
        public string PaddingLeft;
        public string PaddingRight;
        public string PaddingTop;
        public Border RightBorder;
        public string ShadowColor;
        public string ShadowOffset;
        public string TextAlign;
        public string TextDecoration;
        public string TextEffect;
        public Border TopBorder;
        public string UnicodeBiDi;
        public string VerticalAlign;
        public string WritingMode;
        public StyleType Create()
        {
            StyleType type = new StyleType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (BackgroundColor != null)
            {
                itemsElementName.Add(ItemsChoiceType4.BackgroundColor);
                items.Add(BackgroundColor);
            }
            if (BackgroundGradientEndColor != null)
            {
                itemsElementName.Add(ItemsChoiceType4.BackgroundGradientEndColor);
                items.Add(BackgroundGradientEndColor);
            }
            if (BackgroundGradientType != null)
            {
                itemsElementName.Add(ItemsChoiceType4.BackgroundGradientType);
                items.Add(BackgroundGradientType);
            }
            if (BackgroundHatchType != null)
            {
                itemsElementName.Add(ItemsChoiceType4.BackgroundHatchType);
                items.Add(BackgroundHatchType);
            }
            if (BackgroundImage != null)
            {
                itemsElementName.Add(ItemsChoiceType4.BackgroundImage);
                items.Add(BackgroundImage);
            }
            if (Border != null)
            {
                itemsElementName.Add(ItemsChoiceType4.Border);
                items.Add(Border.Create());
            }
            if (BottomBorder != null)
            {
                itemsElementName.Add(ItemsChoiceType4.BottomBorder);
                items.Add(BottomBorder.Create());
            }
            if (Calendar != null)
            {
                itemsElementName.Add(ItemsChoiceType4.Calendar);
                items.Add(Calendar);
            }
            if (Color != null)
            {
                itemsElementName.Add(ItemsChoiceType4.Color);
                items.Add(Color);
            }
            if (Direction != null)
            {
                itemsElementName.Add(ItemsChoiceType4.Direction);
                items.Add(Direction);
            }
            if (FontFamily != null)
            {
                itemsElementName.Add(ItemsChoiceType4.FontFamily);
                items.Add(FontFamily);
            }
            if (FontSize != null)
            {
                itemsElementName.Add(ItemsChoiceType4.FontSize);
                items.Add(FontSize);
            }
            if (FontStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType4.FontStyle);
                items.Add(FontStyle);
            }
            if (FontWeight != null)
            {
                itemsElementName.Add(ItemsChoiceType4.FontWeight);
                items.Add(FontWeight);
            }
            if (Format != null)
            {
                itemsElementName.Add(ItemsChoiceType4.Format);
                items.Add(Format);
            }
            if (Language != null)
            {
                itemsElementName.Add(ItemsChoiceType4.Language);
                items.Add(Language);
            }
            if (LeftBorder != null)
            {
                itemsElementName.Add(ItemsChoiceType4.LeftBorder);
                items.Add(LeftBorder.Create());
            }
            if (LineHeight != null)
            {
                itemsElementName.Add(ItemsChoiceType4.LineHeight);
                items.Add(LineHeight);
            }
            if (NumeralLanguage != null)
            {
                itemsElementName.Add(ItemsChoiceType4.NumeralLanguage);
                items.Add(NumeralLanguage);
            }
            if (NumeralVariant != null)
            {
                itemsElementName.Add(ItemsChoiceType4.NumeralVariant);
                items.Add(NumeralVariant);
            }
            if (PaddingBottom != null)
            {
                itemsElementName.Add(ItemsChoiceType4.PaddingBottom);
                items.Add(PaddingBottom);
            }
            if (PaddingLeft != null)
            {
                itemsElementName.Add(ItemsChoiceType4.PaddingLeft);
                items.Add(PaddingLeft);
            }
            if (PaddingRight != null)
            {
                itemsElementName.Add(ItemsChoiceType4.PaddingRight);
                items.Add(PaddingRight);
            }
            if (PaddingTop != null)
            {
                itemsElementName.Add(ItemsChoiceType4.PaddingTop);
                items.Add(PaddingTop);
            }
            if (RightBorder != null)
            {
                itemsElementName.Add(ItemsChoiceType4.RightBorder);
                items.Add(RightBorder.Create());
            }
            if (ShadowColor != null)
            {
                itemsElementName.Add(ItemsChoiceType4.ShadowColor);
                items.Add(ShadowColor);
            }
            if (ShadowOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType4.ShadowOffset);
                items.Add(ShadowOffset);
            }
            if (TextAlign != null)
            {
                itemsElementName.Add(ItemsChoiceType4.TextAlign);
                items.Add(TextAlign);
            }
            if (TextDecoration != null)
            {
                itemsElementName.Add(ItemsChoiceType4.TextDecoration);
                items.Add(TextDecoration);
            }
            if (TextEffect != null)
            {
                itemsElementName.Add(ItemsChoiceType4.TextEffect);
                items.Add(TextEffect);
            }
            if (TopBorder != null)
            {
                itemsElementName.Add(ItemsChoiceType4.TopBorder);
                items.Add(TopBorder.Create());
            }
            if (UnicodeBiDi != null)
            {
                itemsElementName.Add(ItemsChoiceType4.UnicodeBiDi);
                items.Add(UnicodeBiDi);
            }
            if (VerticalAlign != null)
            {
                itemsElementName.Add(ItemsChoiceType4.VerticalAlign);
                items.Add(VerticalAlign);
            }
            if (WritingMode != null)
            {
                itemsElementName.Add(ItemsChoiceType4.WritingMode);
                items.Add(WritingMode);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType4[])itemsElementName.ToArray(typeof(ItemsChoiceType4));
            return type;
        }
    }

    public class CellContentsEx
    {
        public ChartType Chart;
        public uint? ColSpan;
        public CustomReportItemType CustomReportItem;
        public GaugePanelType GaugePanel;
        public ImageType Image;
        public LineType Line;
        public RectangleType Rectangle;
        public uint? RowSpan;
        public SubreportType Subreport;
        public TablixType Tablix;
        public TextboxEx Textbox;
        public CellContentsType Create()
        {
            CellContentsType type = new CellContentsType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Chart != null)
            {
                itemsElementName.Add(ItemsChoiceType71.Chart);
                items.Add(Chart);
            }
            if (ColSpan != null)
            {
                itemsElementName.Add(ItemsChoiceType71.ColSpan);
                items.Add(ColSpan);
            }
            if (CustomReportItem != null)
            {
                itemsElementName.Add(ItemsChoiceType71.CustomReportItem);
                items.Add(CustomReportItem);
            }
            if (GaugePanel != null)
            {
                itemsElementName.Add(ItemsChoiceType71.GaugePanel);
                items.Add(GaugePanel);
            }
            if (Image != null)
            {
                itemsElementName.Add(ItemsChoiceType71.Image);
                items.Add(Image);
            }
            if (Line != null)
            {
                itemsElementName.Add(ItemsChoiceType71.Line);
                items.Add(Line);
            }
            if (Rectangle != null)
            {
                itemsElementName.Add(ItemsChoiceType71.Rectangle);
                items.Add(Rectangle);
            }
            if (RowSpan != null)
            {
                itemsElementName.Add(ItemsChoiceType71.RowSpan);
                items.Add(RowSpan);
            }
            if (Subreport != null)
            {
                itemsElementName.Add(ItemsChoiceType71.Subreport);
                items.Add(Subreport);
            }
            if (Tablix != null)
            {
                itemsElementName.Add(ItemsChoiceType71.Tablix);
                items.Add(Tablix);
            }
            if (Textbox != null)
            {
                itemsElementName.Add(ItemsChoiceType71.Textbox);
                items.Add(Textbox.Create(Textbox.Name));
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType71[])itemsElementName.ToArray(typeof(ItemsChoiceType71));
            return type;
        }
    }
  

    public interface ICreator<T> //where T:IType
    {
        T Create();
    }


}
