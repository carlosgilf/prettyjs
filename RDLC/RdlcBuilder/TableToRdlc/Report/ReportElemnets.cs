/*
该文件是根据ReportDefinition.cs自动生成
生成工具：E:\jrt\新家校通系统\TryProject\Jrt代码生成\JrtGenerator\bin\Debug\JrtGenerator.exe
*/

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Rdl;
using System.Collections;
namespace Common.Dynamic
{

    public partial class ReportBuilder
    {
        public string Author;
        public uint? AutoRefresh;
        public BodyType Body;
        public ClassesType Classes;
        public string Code;
        public CodeModulesType CodeModules;
        public bool? ConsumeContainerWhitespace;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public ReportDataElementStyle? DataElementStyle;
        public string DataSchema;
        public DataSetsType DataSets;
        public DataSourcesType DataSources;
        public string DataTransform;
        public bool? DeferVariableEvaluation;
        public StringLocIDType Description;
        public EmbeddedImagesType EmbeddedImages;
        public string Language;
        public PageType Page;
        public ReportParametersType ReportParameters;
        public VariablesType Variables;
        public string Width;
        public Rdl.Report Create()
        {
            Rdl.Report type = new Rdl.Report();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Author != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Author);
                items.Add(Author);
            }
            if (AutoRefresh != null)
            {
                itemsElementName.Add(ItemsChoiceType80.AutoRefresh);
                items.Add(AutoRefresh);
            }
            if (Body != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Body);
                items.Add(Body);
            }
            if (Classes != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Classes);
                items.Add(Classes);
            }
            if (Code != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Code);
                items.Add(Code);
            }
            if (CodeModules != null)
            {
                itemsElementName.Add(ItemsChoiceType80.CodeModules);
                items.Add(CodeModules);
            }
            if (ConsumeContainerWhitespace != null)
            {
                itemsElementName.Add(ItemsChoiceType80.ConsumeContainerWhitespace);
                items.Add(ConsumeContainerWhitespace);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType80.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType80.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType80.DataElementStyle);
                items.Add(DataElementStyle);
            }
            if (DataSchema != null)
            {
                itemsElementName.Add(ItemsChoiceType80.DataSchema);
                items.Add(DataSchema);
            }
            if (DataSets != null)
            {
                itemsElementName.Add(ItemsChoiceType80.DataSets);
                items.Add(DataSets);
            }
            if (DataSources != null)
            {
                itemsElementName.Add(ItemsChoiceType80.DataSources);
                items.Add(DataSources);
            }
            if (DataTransform != null)
            {
                itemsElementName.Add(ItemsChoiceType80.DataTransform);
                items.Add(DataTransform);
            }
            if (DeferVariableEvaluation != null)
            {
                itemsElementName.Add(ItemsChoiceType80.DeferVariableEvaluation);
                items.Add(DeferVariableEvaluation);
            }
            if (Description != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Description);
                items.Add(Description);
            }
            if (EmbeddedImages != null)
            {
                itemsElementName.Add(ItemsChoiceType80.EmbeddedImages);
                items.Add(EmbeddedImages);
            }
            if (Language != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Language);
                items.Add(Language);
            }
            if (Page != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Page);
                items.Add(Page);
            }
            if (ReportParameters != null)
            {
                itemsElementName.Add(ItemsChoiceType80.ReportParameters);
                items.Add(ReportParameters);
            }
            if (Variables != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Variables);
                items.Add(Variables);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType80.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType80[])itemsElementName.ToArray(typeof(ItemsChoiceType80));
            return type;
        }
    }

    public class Body
    {
        public string Height;
        public ReportItemsType ReportItems;
        public StyleType Style;
        public BodyType Create()
        {
            BodyType type = new BodyType();
            ArrayList items = new ArrayList();
            if (Height != null)
            {
                items.Add(Height);
            }
            if (ReportItems != null)
            {
                items.Add(ReportItems);
            }
            if (Style != null)
            {
                items.Add(Style);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class ReportItems
    {
        public ChartType[] Chart;
        public CustomReportItemType[] CustomReportItem;
        public GaugePanelType[] GaugePanel;
        public ImageType[] Image;
        public LineType[] Line;
        public RectangleType[] Rectangle;
        public SubreportType[] Subreport;
        public TablixType[] Tablix;
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
            if (Tablix != null)
            {
                items.AddRange(Tablix);
            }
            if (Textbox != null)
            {
                items.AddRange(Textbox);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class Chart
    {
        public ActionInfoType ActionInfo;
        public string Bookmark;
        public ChartAnnotationsType ChartAnnotations;
        public ChartAreasType ChartAreas;
        public ChartBorderSkinType ChartBorderSkin;
        public ChartHierarchyType ChartCategoryHierarchy;
        public ChartCodeParametersType ChartCodeParameters;
        public ChartCustomPaletteColorsType ChartCustomPaletteColors;
        public ChartDataType ChartData;
        public ChartLegendsType ChartLegends;
        public ChartTitleType ChartNoDataMessage;
        public ChartHierarchyType ChartSeriesHierarchy;
        public ChartTitlesType ChartTitles;
        public string Code;
        public ChartTypeCodeLanguage? CodeLanguage;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public ChartTypeDataElementOutput? DataElementOutput;
        public string DataSetName;
        public StringLocIDType DocumentMapLabel;
        public string DynamicHeight;
        public string DynamicWidth;
        public FiltersType Filters;
        public string Height;
        public string Left;
        public string NoRowsMessage;
        public PageBreakType PageBreak;
        public string Palette;
        public string PaletteHatchBehavior;
        public string RepeatWith;
        public SortExpressionsType SortExpressions;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public string Top;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public ChartType Create(string name)
        {
            ChartType type = new ChartType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Bookmark);
                items.Add(Bookmark);
            }
            if (ChartAnnotations != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartAnnotations);
                items.Add(ChartAnnotations);
            }
            if (ChartAreas != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartAreas);
                items.Add(ChartAreas);
            }
            if (ChartBorderSkin != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartBorderSkin);
                items.Add(ChartBorderSkin);
            }
            if (ChartCategoryHierarchy != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartCategoryHierarchy);
                items.Add(ChartCategoryHierarchy);
            }
            if (ChartCodeParameters != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartCodeParameters);
                items.Add(ChartCodeParameters);
            }
            if (ChartCustomPaletteColors != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartCustomPaletteColors);
                items.Add(ChartCustomPaletteColors);
            }
            if (ChartData != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartData);
                items.Add(ChartData);
            }
            if (ChartLegends != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartLegends);
                items.Add(ChartLegends);
            }
            if (ChartNoDataMessage != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartNoDataMessage);
                items.Add(ChartNoDataMessage);
            }
            if (ChartSeriesHierarchy != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartSeriesHierarchy);
                items.Add(ChartSeriesHierarchy);
            }
            if (ChartTitles != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ChartTitles);
                items.Add(ChartTitles);
            }
            if (Code != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Code);
                items.Add(Code);
            }
            if (CodeLanguage != null)
            {
                itemsElementName.Add(ItemsChoiceType39.CodeLanguage);
                items.Add(CodeLanguage);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType39.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType39.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType39.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DataSetName != null)
            {
                itemsElementName.Add(ItemsChoiceType39.DataSetName);
                items.Add(DataSetName);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType39.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (DynamicHeight != null)
            {
                itemsElementName.Add(ItemsChoiceType39.DynamicHeight);
                items.Add(DynamicHeight);
            }
            if (DynamicWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType39.DynamicWidth);
                items.Add(DynamicWidth);
            }
            if (Filters != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Filters);
                items.Add(Filters);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Height);
                items.Add(Height);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Left);
                items.Add(Left);
            }
            if (NoRowsMessage != null)
            {
                itemsElementName.Add(ItemsChoiceType39.NoRowsMessage);
                items.Add(NoRowsMessage);
            }
            if (PageBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType39.PageBreak);
                items.Add(PageBreak);
            }
            if (Palette != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Palette);
                items.Add(Palette);
            }
            if (PaletteHatchBehavior != null)
            {
                itemsElementName.Add(ItemsChoiceType39.PaletteHatchBehavior);
                items.Add(PaletteHatchBehavior);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType39.RepeatWith);
                items.Add(RepeatWith);
            }
            if (SortExpressions != null)
            {
                itemsElementName.Add(ItemsChoiceType39.SortExpressions);
                items.Add(SortExpressions);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Top);
                items.Add(Top);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Visibility);
                items.Add(Visibility);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType39.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType39.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType39[])itemsElementName.ToArray(typeof(ItemsChoiceType39));
            return type;
        }
    }

    public class ActionInfo
    {
        public ActionsType[] Actions;
        public ActionInfoType Create()
        {
            ActionInfoType type = new ActionInfoType();
            ArrayList items = new ArrayList();
            if (Actions != null)
            {
                items.AddRange(Actions);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class Actions
    {
        public ActionType[] Action;
        public ActionsType Create()
        {
            ActionsType type = new ActionsType();
            ArrayList items = new ArrayList();
            if (Action != null)
            {
                items.AddRange(Action);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class Action
    {
        public string BookmarkLink;
        public DrillthroughType Drillthrough;
        public string Hyperlink;
        public ActionType Create()
        {
            ActionType type = new ActionType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (BookmarkLink != null)
            {
                itemsElementName.Add(ItemsChoiceType6.BookmarkLink);
                items.Add(BookmarkLink);
            }
            if (Drillthrough != null)
            {
                itemsElementName.Add(ItemsChoiceType6.Drillthrough);
                items.Add(Drillthrough);
            }
            if (Hyperlink != null)
            {
                itemsElementName.Add(ItemsChoiceType6.Hyperlink);
                items.Add(Hyperlink);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType6[])itemsElementName.ToArray(typeof(ItemsChoiceType6));
            return type;
        }
    }

    public class Drillthrough
    {
        public ParametersType[] Parameters;
        public string[] ReportName;
        public DrillthroughType Create()
        {
            DrillthroughType type = new DrillthroughType();
            ArrayList items = new ArrayList();
            if (Parameters != null)
            {
                items.AddRange(Parameters);
            }
            if (ReportName != null)
            {
                items.AddRange(ReportName);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class Parameter
    {
        public string Omit;
        public string Value;
        public ParameterType Create(string name)
        {
            ParameterType type = new ParameterType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Omit != null)
            {
                itemsElementName.Add(ItemsChoiceType5.Omit);
                items.Add(Omit);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType5.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType5[])itemsElementName.ToArray(typeof(ItemsChoiceType5));
            return type;
        }
    }

    public class Class
    {
        public string ClassName;
        public string InstanceName;
        public ClassType Create()
        {
            ClassType type = new ClassType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ClassName != null)
            {
                itemsElementName.Add(ItemsChoiceType79.ClassName);
                items.Add(ClassName);
            }
            if (InstanceName != null)
            {
                itemsElementName.Add(ItemsChoiceType79.InstanceName);
                items.Add(InstanceName);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType79[])itemsElementName.ToArray(typeof(ItemsChoiceType79));
            return type;
        }
    }





    public class EmbeddedImage
    {
        public string ImageData;
        public string MIMEType;
        public EmbeddedImageType Create(string name)
        {
            EmbeddedImageType type = new EmbeddedImageType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ImageData != null)
            {
                itemsElementName.Add(ItemsChoiceType78.ImageData);
                items.Add(ImageData);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType78.MIMEType);
                items.Add(MIMEType);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType78[])itemsElementName.ToArray(typeof(ItemsChoiceType78));
            return type;
        }
    }



    public class PageSection
    {
        public string Height;
        public bool? PrintOnFirstPage;
        public bool? PrintOnLastPage;
        public ReportItemsType ReportItems;
        public StyleType Style;
        public PageSectionType Create()
        {
            PageSectionType type = new PageSectionType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType76.Height);
                items.Add(Height);
            }
            if (PrintOnFirstPage != null)
            {
                itemsElementName.Add(ItemsChoiceType76.PrintOnFirstPage);
                items.Add(PrintOnFirstPage);
            }
            if (PrintOnLastPage != null)
            {
                itemsElementName.Add(ItemsChoiceType76.PrintOnLastPage);
                items.Add(PrintOnLastPage);
            }
            if (ReportItems != null)
            {
                itemsElementName.Add(ItemsChoiceType76.ReportItems);
                items.Add(ReportItems);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType76.Style);
                items.Add(Style);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType76[])itemsElementName.ToArray(typeof(ItemsChoiceType76));
            return type;
        }
    }

    public class Style
    {
        public string BackgroundColor;
        public string BackgroundGradientEndColor;
        public string BackgroundGradientType;
        public string BackgroundHatchType;
        public BackgroundImageType BackgroundImage;
        public BorderType Border;
        public BorderType BottomBorder;
        public string Calendar;
        public string Color;
        public string Direction;
        public string FontFamily;
        public string FontSize;
        public string FontStyle;
        public string FontWeight;
        public string Format;
        public string Language;
        public BorderType LeftBorder;
        public string LineHeight;
        public string NumeralLanguage;
        public string NumeralVariant;
        public string PaddingBottom;
        public string PaddingLeft;
        public string PaddingRight;
        public string PaddingTop;
        public BorderType RightBorder;
        public string ShadowColor;
        public string ShadowOffset;
        public string TextAlign;
        public string TextDecoration;
        public string TextEffect;
        public BorderType TopBorder;
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
                items.Add(Border);
            }
            if (BottomBorder != null)
            {
                itemsElementName.Add(ItemsChoiceType4.BottomBorder);
                items.Add(BottomBorder);
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
                items.Add(LeftBorder);
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
                items.Add(RightBorder);
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
                items.Add(TopBorder);
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

    public class BackgroundImage
    {
        public string BackgroundRepeat;
        public string MIMEType;
        public string Position;
        public BackgroundImageTypeSource? Source;
        public string TransparentColor;
        public string Value;
        public BackgroundImageType Create()
        {
            BackgroundImageType type = new BackgroundImageType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (BackgroundRepeat != null)
            {
                itemsElementName.Add(ItemsChoiceType3.BackgroundRepeat);
                items.Add(BackgroundRepeat);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType3.MIMEType);
                items.Add(MIMEType);
            }
            if (Position != null)
            {
                itemsElementName.Add(ItemsChoiceType3.Position);
                items.Add(Position);
            }
            if (Source != null)
            {
                itemsElementName.Add(ItemsChoiceType3.Source);
                items.Add(Source);
            }
            if (TransparentColor != null)
            {
                itemsElementName.Add(ItemsChoiceType3.TransparentColor);
                items.Add(TransparentColor);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType3.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType3[])itemsElementName.ToArray(typeof(ItemsChoiceType3));
            return type;
        }
    }

    public class Border
    {
        public string Color;
        public string Style;
        public string Width;
        public BorderType Create()
        {
            BorderType type = new BorderType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Color != null)
            {
                itemsElementName.Add(ItemsChoiceType2.Color);
                items.Add(Color);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType2.Style);
                items.Add(Style);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType2.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType2[])itemsElementName.ToArray(typeof(ItemsChoiceType2));
            return type;
        }
    }

    public class Page
    {
        public string BottomMargin;
        public string ColumnSpacing;
        public int? Columns;
        public string InteractiveHeight;
        public string InteractiveWidth;
        public string LeftMargin;
        public PageSectionType PageFooter;
        public PageSectionType PageHeader;
        public string PageHeight;
        public string PageWidth;
        public string RightMargin;
        public StyleType Style;
        public string TopMargin;
        public PageType Create()
        {
            PageType type = new PageType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (BottomMargin != null)
            {
                itemsElementName.Add(ItemsChoiceType77.BottomMargin);
                items.Add(BottomMargin);
            }
            if (ColumnSpacing != null)
            {
                itemsElementName.Add(ItemsChoiceType77.ColumnSpacing);
                items.Add(ColumnSpacing);
            }
            if (Columns != null)
            {
                itemsElementName.Add(ItemsChoiceType77.Columns);
                items.Add(Columns);
            }
            if (InteractiveHeight != null)
            {
                itemsElementName.Add(ItemsChoiceType77.InteractiveHeight);
                items.Add(InteractiveHeight);
            }
            if (InteractiveWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType77.InteractiveWidth);
                items.Add(InteractiveWidth);
            }
            if (LeftMargin != null)
            {
                itemsElementName.Add(ItemsChoiceType77.LeftMargin);
                items.Add(LeftMargin);
            }
            if (PageFooter != null)
            {
                itemsElementName.Add(ItemsChoiceType77.PageFooter);
                items.Add(PageFooter);
            }
            if (PageHeader != null)
            {
                itemsElementName.Add(ItemsChoiceType77.PageHeader);
                items.Add(PageHeader);
            }
            if (PageHeight != null)
            {
                itemsElementName.Add(ItemsChoiceType77.PageHeight);
                items.Add(PageHeight);
            }
            if (PageWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType77.PageWidth);
                items.Add(PageWidth);
            }
            if (RightMargin != null)
            {
                itemsElementName.Add(ItemsChoiceType77.RightMargin);
                items.Add(RightMargin);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType77.Style);
                items.Add(Style);
            }
            if (TopMargin != null)
            {
                itemsElementName.Add(ItemsChoiceType77.TopMargin);
                items.Add(TopMargin);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType77[])itemsElementName.ToArray(typeof(ItemsChoiceType77));
            return type;
        }
    }

    public class ParameterValue
    {
        public StringLocIDType[] Label;
        public string[] Value;
        public ParameterValueType Create()
        {
            ParameterValueType type = new ParameterValueType();
            ArrayList items = new ArrayList();
            if (Label != null)
            {
                items.AddRange(Label);
            }
            if (Value != null)
            {
                items.AddRange(Value);
            }

            type.Items = items.ToArray();
            return type;
        }
    }





    public class ValidValues
    {
        public DataSetReferenceType[] DataSetReference;
        public ParameterValuesType[] ParameterValues;
        public ValidValuesType Create()
        {
            ValidValuesType type = new ValidValuesType();
            ArrayList items = new ArrayList();
            if (DataSetReference != null)
            {
                items.AddRange(DataSetReference);
            }
            if (ParameterValues != null)
            {
                items.AddRange(ParameterValues);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class DataSetReference
    {
        public string DataSetName;
        public string LabelField;
        public string ValueField;
        public DataSetReferenceType Create()
        {
            DataSetReferenceType type = new DataSetReferenceType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (DataSetName != null)
            {
                itemsElementName.Add(ItemsChoiceType74.DataSetName);
                items.Add(DataSetName);
            }
            if (LabelField != null)
            {
                itemsElementName.Add(ItemsChoiceType74.LabelField);
                items.Add(LabelField);
            }
            if (ValueField != null)
            {
                itemsElementName.Add(ItemsChoiceType74.ValueField);
                items.Add(ValueField);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType74[])itemsElementName.ToArray(typeof(ItemsChoiceType74));
            return type;
        }
    }



    public class DefaultValue
    {
        public DataSetReferenceType[] DataSetReference;
        public ValuesType[] Values;
        public DefaultValueType Create()
        {
            DefaultValueType type = new DefaultValueType();
            ArrayList items = new ArrayList();
            if (DataSetReference != null)
            {
                items.AddRange(DataSetReference);
            }
            if (Values != null)
            {
                items.AddRange(Values);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class ReportParameter
    {
        public bool? AllowBlank;
        public ReportParameterTypeDataType? DataType;
        public DefaultValueType DefaultValue;
        public bool? Hidden;
        public bool? MultiValue;
        public bool? Nullable;
        public StringLocIDType Prompt;
        public ReportParameterTypeUsedInQuery? UsedInQuery;
        public ValidValuesType ValidValues;
        public ReportParameterType Create(string name)
        {
            ReportParameterType type = new ReportParameterType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AllowBlank != null)
            {
                itemsElementName.Add(ItemsChoiceType75.AllowBlank);
                items.Add(AllowBlank);
            }
            if (DataType != null)
            {
                itemsElementName.Add(ItemsChoiceType75.DataType);
                items.Add(DataType);
            }
            if (DefaultValue != null)
            {
                itemsElementName.Add(ItemsChoiceType75.DefaultValue);
                items.Add(DefaultValue);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType75.Hidden);
                items.Add(Hidden);
            }
            if (MultiValue != null)
            {
                itemsElementName.Add(ItemsChoiceType75.MultiValue);
                items.Add(MultiValue);
            }
            if (Nullable != null)
            {
                itemsElementName.Add(ItemsChoiceType75.Nullable);
                items.Add(Nullable);
            }
            if (Prompt != null)
            {
                itemsElementName.Add(ItemsChoiceType75.Prompt);
                items.Add(Prompt);
            }
            if (UsedInQuery != null)
            {
                itemsElementName.Add(ItemsChoiceType75.UsedInQuery);
                items.Add(UsedInQuery);
            }
            if (ValidValues != null)
            {
                itemsElementName.Add(ItemsChoiceType75.ValidValues);
                items.Add(ValidValues);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType75[])itemsElementName.ToArray(typeof(ItemsChoiceType75));
            return type;
        }
    }



    public class TablixHeader
    {
        public CellContentsType[] CellContents;
        public string[] Size;
        public TablixHeaderType Create()
        {
            TablixHeaderType type = new TablixHeaderType();
            ArrayList items = new ArrayList();
            if (CellContents != null)
            {
                items.AddRange(CellContents);
            }
            if (Size != null)
            {
                items.AddRange(Size);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class CellContents
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
        public TextboxType Textbox;
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
                items.Add(Textbox);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType71[])itemsElementName.ToArray(typeof(ItemsChoiceType71));
            return type;
        }
    }

    public class CustomReportItem
    {
        public ActionInfoType ActionInfo;
        public ReportItemsType AltReportItem;
        public string Bookmark;
        public CustomDataType CustomData;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public CustomReportItemTypeDataElementOutput? DataElementOutput;
        public StringLocIDType DocumentMapLabel;
        public string Height;
        public string Left;
        public string RepeatWith;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public string Top;
        public string Type;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public CustomReportItemType Create(string name)
        {
            CustomReportItemType type = new CustomReportItemType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType70.ActionInfo);
                items.Add(ActionInfo);
            }
            if (AltReportItem != null)
            {
                itemsElementName.Add(ItemsChoiceType70.AltReportItem);
                items.Add(AltReportItem);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType70.Bookmark);
                items.Add(Bookmark);
            }
            if (CustomData != null)
            {
                itemsElementName.Add(ItemsChoiceType70.CustomData);
                items.Add(CustomData);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType70.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType70.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType70.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType70.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType70.Height);
                items.Add(Height);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType70.Left);
                items.Add(Left);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType70.RepeatWith);
                items.Add(RepeatWith);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType70.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType70.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType70.Top);
                items.Add(Top);
            }
            if (Type != null)
            {
                itemsElementName.Add(ItemsChoiceType70.Type);
                items.Add(Type);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType70.Visibility);
                items.Add(Visibility);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType70.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType70.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType70[])itemsElementName.ToArray(typeof(ItemsChoiceType70));
            return type;
        }
    }

    public class CustomData
    {
        public DataColumnHierarchyType[] DataColumnHierarchy;
        public DataRowHierarchyType[] DataRowHierarchy;
        public DataRowsType[] DataRows;
        public string[] DataSetName;
        public FiltersType[] Filters;
        public SortExpressionsType[] SortExpressions;
        public CustomDataType Create()
        {
            CustomDataType type = new CustomDataType();
            ArrayList items = new ArrayList();
            if (DataColumnHierarchy != null)
            {
                items.AddRange(DataColumnHierarchy);
            }
            if (DataRowHierarchy != null)
            {
                items.AddRange(DataRowHierarchy);
            }
            if (DataRows != null)
            {
                items.AddRange(DataRows);
            }
            if (DataSetName != null)
            {
                items.AddRange(DataSetName);
            }
            if (Filters != null)
            {
                items.AddRange(Filters);
            }
            if (SortExpressions != null)
            {
                items.AddRange(SortExpressions);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class DataColumnHierarchy
    {
        public DataMembersType[] DataMembers;
        public DataColumnHierarchyType Create()
        {
            DataColumnHierarchyType type = new DataColumnHierarchyType();
            ArrayList items = new ArrayList();
            if (DataMembers != null)
            {
                items.AddRange(DataMembers);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class DataMember
    {
        public CustomPropertiesType[] CustomProperties;
        public DataMembersType[] DataMembers;
        public GroupType[] Group;
        public SortExpressionsType[] SortExpressions;
        public bool[] Subtotal;
        public DataMemberType Create()
        {
            DataMemberType type = new DataMemberType();
            ArrayList items = new ArrayList();
            if (CustomProperties != null)
            {
                items.AddRange(CustomProperties);
            }
            if (DataMembers != null)
            {
                items.AddRange(DataMembers);
            }
            if (Group != null)
            {
                items.AddRange(Group);
            }
            if (SortExpressions != null)
            {
                items.AddRange(SortExpressions);
            }
            if (Subtotal != null)
            {
                items.AddRange(Subtotal);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class CustomProperty
    {
        public string Name;
        public string Value;
        public CustomPropertyType Create()
        {
            CustomPropertyType type = new CustomPropertyType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Name != null)
            {
                itemsElementName.Add(ItemsChoiceType8.Name);
                items.Add(Name);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType8.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType8[])itemsElementName.ToArray(typeof(ItemsChoiceType8));
            return type;
        }
    }

    public class Group
    {
        public string DataElementName;
        public GroupTypeDataElementOutput? DataElementOutput;
        public StringLocIDType DocumentMapLabel;
        public FiltersType Filters;
        public GroupExpressionsType GroupExpressions;
        public PageBreakType PageBreak;
        public string Parent;
        public GroupExpressionsType ReGroupExpressions;
        public VariablesType Variables;
        public GroupType Create(string name)
        {
            GroupType type = new GroupType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType17.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType17.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType17.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Filters != null)
            {
                itemsElementName.Add(ItemsChoiceType17.Filters);
                items.Add(Filters);
            }
            if (GroupExpressions != null)
            {
                itemsElementName.Add(ItemsChoiceType17.GroupExpressions);
                items.Add(GroupExpressions);
            }
            if (PageBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType17.PageBreak);
                items.Add(PageBreak);
            }
            if (Parent != null)
            {
                itemsElementName.Add(ItemsChoiceType17.Parent);
                items.Add(Parent);
            }
            if (ReGroupExpressions != null)
            {
                itemsElementName.Add(ItemsChoiceType17.ReGroupExpressions);
                items.Add(ReGroupExpressions);
            }
            if (Variables != null)
            {
                itemsElementName.Add(ItemsChoiceType17.Variables);
                items.Add(Variables);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType17[])itemsElementName.ToArray(typeof(ItemsChoiceType17));
            return type;
        }
    }



    public class Filter
    {
        public string[] FilterExpression;
        public FilterValuesType[] FilterValues;
        public FilterTypeOperator[] Operator;
        public FilterType Create()
        {
            FilterType type = new FilterType();
            ArrayList items = new ArrayList();
            if (FilterExpression != null)
            {
                items.AddRange(FilterExpression);
            }
            if (FilterValues != null)
            {
                items.AddRange(FilterValues);
            }
            if (Operator != null)
            {
                items.AddRange(Operator);
            }

            type.Items = items.ToArray();
            return type;
        }
    }







    public class PageBreak
    {
        public PageBreakTypeBreakLocation[] BreakLocation;
        public PageBreakType Create()
        {
            PageBreakType type = new PageBreakType();
            ArrayList items = new ArrayList();
            if (BreakLocation != null)
            {
                items.AddRange(BreakLocation);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class Variables
    {
        public VariableType[] Variable;
        public VariablesType Create()
        {
            VariablesType type = new VariablesType();
            ArrayList items = new ArrayList();
            if (Variable != null)
            {
                items.AddRange(Variable);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class Variable
    {
        public StringWithDataTypeAttribute[] Value;
        public VariableType Create(string name)
        {
            VariableType type = new VariableType();
            type.Name = name;
            ArrayList items = new ArrayList();
            if (Value != null)
            {
                items.AddRange(Value);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class SortExpression
    {
        public SortExpressionTypeDirection[] Direction;
        public string[] Value;
        public SortExpressionType Create()
        {
            SortExpressionType type = new SortExpressionType();
            ArrayList items = new ArrayList();
            if (Direction != null)
            {
                items.AddRange(Direction);
            }
            if (Value != null)
            {
                items.AddRange(Value);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class DataRowHierarchy
    {
        public DataMembersType[] DataMembers;
        public DataRowHierarchyType Create()
        {
            DataRowHierarchyType type = new DataRowHierarchyType();
            ArrayList items = new ArrayList();
            if (DataMembers != null)
            {
                items.AddRange(DataMembers);
            }

            type.Items = items.ToArray();
            return type;
        }
    }







    public class DataValue
    {
        public string Name;
        public string Value;
        public DataValueType Create()
        {
            DataValueType type = new DataValueType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Name != null)
            {
                itemsElementName.Add(ItemsChoiceType69.Name);
                items.Add(Name);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType69.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType69[])itemsElementName.ToArray(typeof(ItemsChoiceType69));
            return type;
        }
    }

    public class Visibility
    {
        public string Hidden;
        public string ToggleItem;
        public VisibilityType Create()
        {
            VisibilityType type = new VisibilityType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType7.Hidden);
                items.Add(Hidden);
            }
            if (ToggleItem != null)
            {
                itemsElementName.Add(ItemsChoiceType7.ToggleItem);
                items.Add(ToggleItem);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType7[])itemsElementName.ToArray(typeof(ItemsChoiceType7));
            return type;
        }
    }

    public class GaugePanel
    {
        public ActionInfoType ActionInfo;
        public string AntiAliasing;
        public string AutoLayout;
        public BackFrameType BackFrame;
        public string Bookmark;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public GaugePanelTypeDataElementOutput? DataElementOutput;
        public string DataSetName;
        public StringLocIDType DocumentMapLabel;
        public FiltersType Filters;
        public GaugeImagesType GaugeImages;
        public GaugeLabelsType GaugeLabels;
        public GaugeMemberType GaugeMember;
        public string Height;
        public string Left;
        public LinearGaugesType LinearGauges;
        public string NoRowsMessage;
        public NumericIndicatorsType NumericIndicators;
        public PageBreakType PageBreak;
        public RadialGaugesType RadialGauges;
        public string RepeatWith;
        public string ShadowIntensity;
        public SortExpressionsType SortExpressions;
        public StateIndicatorsType StateIndicators;
        public StyleType Style;
        public string TextAntiAliasingQuality;
        public StringLocIDType ToolTip;
        public string Top;
        public TopImageType TopImage;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public GaugePanelType Create(string name)
        {
            GaugePanelType type = new GaugePanelType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType68.ActionInfo);
                items.Add(ActionInfo);
            }
            if (AntiAliasing != null)
            {
                itemsElementName.Add(ItemsChoiceType68.AntiAliasing);
                items.Add(AntiAliasing);
            }
            if (AutoLayout != null)
            {
                itemsElementName.Add(ItemsChoiceType68.AutoLayout);
                items.Add(AutoLayout);
            }
            if (BackFrame != null)
            {
                itemsElementName.Add(ItemsChoiceType68.BackFrame);
                items.Add(BackFrame);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType68.Bookmark);
                items.Add(Bookmark);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType68.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType68.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType68.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DataSetName != null)
            {
                itemsElementName.Add(ItemsChoiceType68.DataSetName);
                items.Add(DataSetName);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType68.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Filters != null)
            {
                itemsElementName.Add(ItemsChoiceType68.Filters);
                items.Add(Filters);
            }
            if (GaugeImages != null)
            {
                itemsElementName.Add(ItemsChoiceType68.GaugeImages);
                items.Add(GaugeImages);
            }
            if (GaugeLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType68.GaugeLabels);
                items.Add(GaugeLabels);
            }
            if (GaugeMember != null)
            {
                itemsElementName.Add(ItemsChoiceType68.GaugeMember);
                items.Add(GaugeMember);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType68.Height);
                items.Add(Height);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType68.Left);
                items.Add(Left);
            }
            if (LinearGauges != null)
            {
                itemsElementName.Add(ItemsChoiceType68.LinearGauges);
                items.Add(LinearGauges);
            }
            if (NoRowsMessage != null)
            {
                itemsElementName.Add(ItemsChoiceType68.NoRowsMessage);
                items.Add(NoRowsMessage);
            }
            if (NumericIndicators != null)
            {
                itemsElementName.Add(ItemsChoiceType68.NumericIndicators);
                items.Add(NumericIndicators);
            }
            if (PageBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType68.PageBreak);
                items.Add(PageBreak);
            }
            if (RadialGauges != null)
            {
                itemsElementName.Add(ItemsChoiceType68.RadialGauges);
                items.Add(RadialGauges);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType68.RepeatWith);
                items.Add(RepeatWith);
            }
            if (ShadowIntensity != null)
            {
                itemsElementName.Add(ItemsChoiceType68.ShadowIntensity);
                items.Add(ShadowIntensity);
            }
            if (SortExpressions != null)
            {
                itemsElementName.Add(ItemsChoiceType68.SortExpressions);
                items.Add(SortExpressions);
            }
            if (StateIndicators != null)
            {
                itemsElementName.Add(ItemsChoiceType68.StateIndicators);
                items.Add(StateIndicators);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType68.Style);
                items.Add(Style);
            }
            if (TextAntiAliasingQuality != null)
            {
                itemsElementName.Add(ItemsChoiceType68.TextAntiAliasingQuality);
                items.Add(TextAntiAliasingQuality);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType68.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType68.Top);
                items.Add(Top);
            }
            if (TopImage != null)
            {
                itemsElementName.Add(ItemsChoiceType68.TopImage);
                items.Add(TopImage);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType68.Visibility);
                items.Add(Visibility);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType68.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType68.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType68[])itemsElementName.ToArray(typeof(ItemsChoiceType68));
            return type;
        }
    }

    public class BackFrame
    {
        public FrameBackgroundType FrameBackground;
        public FrameImageType FrameImage;
        public string FrameShape;
        public string FrameStyle;
        public string FrameWidth;
        public string GlassEffect;
        public StyleType Style;
        public BackFrameType Create()
        {
            BackFrameType type = new BackFrameType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (FrameBackground != null)
            {
                itemsElementName.Add(ItemsChoiceType41.FrameBackground);
                items.Add(FrameBackground);
            }
            if (FrameImage != null)
            {
                itemsElementName.Add(ItemsChoiceType41.FrameImage);
                items.Add(FrameImage);
            }
            if (FrameShape != null)
            {
                itemsElementName.Add(ItemsChoiceType41.FrameShape);
                items.Add(FrameShape);
            }
            if (FrameStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType41.FrameStyle);
                items.Add(FrameStyle);
            }
            if (FrameWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType41.FrameWidth);
                items.Add(FrameWidth);
            }
            if (GlassEffect != null)
            {
                itemsElementName.Add(ItemsChoiceType41.GlassEffect);
                items.Add(GlassEffect);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType41.Style);
                items.Add(Style);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType41[])itemsElementName.ToArray(typeof(ItemsChoiceType41));
            return type;
        }
    }



    public class FrameImage
    {
        public string ClipImage;
        public string HueColor;
        public string MIMEType;
        public string Source;
        public string Transparency;
        public string TransparentColor;
        public string Value;
        public FrameImageType Create()
        {
            FrameImageType type = new FrameImageType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ClipImage != null)
            {
                itemsElementName.Add(ItemsChoiceType40.ClipImage);
                items.Add(ClipImage);
            }
            if (HueColor != null)
            {
                itemsElementName.Add(ItemsChoiceType40.HueColor);
                items.Add(HueColor);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType40.MIMEType);
                items.Add(MIMEType);
            }
            if (Source != null)
            {
                itemsElementName.Add(ItemsChoiceType40.Source);
                items.Add(Source);
            }
            if (Transparency != null)
            {
                itemsElementName.Add(ItemsChoiceType40.Transparency);
                items.Add(Transparency);
            }
            if (TransparentColor != null)
            {
                itemsElementName.Add(ItemsChoiceType40.TransparentColor);
                items.Add(TransparentColor);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType40.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType40[])itemsElementName.ToArray(typeof(ItemsChoiceType40));
            return type;
        }
    }



    public class GaugeImage
    {
        public ActionInfoType ActionInfo;
        public string Angle;
        public string Height;
        public string Hidden;
        public string Left;
        public string MIMEType;
        public string ParentItem;
        public string ResizeMode;
        public string Source;
        public string ToolTip;
        public string Top;
        public string Transparency;
        public string TransparentColor;
        public string Value;
        public string Width;
        public string ZIndex;
        public GaugeImageType Create(string name)
        {
            GaugeImageType type = new GaugeImageType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType66.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Angle != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Angle);
                items.Add(Angle);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Height);
                items.Add(Height);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Hidden);
                items.Add(Hidden);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Left);
                items.Add(Left);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType66.MIMEType);
                items.Add(MIMEType);
            }
            if (ParentItem != null)
            {
                itemsElementName.Add(ItemsChoiceType66.ParentItem);
                items.Add(ParentItem);
            }
            if (ResizeMode != null)
            {
                itemsElementName.Add(ItemsChoiceType66.ResizeMode);
                items.Add(ResizeMode);
            }
            if (Source != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Source);
                items.Add(Source);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType66.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Top);
                items.Add(Top);
            }
            if (Transparency != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Transparency);
                items.Add(Transparency);
            }
            if (TransparentColor != null)
            {
                itemsElementName.Add(ItemsChoiceType66.TransparentColor);
                items.Add(TransparentColor);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Value);
                items.Add(Value);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType66.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType66.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType66[])itemsElementName.ToArray(typeof(ItemsChoiceType66));
            return type;
        }
    }



    public class GaugeLabel
    {
        public ActionInfoType ActionInfo;
        public string Angle;
        public string Height;
        public string Hidden;
        public string Left;
        public string ParentItem;
        public string ResizeMode;
        public StyleType Style;
        public string Text;
        public string TextShadowOffset;
        public string ToolTip;
        public string Top;
        public string UseFontPercent;
        public string Width;
        public string ZIndex;
        public GaugeLabelType Create(string name)
        {
            GaugeLabelType type = new GaugeLabelType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType67.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Angle != null)
            {
                itemsElementName.Add(ItemsChoiceType67.Angle);
                items.Add(Angle);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType67.Height);
                items.Add(Height);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType67.Hidden);
                items.Add(Hidden);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType67.Left);
                items.Add(Left);
            }
            if (ParentItem != null)
            {
                itemsElementName.Add(ItemsChoiceType67.ParentItem);
                items.Add(ParentItem);
            }
            if (ResizeMode != null)
            {
                itemsElementName.Add(ItemsChoiceType67.ResizeMode);
                items.Add(ResizeMode);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType67.Style);
                items.Add(Style);
            }
            if (Text != null)
            {
                itemsElementName.Add(ItemsChoiceType67.Text);
                items.Add(Text);
            }
            if (TextShadowOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType67.TextShadowOffset);
                items.Add(TextShadowOffset);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType67.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType67.Top);
                items.Add(Top);
            }
            if (UseFontPercent != null)
            {
                itemsElementName.Add(ItemsChoiceType67.UseFontPercent);
                items.Add(UseFontPercent);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType67.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType67.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType67[])itemsElementName.ToArray(typeof(ItemsChoiceType67));
            return type;
        }
    }

    public class GaugeMemberEx
    {
        public GaugeMemberType[] GaugeMember;
        public GroupType[] Group;
        public SortExpressionsType[] SortExpressions;
        public GaugeMemberType Create()
        {
            GaugeMemberType type = new GaugeMemberType();
            ArrayList items = new ArrayList();
            if (GaugeMember != null)
            {
                items.AddRange(GaugeMember);
            }
            if (Group != null)
            {
                items.AddRange(Group);
            }
            if (SortExpressions != null)
            {
                items.AddRange(SortExpressions);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class LinearGauge
    {
        public ActionInfoType ActionInfo;
        public string AspectRatio;
        public BackFrameType BackFrame;
        public string ClipContent;
        public LinearScalesType GaugeScales;
        public string Height;
        public string Hidden;
        public string Left;
        public string Orientation;
        public string ParentItem;
        public string ToolTip;
        public string Top;
        public TopImageType TopImage;
        public string Width;
        public string ZIndex;
        public LinearGaugeType Create(string name)
        {
            LinearGaugeType type = new LinearGaugeType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType60.ActionInfo);
                items.Add(ActionInfo);
            }
            if (AspectRatio != null)
            {
                itemsElementName.Add(ItemsChoiceType60.AspectRatio);
                items.Add(AspectRatio);
            }
            if (BackFrame != null)
            {
                itemsElementName.Add(ItemsChoiceType60.BackFrame);
                items.Add(BackFrame);
            }
            if (ClipContent != null)
            {
                itemsElementName.Add(ItemsChoiceType60.ClipContent);
                items.Add(ClipContent);
            }
            if (GaugeScales != null)
            {
                itemsElementName.Add(ItemsChoiceType60.GaugeScales);
                items.Add(GaugeScales);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType60.Height);
                items.Add(Height);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType60.Hidden);
                items.Add(Hidden);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType60.Left);
                items.Add(Left);
            }
            if (Orientation != null)
            {
                itemsElementName.Add(ItemsChoiceType60.Orientation);
                items.Add(Orientation);
            }
            if (ParentItem != null)
            {
                itemsElementName.Add(ItemsChoiceType60.ParentItem);
                items.Add(ParentItem);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType60.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType60.Top);
                items.Add(Top);
            }
            if (TopImage != null)
            {
                itemsElementName.Add(ItemsChoiceType60.TopImage);
                items.Add(TopImage);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType60.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType60.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType60[])itemsElementName.ToArray(typeof(ItemsChoiceType60));
            return type;
        }
    }



    public class LinearScale
    {
        public ActionInfoType ActionInfo;
        public CustomLabelsType CustomLabels;
        public string EndMargin;
        public GaugeTickMarksType GaugeMajorTickMarks;
        public GaugeTickMarksType GaugeMinorTickMarks;
        public LinearPointersType GaugePointers;
        public string Hidden;
        public string Interval;
        public string IntervalOffset;
        public string Logarithmic;
        public string LogarithmicBase;
        public ScalePinType MaximumPin;
        public GaugeInputValueType MaximumValue;
        public ScalePinType MinimumPin;
        public GaugeInputValueType MinimumValue;
        public string Multiplier;
        public string Position;
        public string Reversed;
        public ScaleLabelsType ScaleLabels;
        public ScaleRangesType ScaleRanges;
        public string StartMargin;
        public StyleType Style;
        public string TickMarksOnTop;
        public string ToolTip;
        public string Width;
        public LinearScaleType Create(string name)
        {
            LinearScaleType type = new LinearScaleType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType59.ActionInfo);
                items.Add(ActionInfo);
            }
            if (CustomLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType59.CustomLabels);
                items.Add(CustomLabels);
            }
            if (EndMargin != null)
            {
                itemsElementName.Add(ItemsChoiceType59.EndMargin);
                items.Add(EndMargin);
            }
            if (GaugeMajorTickMarks != null)
            {
                itemsElementName.Add(ItemsChoiceType59.GaugeMajorTickMarks);
                items.Add(GaugeMajorTickMarks);
            }
            if (GaugeMinorTickMarks != null)
            {
                itemsElementName.Add(ItemsChoiceType59.GaugeMinorTickMarks);
                items.Add(GaugeMinorTickMarks);
            }
            if (GaugePointers != null)
            {
                itemsElementName.Add(ItemsChoiceType59.GaugePointers);
                items.Add(GaugePointers);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType59.Hidden);
                items.Add(Hidden);
            }
            if (Interval != null)
            {
                itemsElementName.Add(ItemsChoiceType59.Interval);
                items.Add(Interval);
            }
            if (IntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType59.IntervalOffset);
                items.Add(IntervalOffset);
            }
            if (Logarithmic != null)
            {
                itemsElementName.Add(ItemsChoiceType59.Logarithmic);
                items.Add(Logarithmic);
            }
            if (LogarithmicBase != null)
            {
                itemsElementName.Add(ItemsChoiceType59.LogarithmicBase);
                items.Add(LogarithmicBase);
            }
            if (MaximumPin != null)
            {
                itemsElementName.Add(ItemsChoiceType59.MaximumPin);
                items.Add(MaximumPin);
            }
            if (MaximumValue != null)
            {
                itemsElementName.Add(ItemsChoiceType59.MaximumValue);
                items.Add(MaximumValue);
            }
            if (MinimumPin != null)
            {
                itemsElementName.Add(ItemsChoiceType59.MinimumPin);
                items.Add(MinimumPin);
            }
            if (MinimumValue != null)
            {
                itemsElementName.Add(ItemsChoiceType59.MinimumValue);
                items.Add(MinimumValue);
            }
            if (Multiplier != null)
            {
                itemsElementName.Add(ItemsChoiceType59.Multiplier);
                items.Add(Multiplier);
            }
            if (Position != null)
            {
                itemsElementName.Add(ItemsChoiceType59.Position);
                items.Add(Position);
            }
            if (Reversed != null)
            {
                itemsElementName.Add(ItemsChoiceType59.Reversed);
                items.Add(Reversed);
            }
            if (ScaleLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType59.ScaleLabels);
                items.Add(ScaleLabels);
            }
            if (ScaleRanges != null)
            {
                itemsElementName.Add(ItemsChoiceType59.ScaleRanges);
                items.Add(ScaleRanges);
            }
            if (StartMargin != null)
            {
                itemsElementName.Add(ItemsChoiceType59.StartMargin);
                items.Add(StartMargin);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType59.Style);
                items.Add(Style);
            }
            if (TickMarksOnTop != null)
            {
                itemsElementName.Add(ItemsChoiceType59.TickMarksOnTop);
                items.Add(TickMarksOnTop);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType59.ToolTip);
                items.Add(ToolTip);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType59.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType59[])itemsElementName.ToArray(typeof(ItemsChoiceType59));
            return type;
        }
    }



    public class CustomLabel
    {
        public string AllowUpsideDown;
        public string DistanceFromScale;
        public string FontAngle;
        public string Hidden;
        public string Placement;
        public string RotateLabel;
        public StyleType Style;
        public string Text;
        public TickMarkStyleType TickMarkStyle;
        public string UseFontPercent;
        public string Value;
        public CustomLabelType Create(string name)
        {
            CustomLabelType type = new CustomLabelType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AllowUpsideDown != null)
            {
                itemsElementName.Add(ItemsChoiceType48.AllowUpsideDown);
                items.Add(AllowUpsideDown);
            }
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType48.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (FontAngle != null)
            {
                itemsElementName.Add(ItemsChoiceType48.FontAngle);
                items.Add(FontAngle);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType48.Hidden);
                items.Add(Hidden);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType48.Placement);
                items.Add(Placement);
            }
            if (RotateLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType48.RotateLabel);
                items.Add(RotateLabel);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType48.Style);
                items.Add(Style);
            }
            if (Text != null)
            {
                itemsElementName.Add(ItemsChoiceType48.Text);
                items.Add(Text);
            }
            if (TickMarkStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType48.TickMarkStyle);
                items.Add(TickMarkStyle);
            }
            if (UseFontPercent != null)
            {
                itemsElementName.Add(ItemsChoiceType48.UseFontPercent);
                items.Add(UseFontPercent);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType48.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType48[])itemsElementName.ToArray(typeof(ItemsChoiceType48));
            return type;
        }
    }

    public class TickMarkStyle
    {
        public string DistanceFromScale;
        public string EnableGradient;
        public string GradientDensity;
        public string Hidden;
        public string Length;
        public string Placement;
        public string Shape;
        public StyleType Style;
        public TopImageType TickMarkImage;
        public string Width;
        public TickMarkStyleType Create()
        {
            TickMarkStyleType type = new TickMarkStyleType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType47.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (EnableGradient != null)
            {
                itemsElementName.Add(ItemsChoiceType47.EnableGradient);
                items.Add(EnableGradient);
            }
            if (GradientDensity != null)
            {
                itemsElementName.Add(ItemsChoiceType47.GradientDensity);
                items.Add(GradientDensity);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType47.Hidden);
                items.Add(Hidden);
            }
            if (Length != null)
            {
                itemsElementName.Add(ItemsChoiceType47.Length);
                items.Add(Length);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType47.Placement);
                items.Add(Placement);
            }
            if (Shape != null)
            {
                itemsElementName.Add(ItemsChoiceType47.Shape);
                items.Add(Shape);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType47.Style);
                items.Add(Style);
            }
            if (TickMarkImage != null)
            {
                itemsElementName.Add(ItemsChoiceType47.TickMarkImage);
                items.Add(TickMarkImage);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType47.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType47[])itemsElementName.ToArray(typeof(ItemsChoiceType47));
            return type;
        }
    }

    public class TopImage
    {
        public string HueColor;
        public string MIMEType;
        public string Source;
        public string TransparentColor;
        public string Value;
        public TopImageType Create()
        {
            TopImageType type = new TopImageType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (HueColor != null)
            {
                itemsElementName.Add(ItemsChoiceType42.HueColor);
                items.Add(HueColor);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType42.MIMEType);
                items.Add(MIMEType);
            }
            if (Source != null)
            {
                itemsElementName.Add(ItemsChoiceType42.Source);
                items.Add(Source);
            }
            if (TransparentColor != null)
            {
                itemsElementName.Add(ItemsChoiceType42.TransparentColor);
                items.Add(TransparentColor);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType42.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType42[])itemsElementName.ToArray(typeof(ItemsChoiceType42));
            return type;
        }
    }

    public class GaugeTickMarks
    {
        public string DistanceFromScale;
        public string EnableGradient;
        public string GradientDensity;
        public string Hidden;
        public string Interval;
        public string IntervalOffset;
        public string Length;
        public string Placement;
        public string Shape;
        public StyleType Style;
        public TopImageType TickMarkImage;
        public string Width;
        public GaugeTickMarksType Create()
        {
            GaugeTickMarksType type = new GaugeTickMarksType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType46.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (EnableGradient != null)
            {
                itemsElementName.Add(ItemsChoiceType46.EnableGradient);
                items.Add(EnableGradient);
            }
            if (GradientDensity != null)
            {
                itemsElementName.Add(ItemsChoiceType46.GradientDensity);
                items.Add(GradientDensity);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType46.Hidden);
                items.Add(Hidden);
            }
            if (Interval != null)
            {
                itemsElementName.Add(ItemsChoiceType46.Interval);
                items.Add(Interval);
            }
            if (IntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType46.IntervalOffset);
                items.Add(IntervalOffset);
            }
            if (Length != null)
            {
                itemsElementName.Add(ItemsChoiceType46.Length);
                items.Add(Length);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType46.Placement);
                items.Add(Placement);
            }
            if (Shape != null)
            {
                itemsElementName.Add(ItemsChoiceType46.Shape);
                items.Add(Shape);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType46.Style);
                items.Add(Style);
            }
            if (TickMarkImage != null)
            {
                itemsElementName.Add(ItemsChoiceType46.TickMarkImage);
                items.Add(TickMarkImage);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType46.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType46[])itemsElementName.ToArray(typeof(ItemsChoiceType46));
            return type;
        }
    }



    public class LinearPointer
    {
        public ActionInfoType ActionInfo;
        public string BarStart;
        public string DistanceFromScale;
        public GaugeInputValueType GaugeInputValue;
        public string Hidden;
        public string MarkerLength;
        public string MarkerStyle;
        public string Placement;
        public PointerImageType PointerImage;
        public string SnappingEnabled;
        public string SnappingInterval;
        public StyleType Style;
        public ThermometerType Thermometer;
        public string ToolTip;
        public string Type;
        public string Width;
        public LinearPointerType Create(string name)
        {
            LinearPointerType type = new LinearPointerType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType58.ActionInfo);
                items.Add(ActionInfo);
            }
            if (BarStart != null)
            {
                itemsElementName.Add(ItemsChoiceType58.BarStart);
                items.Add(BarStart);
            }
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType58.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (GaugeInputValue != null)
            {
                itemsElementName.Add(ItemsChoiceType58.GaugeInputValue);
                items.Add(GaugeInputValue);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType58.Hidden);
                items.Add(Hidden);
            }
            if (MarkerLength != null)
            {
                itemsElementName.Add(ItemsChoiceType58.MarkerLength);
                items.Add(MarkerLength);
            }
            if (MarkerStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType58.MarkerStyle);
                items.Add(MarkerStyle);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType58.Placement);
                items.Add(Placement);
            }
            if (PointerImage != null)
            {
                itemsElementName.Add(ItemsChoiceType58.PointerImage);
                items.Add(PointerImage);
            }
            if (SnappingEnabled != null)
            {
                itemsElementName.Add(ItemsChoiceType58.SnappingEnabled);
                items.Add(SnappingEnabled);
            }
            if (SnappingInterval != null)
            {
                itemsElementName.Add(ItemsChoiceType58.SnappingInterval);
                items.Add(SnappingInterval);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType58.Style);
                items.Add(Style);
            }
            if (Thermometer != null)
            {
                itemsElementName.Add(ItemsChoiceType58.Thermometer);
                items.Add(Thermometer);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType58.ToolTip);
                items.Add(ToolTip);
            }
            if (Type != null)
            {
                itemsElementName.Add(ItemsChoiceType58.Type);
                items.Add(Type);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType58.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType58[])itemsElementName.ToArray(typeof(ItemsChoiceType58));
            return type;
        }
    }

    public class GaugeInputValue
    {
        public string AddConstant;
        public string DataElementName;
        public GaugeInputValueTypeDataElementOutput? DataElementOutput;
        public string Formula;
        public string MaxPercent;
        public string MinPercent;
        public string Multiplier;
        public string Value;
        public GaugeInputValueType Create()
        {
            GaugeInputValueType type = new GaugeInputValueType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AddConstant != null)
            {
                itemsElementName.Add(ItemsChoiceType43.AddConstant);
                items.Add(AddConstant);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType43.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType43.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (Formula != null)
            {
                itemsElementName.Add(ItemsChoiceType43.Formula);
                items.Add(Formula);
            }
            if (MaxPercent != null)
            {
                itemsElementName.Add(ItemsChoiceType43.MaxPercent);
                items.Add(MaxPercent);
            }
            if (MinPercent != null)
            {
                itemsElementName.Add(ItemsChoiceType43.MinPercent);
                items.Add(MinPercent);
            }
            if (Multiplier != null)
            {
                itemsElementName.Add(ItemsChoiceType43.Multiplier);
                items.Add(Multiplier);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType43.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType43[])itemsElementName.ToArray(typeof(ItemsChoiceType43));
            return type;
        }
    }

    public class PointerImage
    {
        public string HueColor;
        public string MIMEType;
        public string OffsetX;
        public string OffsetY;
        public string Source;
        public string Transparency;
        public string TransparentColor;
        public string Value;
        public PointerImageType Create()
        {
            PointerImageType type = new PointerImageType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (HueColor != null)
            {
                itemsElementName.Add(ItemsChoiceType51.HueColor);
                items.Add(HueColor);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType51.MIMEType);
                items.Add(MIMEType);
            }
            if (OffsetX != null)
            {
                itemsElementName.Add(ItemsChoiceType51.OffsetX);
                items.Add(OffsetX);
            }
            if (OffsetY != null)
            {
                itemsElementName.Add(ItemsChoiceType51.OffsetY);
                items.Add(OffsetY);
            }
            if (Source != null)
            {
                itemsElementName.Add(ItemsChoiceType51.Source);
                items.Add(Source);
            }
            if (Transparency != null)
            {
                itemsElementName.Add(ItemsChoiceType51.Transparency);
                items.Add(Transparency);
            }
            if (TransparentColor != null)
            {
                itemsElementName.Add(ItemsChoiceType51.TransparentColor);
                items.Add(TransparentColor);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType51.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType51[])itemsElementName.ToArray(typeof(ItemsChoiceType51));
            return type;
        }
    }

    public class Thermometer
    {
        public string BulbOffset;
        public string BulbSize;
        public StyleType Style;
        public string ThermometerStyle;
        public ThermometerType Create()
        {
            ThermometerType type = new ThermometerType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (BulbOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType57.BulbOffset);
                items.Add(BulbOffset);
            }
            if (BulbSize != null)
            {
                itemsElementName.Add(ItemsChoiceType57.BulbSize);
                items.Add(BulbSize);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType57.Style);
                items.Add(Style);
            }
            if (ThermometerStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType57.ThermometerStyle);
                items.Add(ThermometerStyle);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType57[])itemsElementName.ToArray(typeof(ItemsChoiceType57));
            return type;
        }
    }

    public class ScalePin
    {
        public string DistanceFromScale;
        public string Enable;
        public string EnableGradient;
        public string GradientDensity;
        public string Hidden;
        public string Length;
        public string Location;
        public PinLabelType PinLabel;
        public string Placement;
        public string Shape;
        public StyleType Style;
        public TopImageType TickMarkImage;
        public string Width;
        public ScalePinType Create()
        {
            ScalePinType type = new ScalePinType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType50.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (Enable != null)
            {
                itemsElementName.Add(ItemsChoiceType50.Enable);
                items.Add(Enable);
            }
            if (EnableGradient != null)
            {
                itemsElementName.Add(ItemsChoiceType50.EnableGradient);
                items.Add(EnableGradient);
            }
            if (GradientDensity != null)
            {
                itemsElementName.Add(ItemsChoiceType50.GradientDensity);
                items.Add(GradientDensity);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType50.Hidden);
                items.Add(Hidden);
            }
            if (Length != null)
            {
                itemsElementName.Add(ItemsChoiceType50.Length);
                items.Add(Length);
            }
            if (Location != null)
            {
                itemsElementName.Add(ItemsChoiceType50.Location);
                items.Add(Location);
            }
            if (PinLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType50.PinLabel);
                items.Add(PinLabel);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType50.Placement);
                items.Add(Placement);
            }
            if (Shape != null)
            {
                itemsElementName.Add(ItemsChoiceType50.Shape);
                items.Add(Shape);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType50.Style);
                items.Add(Style);
            }
            if (TickMarkImage != null)
            {
                itemsElementName.Add(ItemsChoiceType50.TickMarkImage);
                items.Add(TickMarkImage);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType50.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType50[])itemsElementName.ToArray(typeof(ItemsChoiceType50));
            return type;
        }
    }

    public class PinLabel
    {
        public string AllowUpsideDown;
        public string DistanceFromScale;
        public string FontAngle;
        public string Placement;
        public string RotateLabel;
        public StyleType Style;
        public string Text;
        public string UseFontPercent;
        public PinLabelType Create()
        {
            PinLabelType type = new PinLabelType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AllowUpsideDown != null)
            {
                itemsElementName.Add(ItemsChoiceType49.AllowUpsideDown);
                items.Add(AllowUpsideDown);
            }
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType49.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (FontAngle != null)
            {
                itemsElementName.Add(ItemsChoiceType49.FontAngle);
                items.Add(FontAngle);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType49.Placement);
                items.Add(Placement);
            }
            if (RotateLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType49.RotateLabel);
                items.Add(RotateLabel);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType49.Style);
                items.Add(Style);
            }
            if (Text != null)
            {
                itemsElementName.Add(ItemsChoiceType49.Text);
                items.Add(Text);
            }
            if (UseFontPercent != null)
            {
                itemsElementName.Add(ItemsChoiceType49.UseFontPercent);
                items.Add(UseFontPercent);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType49[])itemsElementName.ToArray(typeof(ItemsChoiceType49));
            return type;
        }
    }

    public class ScaleLabels
    {
        public string AllowUpsideDown;
        public string DistanceFromScale;
        public string FontAngle;
        public string Hidden;
        public string Interval;
        public string IntervalOffset;
        public string Placement;
        public string RotateLabels;
        public string ShowEndLabels;
        public StyleType Style;
        public string UseFontPercent;
        public ScaleLabelsType Create()
        {
            ScaleLabelsType type = new ScaleLabelsType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AllowUpsideDown != null)
            {
                itemsElementName.Add(ItemsChoiceType45.AllowUpsideDown);
                items.Add(AllowUpsideDown);
            }
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType45.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (FontAngle != null)
            {
                itemsElementName.Add(ItemsChoiceType45.FontAngle);
                items.Add(FontAngle);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType45.Hidden);
                items.Add(Hidden);
            }
            if (Interval != null)
            {
                itemsElementName.Add(ItemsChoiceType45.Interval);
                items.Add(Interval);
            }
            if (IntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType45.IntervalOffset);
                items.Add(IntervalOffset);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType45.Placement);
                items.Add(Placement);
            }
            if (RotateLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType45.RotateLabels);
                items.Add(RotateLabels);
            }
            if (ShowEndLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType45.ShowEndLabels);
                items.Add(ShowEndLabels);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType45.Style);
                items.Add(Style);
            }
            if (UseFontPercent != null)
            {
                itemsElementName.Add(ItemsChoiceType45.UseFontPercent);
                items.Add(UseFontPercent);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType45[])itemsElementName.ToArray(typeof(ItemsChoiceType45));
            return type;
        }
    }



    public class ScaleRange
    {
        public ActionInfoType ActionInfo;
        public string BackgroundGradientType;
        public string DistanceFromScale;
        public GaugeInputValueType EndValue;
        public string EndWidth;
        public string Hidden;
        public string InRangeBarPointerColor;
        public string InRangeLabelColor;
        public string InRangeTickMarksColor;
        public string Placement;
        public GaugeInputValueType StartValue;
        public string StartWidth;
        public StyleType Style;
        public string ToolTip;
        public ScaleRangeType Create(string name)
        {
            ScaleRangeType type = new ScaleRangeType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType44.ActionInfo);
                items.Add(ActionInfo);
            }
            if (BackgroundGradientType != null)
            {
                itemsElementName.Add(ItemsChoiceType44.BackgroundGradientType);
                items.Add(BackgroundGradientType);
            }
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType44.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (EndValue != null)
            {
                itemsElementName.Add(ItemsChoiceType44.EndValue);
                items.Add(EndValue);
            }
            if (EndWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType44.EndWidth);
                items.Add(EndWidth);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType44.Hidden);
                items.Add(Hidden);
            }
            if (InRangeBarPointerColor != null)
            {
                itemsElementName.Add(ItemsChoiceType44.InRangeBarPointerColor);
                items.Add(InRangeBarPointerColor);
            }
            if (InRangeLabelColor != null)
            {
                itemsElementName.Add(ItemsChoiceType44.InRangeLabelColor);
                items.Add(InRangeLabelColor);
            }
            if (InRangeTickMarksColor != null)
            {
                itemsElementName.Add(ItemsChoiceType44.InRangeTickMarksColor);
                items.Add(InRangeTickMarksColor);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType44.Placement);
                items.Add(Placement);
            }
            if (StartValue != null)
            {
                itemsElementName.Add(ItemsChoiceType44.StartValue);
                items.Add(StartValue);
            }
            if (StartWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType44.StartWidth);
                items.Add(StartWidth);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType44.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType44.ToolTip);
                items.Add(ToolTip);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType44[])itemsElementName.ToArray(typeof(ItemsChoiceType44));
            return type;
        }
    }



    public class NumericIndicator
    {
        public ActionInfoType ActionInfo;
        public string DecimalDigitColor;
        public string DecimalDigits;
        public string DigitColor;
        public string Digits;
        public GaugeInputValueType GaugeInputValue;
        public string Height;
        public string Hidden;
        public string IndicatorStyle;
        public string LedDimColor;
        public string Left;
        public GaugeInputValueType MaximumValue;
        public GaugeInputValueType MinimumValue;
        public string Multiplier;
        public NumericIndicatorRangesType NumericIndicatorRanges;
        public string OffString;
        public string OutOfRangeString;
        public string ParentItem;
        public string ResizeMode;
        public string SeparatorColor;
        public string SeparatorWidth;
        public string ShowDecimalPoint;
        public string ShowLeadingZeros;
        public string ShowSign;
        public string SnappingEnabled;
        public string SnappingInterval;
        public StyleType Style;
        public string ToolTip;
        public string Top;
        public string UseFontPercent;
        public string Width;
        public string ZIndex;
        public NumericIndicatorType Create(string name)
        {
            NumericIndicatorType type = new NumericIndicatorType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType62.ActionInfo);
                items.Add(ActionInfo);
            }
            if (DecimalDigitColor != null)
            {
                itemsElementName.Add(ItemsChoiceType62.DecimalDigitColor);
                items.Add(DecimalDigitColor);
            }
            if (DecimalDigits != null)
            {
                itemsElementName.Add(ItemsChoiceType62.DecimalDigits);
                items.Add(DecimalDigits);
            }
            if (DigitColor != null)
            {
                itemsElementName.Add(ItemsChoiceType62.DigitColor);
                items.Add(DigitColor);
            }
            if (Digits != null)
            {
                itemsElementName.Add(ItemsChoiceType62.Digits);
                items.Add(Digits);
            }
            if (GaugeInputValue != null)
            {
                itemsElementName.Add(ItemsChoiceType62.GaugeInputValue);
                items.Add(GaugeInputValue);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType62.Height);
                items.Add(Height);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType62.Hidden);
                items.Add(Hidden);
            }
            if (IndicatorStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType62.IndicatorStyle);
                items.Add(IndicatorStyle);
            }
            if (LedDimColor != null)
            {
                itemsElementName.Add(ItemsChoiceType62.LedDimColor);
                items.Add(LedDimColor);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType62.Left);
                items.Add(Left);
            }
            if (MaximumValue != null)
            {
                itemsElementName.Add(ItemsChoiceType62.MaximumValue);
                items.Add(MaximumValue);
            }
            if (MinimumValue != null)
            {
                itemsElementName.Add(ItemsChoiceType62.MinimumValue);
                items.Add(MinimumValue);
            }
            if (Multiplier != null)
            {
                itemsElementName.Add(ItemsChoiceType62.Multiplier);
                items.Add(Multiplier);
            }
            if (NumericIndicatorRanges != null)
            {
                itemsElementName.Add(ItemsChoiceType62.NumericIndicatorRanges);
                items.Add(NumericIndicatorRanges);
            }
            if (OffString != null)
            {
                itemsElementName.Add(ItemsChoiceType62.OffString);
                items.Add(OffString);
            }
            if (OutOfRangeString != null)
            {
                itemsElementName.Add(ItemsChoiceType62.OutOfRangeString);
                items.Add(OutOfRangeString);
            }
            if (ParentItem != null)
            {
                itemsElementName.Add(ItemsChoiceType62.ParentItem);
                items.Add(ParentItem);
            }
            if (ResizeMode != null)
            {
                itemsElementName.Add(ItemsChoiceType62.ResizeMode);
                items.Add(ResizeMode);
            }
            if (SeparatorColor != null)
            {
                itemsElementName.Add(ItemsChoiceType62.SeparatorColor);
                items.Add(SeparatorColor);
            }
            if (SeparatorWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType62.SeparatorWidth);
                items.Add(SeparatorWidth);
            }
            if (ShowDecimalPoint != null)
            {
                itemsElementName.Add(ItemsChoiceType62.ShowDecimalPoint);
                items.Add(ShowDecimalPoint);
            }
            if (ShowLeadingZeros != null)
            {
                itemsElementName.Add(ItemsChoiceType62.ShowLeadingZeros);
                items.Add(ShowLeadingZeros);
            }
            if (ShowSign != null)
            {
                itemsElementName.Add(ItemsChoiceType62.ShowSign);
                items.Add(ShowSign);
            }
            if (SnappingEnabled != null)
            {
                itemsElementName.Add(ItemsChoiceType62.SnappingEnabled);
                items.Add(SnappingEnabled);
            }
            if (SnappingInterval != null)
            {
                itemsElementName.Add(ItemsChoiceType62.SnappingInterval);
                items.Add(SnappingInterval);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType62.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType62.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType62.Top);
                items.Add(Top);
            }
            if (UseFontPercent != null)
            {
                itemsElementName.Add(ItemsChoiceType62.UseFontPercent);
                items.Add(UseFontPercent);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType62.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType62.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType62[])itemsElementName.ToArray(typeof(ItemsChoiceType62));
            return type;
        }
    }



    public class NumericIndicatorRange
    {
        public string DecimalDigitColor;
        public string DigitColor;
        public GaugeInputValueType EndValue;
        public GaugeInputValueType StartValue;
        public NumericIndicatorRangeType Create(string name)
        {
            NumericIndicatorRangeType type = new NumericIndicatorRangeType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (DecimalDigitColor != null)
            {
                itemsElementName.Add(ItemsChoiceType61.DecimalDigitColor);
                items.Add(DecimalDigitColor);
            }
            if (DigitColor != null)
            {
                itemsElementName.Add(ItemsChoiceType61.DigitColor);
                items.Add(DigitColor);
            }
            if (EndValue != null)
            {
                itemsElementName.Add(ItemsChoiceType61.EndValue);
                items.Add(EndValue);
            }
            if (StartValue != null)
            {
                itemsElementName.Add(ItemsChoiceType61.StartValue);
                items.Add(StartValue);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType61[])itemsElementName.ToArray(typeof(ItemsChoiceType61));
            return type;
        }
    }



    public class RadialGauge
    {
        public ActionInfoType ActionInfo;
        public string AspectRatio;
        public BackFrameType BackFrame;
        public string ClipContent;
        public RadialScalesType GaugeScales;
        public string Height;
        public string Hidden;
        public string Left;
        public string ParentItem;
        public string PivotX;
        public string PivotY;
        public string ToolTip;
        public string Top;
        public TopImageType TopImage;
        public string Width;
        public string ZIndex;
        public RadialGaugeType Create(string name)
        {
            RadialGaugeType type = new RadialGaugeType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType56.ActionInfo);
                items.Add(ActionInfo);
            }
            if (AspectRatio != null)
            {
                itemsElementName.Add(ItemsChoiceType56.AspectRatio);
                items.Add(AspectRatio);
            }
            if (BackFrame != null)
            {
                itemsElementName.Add(ItemsChoiceType56.BackFrame);
                items.Add(BackFrame);
            }
            if (ClipContent != null)
            {
                itemsElementName.Add(ItemsChoiceType56.ClipContent);
                items.Add(ClipContent);
            }
            if (GaugeScales != null)
            {
                itemsElementName.Add(ItemsChoiceType56.GaugeScales);
                items.Add(GaugeScales);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType56.Height);
                items.Add(Height);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType56.Hidden);
                items.Add(Hidden);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType56.Left);
                items.Add(Left);
            }
            if (ParentItem != null)
            {
                itemsElementName.Add(ItemsChoiceType56.ParentItem);
                items.Add(ParentItem);
            }
            if (PivotX != null)
            {
                itemsElementName.Add(ItemsChoiceType56.PivotX);
                items.Add(PivotX);
            }
            if (PivotY != null)
            {
                itemsElementName.Add(ItemsChoiceType56.PivotY);
                items.Add(PivotY);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType56.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType56.Top);
                items.Add(Top);
            }
            if (TopImage != null)
            {
                itemsElementName.Add(ItemsChoiceType56.TopImage);
                items.Add(TopImage);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType56.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType56.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType56[])itemsElementName.ToArray(typeof(ItemsChoiceType56));
            return type;
        }
    }



    public class RadialScale
    {
        public ActionInfoType ActionInfo;
        public CustomLabelsType CustomLabels;
        public GaugeTickMarksType GaugeMajorTickMarks;
        public GaugeTickMarksType GaugeMinorTickMarks;
        public RadialPointersType GaugePointers;
        public string Hidden;
        public string Interval;
        public string IntervalOffset;
        public string Logarithmic;
        public string LogarithmicBase;
        public ScalePinType MaximumPin;
        public GaugeInputValueType MaximumValue;
        public ScalePinType MinimumPin;
        public GaugeInputValueType MinimumValue;
        public string Multiplier;
        public string Radius;
        public string Reversed;
        public ScaleLabelsType ScaleLabels;
        public ScaleRangesType ScaleRanges;
        public string StartAngle;
        public StyleType Style;
        public string SweepAngle;
        public string TickMarksOnTop;
        public string ToolTip;
        public string Width;
        public RadialScaleType Create(string name)
        {
            RadialScaleType type = new RadialScaleType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType55.ActionInfo);
                items.Add(ActionInfo);
            }
            if (CustomLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType55.CustomLabels);
                items.Add(CustomLabels);
            }
            if (GaugeMajorTickMarks != null)
            {
                itemsElementName.Add(ItemsChoiceType55.GaugeMajorTickMarks);
                items.Add(GaugeMajorTickMarks);
            }
            if (GaugeMinorTickMarks != null)
            {
                itemsElementName.Add(ItemsChoiceType55.GaugeMinorTickMarks);
                items.Add(GaugeMinorTickMarks);
            }
            if (GaugePointers != null)
            {
                itemsElementName.Add(ItemsChoiceType55.GaugePointers);
                items.Add(GaugePointers);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType55.Hidden);
                items.Add(Hidden);
            }
            if (Interval != null)
            {
                itemsElementName.Add(ItemsChoiceType55.Interval);
                items.Add(Interval);
            }
            if (IntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType55.IntervalOffset);
                items.Add(IntervalOffset);
            }
            if (Logarithmic != null)
            {
                itemsElementName.Add(ItemsChoiceType55.Logarithmic);
                items.Add(Logarithmic);
            }
            if (LogarithmicBase != null)
            {
                itemsElementName.Add(ItemsChoiceType55.LogarithmicBase);
                items.Add(LogarithmicBase);
            }
            if (MaximumPin != null)
            {
                itemsElementName.Add(ItemsChoiceType55.MaximumPin);
                items.Add(MaximumPin);
            }
            if (MaximumValue != null)
            {
                itemsElementName.Add(ItemsChoiceType55.MaximumValue);
                items.Add(MaximumValue);
            }
            if (MinimumPin != null)
            {
                itemsElementName.Add(ItemsChoiceType55.MinimumPin);
                items.Add(MinimumPin);
            }
            if (MinimumValue != null)
            {
                itemsElementName.Add(ItemsChoiceType55.MinimumValue);
                items.Add(MinimumValue);
            }
            if (Multiplier != null)
            {
                itemsElementName.Add(ItemsChoiceType55.Multiplier);
                items.Add(Multiplier);
            }
            if (Radius != null)
            {
                itemsElementName.Add(ItemsChoiceType55.Radius);
                items.Add(Radius);
            }
            if (Reversed != null)
            {
                itemsElementName.Add(ItemsChoiceType55.Reversed);
                items.Add(Reversed);
            }
            if (ScaleLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType55.ScaleLabels);
                items.Add(ScaleLabels);
            }
            if (ScaleRanges != null)
            {
                itemsElementName.Add(ItemsChoiceType55.ScaleRanges);
                items.Add(ScaleRanges);
            }
            if (StartAngle != null)
            {
                itemsElementName.Add(ItemsChoiceType55.StartAngle);
                items.Add(StartAngle);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType55.Style);
                items.Add(Style);
            }
            if (SweepAngle != null)
            {
                itemsElementName.Add(ItemsChoiceType55.SweepAngle);
                items.Add(SweepAngle);
            }
            if (TickMarksOnTop != null)
            {
                itemsElementName.Add(ItemsChoiceType55.TickMarksOnTop);
                items.Add(TickMarksOnTop);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType55.ToolTip);
                items.Add(ToolTip);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType55.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType55[])itemsElementName.ToArray(typeof(ItemsChoiceType55));
            return type;
        }
    }



    public class RadialPointer
    {
        public ActionInfoType ActionInfo;
        public string BarStart;
        public string DistanceFromScale;
        public GaugeInputValueType GaugeInputValue;
        public string Hidden;
        public string MarkerLength;
        public string MarkerStyle;
        public string NeedleStyle;
        public string Placement;
        public PointerCapType PointerCap;
        public PointerImageType PointerImage;
        public string SnappingEnabled;
        public string SnappingInterval;
        public StyleType Style;
        public string ToolTip;
        public string Type;
        public string Width;
        public RadialPointerType Create(string name)
        {
            RadialPointerType type = new RadialPointerType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType54.ActionInfo);
                items.Add(ActionInfo);
            }
            if (BarStart != null)
            {
                itemsElementName.Add(ItemsChoiceType54.BarStart);
                items.Add(BarStart);
            }
            if (DistanceFromScale != null)
            {
                itemsElementName.Add(ItemsChoiceType54.DistanceFromScale);
                items.Add(DistanceFromScale);
            }
            if (GaugeInputValue != null)
            {
                itemsElementName.Add(ItemsChoiceType54.GaugeInputValue);
                items.Add(GaugeInputValue);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType54.Hidden);
                items.Add(Hidden);
            }
            if (MarkerLength != null)
            {
                itemsElementName.Add(ItemsChoiceType54.MarkerLength);
                items.Add(MarkerLength);
            }
            if (MarkerStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType54.MarkerStyle);
                items.Add(MarkerStyle);
            }
            if (NeedleStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType54.NeedleStyle);
                items.Add(NeedleStyle);
            }
            if (Placement != null)
            {
                itemsElementName.Add(ItemsChoiceType54.Placement);
                items.Add(Placement);
            }
            if (PointerCap != null)
            {
                itemsElementName.Add(ItemsChoiceType54.PointerCap);
                items.Add(PointerCap);
            }
            if (PointerImage != null)
            {
                itemsElementName.Add(ItemsChoiceType54.PointerImage);
                items.Add(PointerImage);
            }
            if (SnappingEnabled != null)
            {
                itemsElementName.Add(ItemsChoiceType54.SnappingEnabled);
                items.Add(SnappingEnabled);
            }
            if (SnappingInterval != null)
            {
                itemsElementName.Add(ItemsChoiceType54.SnappingInterval);
                items.Add(SnappingInterval);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType54.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType54.ToolTip);
                items.Add(ToolTip);
            }
            if (Type != null)
            {
                itemsElementName.Add(ItemsChoiceType54.Type);
                items.Add(Type);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType54.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType54[])itemsElementName.ToArray(typeof(ItemsChoiceType54));
            return type;
        }
    }

    public class PointerCap
    {
        public CapImageType CapImage;
        public string CapStyle;
        public string Hidden;
        public string OnTop;
        public string Reflection;
        public StyleType Style;
        public string Width;
        public PointerCapType Create()
        {
            PointerCapType type = new PointerCapType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (CapImage != null)
            {
                itemsElementName.Add(ItemsChoiceType53.CapImage);
                items.Add(CapImage);
            }
            if (CapStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType53.CapStyle);
                items.Add(CapStyle);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType53.Hidden);
                items.Add(Hidden);
            }
            if (OnTop != null)
            {
                itemsElementName.Add(ItemsChoiceType53.OnTop);
                items.Add(OnTop);
            }
            if (Reflection != null)
            {
                itemsElementName.Add(ItemsChoiceType53.Reflection);
                items.Add(Reflection);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType53.Style);
                items.Add(Style);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType53.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType53[])itemsElementName.ToArray(typeof(ItemsChoiceType53));
            return type;
        }
    }

    public class CapImage
    {
        public string HueColor;
        public string MIMEType;
        public string OffsetX;
        public string OffsetY;
        public string Source;
        public string TransparentColor;
        public string Value;
        public CapImageType Create()
        {
            CapImageType type = new CapImageType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (HueColor != null)
            {
                itemsElementName.Add(ItemsChoiceType52.HueColor);
                items.Add(HueColor);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType52.MIMEType);
                items.Add(MIMEType);
            }
            if (OffsetX != null)
            {
                itemsElementName.Add(ItemsChoiceType52.OffsetX);
                items.Add(OffsetX);
            }
            if (OffsetY != null)
            {
                itemsElementName.Add(ItemsChoiceType52.OffsetY);
                items.Add(OffsetY);
            }
            if (Source != null)
            {
                itemsElementName.Add(ItemsChoiceType52.Source);
                items.Add(Source);
            }
            if (TransparentColor != null)
            {
                itemsElementName.Add(ItemsChoiceType52.TransparentColor);
                items.Add(TransparentColor);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType52.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType52[])itemsElementName.ToArray(typeof(ItemsChoiceType52));
            return type;
        }
    }



    public class StateIndicator
    {
        public ActionInfoType ActionInfo;
        public string Angle;
        public GaugeInputValueType GaugeInputValue;
        public string Height;
        public string Hidden;
        public IndicatorStatesType IndicatorStates;
        public string IndicatorStyle;
        public string Left;
        public string ParentItem;
        public string ResizeMode;
        public StateImageType StateImage;
        public StyleType Style;
        public string Text;
        public string ToolTip;
        public string Top;
        public string UseFontPercent;
        public string Width;
        public string ZIndex;
        public StateIndicatorType Create(string name)
        {
            StateIndicatorType type = new StateIndicatorType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType65.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Angle != null)
            {
                itemsElementName.Add(ItemsChoiceType65.Angle);
                items.Add(Angle);
            }
            if (GaugeInputValue != null)
            {
                itemsElementName.Add(ItemsChoiceType65.GaugeInputValue);
                items.Add(GaugeInputValue);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType65.Height);
                items.Add(Height);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType65.Hidden);
                items.Add(Hidden);
            }
            if (IndicatorStates != null)
            {
                itemsElementName.Add(ItemsChoiceType65.IndicatorStates);
                items.Add(IndicatorStates);
            }
            if (IndicatorStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType65.IndicatorStyle);
                items.Add(IndicatorStyle);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType65.Left);
                items.Add(Left);
            }
            if (ParentItem != null)
            {
                itemsElementName.Add(ItemsChoiceType65.ParentItem);
                items.Add(ParentItem);
            }
            if (ResizeMode != null)
            {
                itemsElementName.Add(ItemsChoiceType65.ResizeMode);
                items.Add(ResizeMode);
            }
            if (StateImage != null)
            {
                itemsElementName.Add(ItemsChoiceType65.StateImage);
                items.Add(StateImage);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType65.Style);
                items.Add(Style);
            }
            if (Text != null)
            {
                itemsElementName.Add(ItemsChoiceType65.Text);
                items.Add(Text);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType65.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType65.Top);
                items.Add(Top);
            }
            if (UseFontPercent != null)
            {
                itemsElementName.Add(ItemsChoiceType65.UseFontPercent);
                items.Add(UseFontPercent);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType65.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType65.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType65[])itemsElementName.ToArray(typeof(ItemsChoiceType65));
            return type;
        }
    }



    public class IndicatorState
    {
        public GaugeInputValueType EndValue;
        public GaugeInputValueType StartValue;
        public StateImageType StateImage;
        public StyleType Style;
        public string Text;
        public IndicatorStateType Create(string name)
        {
            IndicatorStateType type = new IndicatorStateType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (EndValue != null)
            {
                itemsElementName.Add(ItemsChoiceType64.EndValue);
                items.Add(EndValue);
            }
            if (StartValue != null)
            {
                itemsElementName.Add(ItemsChoiceType64.StartValue);
                items.Add(StartValue);
            }
            if (StateImage != null)
            {
                itemsElementName.Add(ItemsChoiceType64.StateImage);
                items.Add(StateImage);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType64.Style);
                items.Add(Style);
            }
            if (Text != null)
            {
                itemsElementName.Add(ItemsChoiceType64.Text);
                items.Add(Text);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType64[])itemsElementName.ToArray(typeof(ItemsChoiceType64));
            return type;
        }
    }

    public class StateImage
    {
        public string HueColor;
        public string MIMEType;
        public string Source;
        public string Transparency;
        public string TransparentColor;
        public string Value;
        public StateImageType Create()
        {
            StateImageType type = new StateImageType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (HueColor != null)
            {
                itemsElementName.Add(ItemsChoiceType63.HueColor);
                items.Add(HueColor);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType63.MIMEType);
                items.Add(MIMEType);
            }
            if (Source != null)
            {
                itemsElementName.Add(ItemsChoiceType63.Source);
                items.Add(Source);
            }
            if (Transparency != null)
            {
                itemsElementName.Add(ItemsChoiceType63.Transparency);
                items.Add(Transparency);
            }
            if (TransparentColor != null)
            {
                itemsElementName.Add(ItemsChoiceType63.TransparentColor);
                items.Add(TransparentColor);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType63.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType63[])itemsElementName.ToArray(typeof(ItemsChoiceType63));
            return type;
        }
    }

    public class Image
    {
        public ActionInfoType ActionInfo;
        public string Bookmark;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public ImageTypeDataElementOutput? DataElementOutput;
        public StringLocIDType DocumentMapLabel;
        public string Height;
        public string Left;
        public string MIMEType;
        public string RepeatWith;
        public ImageTypeSizing? Sizing;
        public ImageTypeSource? Source;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public string Top;
        public string Value;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public ImageType Create(string name)
        {
            ImageType type = new ImageType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType15.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Bookmark);
                items.Add(Bookmark);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType15.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType15.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType15.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType15.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Height);
                items.Add(Height);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Left);
                items.Add(Left);
            }
            if (MIMEType != null)
            {
                itemsElementName.Add(ItemsChoiceType15.MIMEType);
                items.Add(MIMEType);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType15.RepeatWith);
                items.Add(RepeatWith);
            }
            if (Sizing != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Sizing);
                items.Add(Sizing);
            }
            if (Source != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Source);
                items.Add(Source);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType15.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Top);
                items.Add(Top);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Value);
                items.Add(Value);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Visibility);
                items.Add(Visibility);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType15.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType15.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType15[])itemsElementName.ToArray(typeof(ItemsChoiceType15));
            return type;
        }
    }

    public class Line
    {
        public ActionInfoType ActionInfo;
        public string Bookmark;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public LineTypeDataElementOutput? DataElementOutput;
        public StringLocIDType DocumentMapLabel;
        public string Height;
        public string Left;
        public string RepeatWith;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public string Top;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public LineType Create(string name)
        {
            LineType type = new LineType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType9.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType9.Bookmark);
                items.Add(Bookmark);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType9.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType9.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType9.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType9.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType9.Height);
                items.Add(Height);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType9.Left);
                items.Add(Left);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType9.RepeatWith);
                items.Add(RepeatWith);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType9.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType9.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType9.Top);
                items.Add(Top);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType9.Visibility);
                items.Add(Visibility);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType9.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType9.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType9[])itemsElementName.ToArray(typeof(ItemsChoiceType9));
            return type;
        }
    }

    public class Rectangle
    {
        public ActionInfoType ActionInfo;
        public string Bookmark;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public RectangleTypeDataElementOutput? DataElementOutput;
        public StringLocIDType DocumentMapLabel;
        public string Height;
        public bool? KeepTogether;
        public string Left;
        public string LinkToChild;
        public bool? OmitBorderOnPageBreak;
        public PageBreakType PageBreak;
        public string RepeatWith;
        public ReportItemsType ReportItems;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public string Top;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public RectangleType Create(string name)
        {
            RectangleType type = new RectangleType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType10.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType10.Bookmark);
                items.Add(Bookmark);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType10.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType10.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType10.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType10.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType10.Height);
                items.Add(Height);
            }
            if (KeepTogether != null)
            {
                itemsElementName.Add(ItemsChoiceType10.KeepTogether);
                items.Add(KeepTogether);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType10.Left);
                items.Add(Left);
            }
            if (LinkToChild != null)
            {
                itemsElementName.Add(ItemsChoiceType10.LinkToChild);
                items.Add(LinkToChild);
            }
            if (OmitBorderOnPageBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType10.OmitBorderOnPageBreak);
                items.Add(OmitBorderOnPageBreak);
            }
            if (PageBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType10.PageBreak);
                items.Add(PageBreak);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType10.RepeatWith);
                items.Add(RepeatWith);
            }
            if (ReportItems != null)
            {
                itemsElementName.Add(ItemsChoiceType10.ReportItems);
                items.Add(ReportItems);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType10.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType10.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType10.Top);
                items.Add(Top);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType10.Visibility);
                items.Add(Visibility);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType10.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType10.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType10[])itemsElementName.ToArray(typeof(ItemsChoiceType10));
            return type;
        }
    }

    public class Subreport
    {
        public ActionInfoType ActionInfo;
        public string Bookmark;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public SubreportTypeDataElementOutput? DataElementOutput;
        public StringLocIDType DocumentMapLabel;
        public string Height;
        public bool? KeepTogether;
        public string Left;
        public bool? MergeTransactions;
        public string NoRowsMessage;
        public bool? OmitBorderOnPageBreak;
        public ParametersType Parameters;
        public string RepeatWith;
        public string ReportName;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public string Top;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public SubreportType Create(string name)
        {
            SubreportType type = new SubreportType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType16.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Bookmark != null)
            {
                itemsElementName.Add(ItemsChoiceType16.Bookmark);
                items.Add(Bookmark);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType16.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType16.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType16.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (DocumentMapLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType16.DocumentMapLabel);
                items.Add(DocumentMapLabel);
            }
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType16.Height);
                items.Add(Height);
            }
            if (KeepTogether != null)
            {
                itemsElementName.Add(ItemsChoiceType16.KeepTogether);
                items.Add(KeepTogether);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType16.Left);
                items.Add(Left);
            }
            if (MergeTransactions != null)
            {
                itemsElementName.Add(ItemsChoiceType16.MergeTransactions);
                items.Add(MergeTransactions);
            }
            if (NoRowsMessage != null)
            {
                itemsElementName.Add(ItemsChoiceType16.NoRowsMessage);
                items.Add(NoRowsMessage);
            }
            if (OmitBorderOnPageBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType16.OmitBorderOnPageBreak);
                items.Add(OmitBorderOnPageBreak);
            }
            if (Parameters != null)
            {
                itemsElementName.Add(ItemsChoiceType16.Parameters);
                items.Add(Parameters);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType16.RepeatWith);
                items.Add(RepeatWith);
            }
            if (ReportName != null)
            {
                itemsElementName.Add(ItemsChoiceType16.ReportName);
                items.Add(ReportName);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType16.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType16.ToolTip);
                items.Add(ToolTip);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType16.Top);
                items.Add(Top);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType16.Visibility);
                items.Add(Visibility);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType16.Width);
                items.Add(Width);
            }
            if (ZIndex != null)
            {
                itemsElementName.Add(ItemsChoiceType16.ZIndex);
                items.Add(ZIndex);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType16[])itemsElementName.ToArray(typeof(ItemsChoiceType16));
            return type;
        }
    }

    public class Tablix
    {
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
        public StyleType Style;
        public TablixBodyType TablixBody;
        public TablixHierarchyType TablixColumnHierarchy;
        public TablixCornerType TablixCorner;
        public TablixHierarchyType TablixRowHierarchy;
        public StringLocIDType ToolTip;
        public string Top;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public TablixType Create(string name)
        {
            TablixType type = new TablixType();
            type.Name = name;
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
                items.Add(Style);
            }
            if (TablixBody != null)
            {
                itemsElementName.Add(ItemsChoiceType73.TablixBody);
                items.Add(TablixBody);
            }
            if (TablixColumnHierarchy != null)
            {
                itemsElementName.Add(ItemsChoiceType73.TablixColumnHierarchy);
                items.Add(TablixColumnHierarchy);
            }
            if (TablixCorner != null)
            {
                itemsElementName.Add(ItemsChoiceType73.TablixCorner);
                items.Add(TablixCorner);
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

    public class TablixBody
    {
        public TablixColumnsType[] TablixColumns;
        public TablixRowsType[] TablixRows;
        public TablixBodyType Create()
        {
            TablixBodyType type = new TablixBodyType();
            ArrayList items = new ArrayList();
            if (TablixColumns != null)
            {
                items.AddRange(TablixColumns);
            }
            if (TablixRows != null)
            {
                items.AddRange(TablixRows);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixColumns
    {
        public TablixColumnType[] TablixColumn;
        public TablixColumnsType Create()
        {
            TablixColumnsType type = new TablixColumnsType();
            ArrayList items = new ArrayList();
            if (TablixColumn != null)
            {
                items.AddRange(TablixColumn);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixColumn
    {
        //jrt,原来是数组
        public string Width;
        public TablixColumnType Create()
        {
            TablixColumnType type = new TablixColumnType();
            ArrayList items = new ArrayList();
            if (Width != null)
            {
                items.AddRange(new string[]{Width});
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixRows
    {
        public TablixRowType[] TablixRow;
        public TablixRowsType Create()
        {
            TablixRowsType type = new TablixRowsType();
            ArrayList items = new ArrayList();
            if (TablixRow != null)
            {
                items.AddRange(TablixRow);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixRow
    {
        public string Height;
        public TablixCellsType TablixCells;
        public TablixRowType Create()
        {
            TablixRowType type = new TablixRowType();
            ArrayList items = new ArrayList();
            if (Height != null)
            {
                items.Add(Height);
            }
            if (TablixCells != null)
            {
                items.Add(TablixCells);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class TablixCells : ICreator<TablixCellsType>
    {
        public TablixCellType[] TablixCell;
        public TablixCellsType Create()
        {
            TablixCellsType type = new TablixCellsType();
            ArrayList items = new ArrayList();
            if (TablixCell != null)
            {
                items.AddRange(TablixCell);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixCell : ICreator<TablixCellType>
    {
        public bool HasSetValue = false;
        public bool IsEmpty = true;
        public CellContentsType CellContents;
        public string DataElementName;
        public TablixCellTypeDataElementOutput DataElementOutput;
        public TablixCellType Create()
        {
            TablixCellType type = new TablixCellType();
            ArrayList items = new ArrayList();
            if (CellContents != null)
            {
                items.Add(CellContents);
            }
            if (DataElementName != null)
            {
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                items.Add(DataElementOutput);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixHierarchy
    {
        public TablixMembersType[] TablixMembers;
        public TablixHierarchyType Create()
        {
            TablixHierarchyType type = new TablixHierarchyType();
            ArrayList items = new ArrayList();
            if (TablixMembers != null)
            {
                items.AddRange(TablixMembers);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class TablixMember
    {
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public TablixMemberTypeDataElementOutput? DataElementOutput;
        public bool? FixedData;
        public GroupType Group;
        public bool? HideIfNoRows;
        public bool? KeepTogether;
        public TablixMemberTypeKeepWithGroup? KeepWithGroup;
        public bool? RepeatOnNewPage;
        public SortExpressionsType SortExpressions;
        public TablixHeaderType TablixHeader;
        public TablixMembersType TablixMembers;
        public VisibilityType Visibility;
        public TablixMemberType Create()
        {
            TablixMemberType type = new TablixMemberType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType72.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType72.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType72.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (FixedData != null)
            {
                itemsElementName.Add(ItemsChoiceType72.FixedData);
                items.Add(FixedData);
            }
            if (Group != null)
            {
                itemsElementName.Add(ItemsChoiceType72.Group);
                items.Add(Group);
            }
            if (HideIfNoRows != null)
            {
                itemsElementName.Add(ItemsChoiceType72.HideIfNoRows);
                items.Add(HideIfNoRows);
            }
            if (KeepTogether != null)
            {
                itemsElementName.Add(ItemsChoiceType72.KeepTogether);
                items.Add(KeepTogether);
            }
            if (KeepWithGroup != null)
            {
                itemsElementName.Add(ItemsChoiceType72.KeepWithGroup);
                items.Add(KeepWithGroup);
            }
            if (RepeatOnNewPage != null)
            {
                itemsElementName.Add(ItemsChoiceType72.RepeatOnNewPage);
                items.Add(RepeatOnNewPage);
            }
            if (SortExpressions != null)
            {
                itemsElementName.Add(ItemsChoiceType72.SortExpressions);
                items.Add(SortExpressions);
            }
            if (TablixHeader != null)
            {
                itemsElementName.Add(ItemsChoiceType72.TablixHeader);
                items.Add(TablixHeader);
            }
            if (TablixMembers != null)
            {
                itemsElementName.Add(ItemsChoiceType72.TablixMembers);
                items.Add(TablixMembers);
            }
            if (Visibility != null)
            {
                itemsElementName.Add(ItemsChoiceType72.Visibility);
                items.Add(Visibility);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType72[])itemsElementName.ToArray(typeof(ItemsChoiceType72));
            return type;
        }
    }

    public class TablixCorner
    {
        public TablixCornerRowsType[] TablixCornerRows;
        public TablixCornerType Create()
        {
            TablixCornerType type = new TablixCornerType();
            ArrayList items = new ArrayList();
            if (TablixCornerRows != null)
            {
                items.AddRange(TablixCornerRows);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixCornerRows
    {
        public TablixCornerRowType[] TablixCornerRow;
        public TablixCornerRowsType Create()
        {
            TablixCornerRowsType type = new TablixCornerRowsType();
            ArrayList items = new ArrayList();
            if (TablixCornerRow != null)
            {
                items.AddRange(TablixCornerRow);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixCornerRow
    {
        public TablixCornerCellType[] TablixCornerCell;
        public TablixCornerRowType Create()
        {
            TablixCornerRowType type = new TablixCornerRowType();
            ArrayList items = new ArrayList();
            if (TablixCornerCell != null)
            {
                items.AddRange(TablixCornerCell);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class TablixCornerCell
    {
        public bool HasSetValue = false;
        public bool ShouldEmpty=true;
        public CellContentsEx CellContents;
        //public CellContentsType[] CellContents;
        public TablixCornerCellType Create()
        {
            TablixCornerCellType type = new TablixCornerCellType();
            ArrayList items = new ArrayList();
            if (CellContents != null)
            {
                items.Add(CellContents.Create());
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class Textbox
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
        public ParagraphsType Paragraphs;
        public string RepeatWith;
        public StyleType Style;
        public ToggleImageType ToggleImage;
        public StringLocIDType ToolTip;
        public string Top;
        public UserSortType UserSort;
        public VisibilityType Visibility;
        public string Width;
        public uint? ZIndex;
        public TextboxType Create(string name)
        {
            TextboxType type = new TextboxType();
            type.Name = name;
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
            if (Paragraphs != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Paragraphs);
                items.Add(Paragraphs);
            }
            if (RepeatWith != null)
            {
                itemsElementName.Add(ItemsChoiceType14.RepeatWith);
                items.Add(RepeatWith);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType14.Style);
                items.Add(Style);
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
                items.Add(Visibility);
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



    public class Paragraph
    {
        public string HangingIndent;
        public string LeftIndent;
        public uint? ListLevel;
        public ParagraphTypeListStyle? ListStyle;
        public string RightIndent;
        public string SpaceAfter;
        public string SpaceBefore;
        public StyleType Style;
        public TextRunsType TextRuns;
        public ParagraphType Create()
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
                items.Add(Style);
            }
            if (TextRuns != null)
            {
                itemsElementName.Add(ItemsChoiceType12.TextRuns);
                items.Add(TextRuns);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType12[])itemsElementName.ToArray(typeof(ItemsChoiceType12));
            return type;
        }
    }



    public class TextRun
    {
        public ActionInfoType ActionInfo;
        public string Label;
        public string MarkupType;
        public StyleType Style;
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
                items.Add(Style);
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

    public class ToggleImage
    {
        public string[] InitialState;
        public ToggleImageType Create()
        {
            ToggleImageType type = new ToggleImageType();
            ArrayList items = new ArrayList();
            if (InitialState != null)
            {
                items.AddRange(InitialState);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class UserSort
    {
        public string SortExpression;
        public string SortExpressionScope;
        public string SortTarget;
        public UserSortType Create()
        {
            UserSortType type = new UserSortType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (SortExpression != null)
            {
                itemsElementName.Add(ItemsChoiceType13.SortExpression);
                items.Add(SortExpression);
            }
            if (SortExpressionScope != null)
            {
                itemsElementName.Add(ItemsChoiceType13.SortExpressionScope);
                items.Add(SortExpressionScope);
            }
            if (SortTarget != null)
            {
                itemsElementName.Add(ItemsChoiceType13.SortTarget);
                items.Add(SortTarget);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType13[])itemsElementName.ToArray(typeof(ItemsChoiceType13));
            return type;
        }
    }



    public class ChartCodeParameter
    {
        public string[] Value;
        public ChartCodeParameterType Create(string name)
        {
            ChartCodeParameterType type = new ChartCodeParameterType();
            type.Name = name;
            ArrayList items = new ArrayList();
            if (Value != null)
            {
                items.AddRange(Value);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class ChartBorderSkin
    {
        public string[] ChartBorderSkinType;
        public StyleType[] Style;
        public ChartBorderSkinType Create()
        {
            ChartBorderSkinType type = new ChartBorderSkinType();
            ArrayList items = new ArrayList();
            if (ChartBorderSkinType != null)
            {
                items.AddRange(ChartBorderSkinType);
            }
            if (Style != null)
            {
                items.AddRange(Style);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class ChartTitle
    {
        public ActionInfoType ActionInfo;
        public StringLocIDType Caption;
        public ChartElementPositionType ChartElementPosition;
        public string DockOffset;
        public string DockOutsideChartArea;
        public string DockToChartArea;
        public string Hidden;
        public string Position;
        public StyleType Style;
        public string TextOrientation;
        public StringLocIDType ToolTip;
        public ChartTitleType Create(string name)
        {
            ChartTitleType type = new ChartTitleType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType38.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Caption != null)
            {
                itemsElementName.Add(ItemsChoiceType38.Caption);
                items.Add(Caption);
            }
            if (ChartElementPosition != null)
            {
                itemsElementName.Add(ItemsChoiceType38.ChartElementPosition);
                items.Add(ChartElementPosition);
            }
            if (DockOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType38.DockOffset);
                items.Add(DockOffset);
            }
            if (DockOutsideChartArea != null)
            {
                itemsElementName.Add(ItemsChoiceType38.DockOutsideChartArea);
                items.Add(DockOutsideChartArea);
            }
            if (DockToChartArea != null)
            {
                itemsElementName.Add(ItemsChoiceType38.DockToChartArea);
                items.Add(DockToChartArea);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType38.Hidden);
                items.Add(Hidden);
            }
            if (Position != null)
            {
                itemsElementName.Add(ItemsChoiceType38.Position);
                items.Add(Position);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType38.Style);
                items.Add(Style);
            }
            if (TextOrientation != null)
            {
                itemsElementName.Add(ItemsChoiceType38.TextOrientation);
                items.Add(TextOrientation);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType38.ToolTip);
                items.Add(ToolTip);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType38[])itemsElementName.ToArray(typeof(ItemsChoiceType38));
            return type;
        }
    }

    public class ChartElementPosition
    {
        public string Height;
        public string Left;
        public string Top;
        public string Width;
        public ChartElementPositionType Create()
        {
            ChartElementPositionType type = new ChartElementPositionType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Height != null)
            {
                itemsElementName.Add(ItemsChoiceType34.Height);
                items.Add(Height);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType34.Left);
                items.Add(Left);
            }
            if (Top != null)
            {
                itemsElementName.Add(ItemsChoiceType34.Top);
                items.Add(Top);
            }
            if (Width != null)
            {
                itemsElementName.Add(ItemsChoiceType34.Width);
                items.Add(Width);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType34[])itemsElementName.ToArray(typeof(ItemsChoiceType34));
            return type;
        }
    }



    public class ChartLegendColumn
    {
        public ActionInfoType ActionInfo;
        public ChartLegendColumnTypeColumnType? ColumnType;
        public string MaximumWidth;
        public string MinimumWidth;
        public string SeriesSymbolHeight;
        public string SeriesSymbolWidth;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public string Value;
        public ChartLegendColumnType Create(string name)
        {
            ChartLegendColumnType type = new ChartLegendColumnType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType36.ActionInfo);
                items.Add(ActionInfo);
            }
            if (ColumnType != null)
            {
                itemsElementName.Add(ItemsChoiceType36.ColumnType);
                items.Add(ColumnType);
            }
            if (MaximumWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType36.MaximumWidth);
                items.Add(MaximumWidth);
            }
            if (MinimumWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType36.MinimumWidth);
                items.Add(MinimumWidth);
            }
            if (SeriesSymbolHeight != null)
            {
                itemsElementName.Add(ItemsChoiceType36.SeriesSymbolHeight);
                items.Add(SeriesSymbolHeight);
            }
            if (SeriesSymbolWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType36.SeriesSymbolWidth);
                items.Add(SeriesSymbolWidth);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType36.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType36.ToolTip);
                items.Add(ToolTip);
            }
            if (Value != null)
            {
                itemsElementName.Add(ItemsChoiceType36.Value);
                items.Add(Value);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType36[])itemsElementName.ToArray(typeof(ItemsChoiceType36));
            return type;
        }
    }



    public class ChartLegendTitle
    {
        public StringLocIDType[] Caption;
        public StyleType[] Style;
        public string[] TitleSeparator;
        public ChartLegendTitleType Create()
        {
            ChartLegendTitleType type = new ChartLegendTitleType();
            ArrayList items = new ArrayList();
            if (Caption != null)
            {
                items.AddRange(Caption);
            }
            if (Style != null)
            {
                items.AddRange(Style);
            }
            if (TitleSeparator != null)
            {
                items.AddRange(TitleSeparator);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class ChartLegend
    {
        public string AutoFitTextDisabled;
        public ChartElementPositionType ChartElementPosition;
        public ChartLegendColumnsType ChartLegendColumns;
        public ChartLegendTitleType ChartLegendTitle;
        public string ColumnSeparator;
        public string ColumnSeparatorColor;
        public string ColumnSpacing;
        public string DockOutsideChartArea;
        public string DockToChartArea;
        public string EquallySpacedItems;
        public string HeaderSeparator;
        public string HeaderSeparatorColor;
        public string Hidden;
        public string InterlacedRows;
        public string InterlacedRowsColor;
        public string Layout;
        public string MaxAutoSize;
        public string MinFontSize;
        public string Position;
        public string Reversed;
        public StyleType Style;
        public string TextWrapThreshold;
        public ChartLegendType Create(string name)
        {
            ChartLegendType type = new ChartLegendType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AutoFitTextDisabled != null)
            {
                itemsElementName.Add(ItemsChoiceType37.AutoFitTextDisabled);
                items.Add(AutoFitTextDisabled);
            }
            if (ChartElementPosition != null)
            {
                itemsElementName.Add(ItemsChoiceType37.ChartElementPosition);
                items.Add(ChartElementPosition);
            }
            if (ChartLegendColumns != null)
            {
                itemsElementName.Add(ItemsChoiceType37.ChartLegendColumns);
                items.Add(ChartLegendColumns);
            }
            if (ChartLegendTitle != null)
            {
                itemsElementName.Add(ItemsChoiceType37.ChartLegendTitle);
                items.Add(ChartLegendTitle);
            }
            if (ColumnSeparator != null)
            {
                itemsElementName.Add(ItemsChoiceType37.ColumnSeparator);
                items.Add(ColumnSeparator);
            }
            if (ColumnSeparatorColor != null)
            {
                itemsElementName.Add(ItemsChoiceType37.ColumnSeparatorColor);
                items.Add(ColumnSeparatorColor);
            }
            if (ColumnSpacing != null)
            {
                itemsElementName.Add(ItemsChoiceType37.ColumnSpacing);
                items.Add(ColumnSpacing);
            }
            if (DockOutsideChartArea != null)
            {
                itemsElementName.Add(ItemsChoiceType37.DockOutsideChartArea);
                items.Add(DockOutsideChartArea);
            }
            if (DockToChartArea != null)
            {
                itemsElementName.Add(ItemsChoiceType37.DockToChartArea);
                items.Add(DockToChartArea);
            }
            if (EquallySpacedItems != null)
            {
                itemsElementName.Add(ItemsChoiceType37.EquallySpacedItems);
                items.Add(EquallySpacedItems);
            }
            if (HeaderSeparator != null)
            {
                itemsElementName.Add(ItemsChoiceType37.HeaderSeparator);
                items.Add(HeaderSeparator);
            }
            if (HeaderSeparatorColor != null)
            {
                itemsElementName.Add(ItemsChoiceType37.HeaderSeparatorColor);
                items.Add(HeaderSeparatorColor);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType37.Hidden);
                items.Add(Hidden);
            }
            if (InterlacedRows != null)
            {
                itemsElementName.Add(ItemsChoiceType37.InterlacedRows);
                items.Add(InterlacedRows);
            }
            if (InterlacedRowsColor != null)
            {
                itemsElementName.Add(ItemsChoiceType37.InterlacedRowsColor);
                items.Add(InterlacedRowsColor);
            }
            if (Layout != null)
            {
                itemsElementName.Add(ItemsChoiceType37.Layout);
                items.Add(Layout);
            }
            if (MaxAutoSize != null)
            {
                itemsElementName.Add(ItemsChoiceType37.MaxAutoSize);
                items.Add(MaxAutoSize);
            }
            if (MinFontSize != null)
            {
                itemsElementName.Add(ItemsChoiceType37.MinFontSize);
                items.Add(MinFontSize);
            }
            if (Position != null)
            {
                itemsElementName.Add(ItemsChoiceType37.Position);
                items.Add(Position);
            }
            if (Reversed != null)
            {
                itemsElementName.Add(ItemsChoiceType37.Reversed);
                items.Add(Reversed);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType37.Style);
                items.Add(Style);
            }
            if (TextWrapThreshold != null)
            {
                itemsElementName.Add(ItemsChoiceType37.TextWrapThreshold);
                items.Add(TextWrapThreshold);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType37[])itemsElementName.ToArray(typeof(ItemsChoiceType37));
            return type;
        }
    }



    public class ChartAlignType
    {
        public string AxesView;
        public string Cursor;
        public string InnerPlotPosition;
        public string Position;
        public ChartAlignTypeType Create()
        {
            ChartAlignTypeType type = new ChartAlignTypeType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AxesView != null)
            {
                itemsElementName.Add(ItemsChoiceType33.AxesView);
                items.Add(AxesView);
            }
            if (Cursor != null)
            {
                itemsElementName.Add(ItemsChoiceType33.Cursor);
                items.Add(Cursor);
            }
            if (InnerPlotPosition != null)
            {
                itemsElementName.Add(ItemsChoiceType33.InnerPlotPosition);
                items.Add(InnerPlotPosition);
            }
            if (Position != null)
            {
                itemsElementName.Add(ItemsChoiceType33.Position);
                items.Add(Position);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType33[])itemsElementName.ToArray(typeof(ItemsChoiceType33));
            return type;
        }
    }

    public class ChartThreeDProperties
    {
        public string Clustered;
        public string DepthRatio;
        public string Enabled;
        public string GapDepth;
        public string Inclination;
        public string Perspective;
        public string ProjectionMode;
        public string Rotation;
        public string Shading;
        public string WallThickness;
        public ChartThreeDPropertiesType Create()
        {
            ChartThreeDPropertiesType type = new ChartThreeDPropertiesType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Clustered != null)
            {
                itemsElementName.Add(ItemsChoiceType32.Clustered);
                items.Add(Clustered);
            }
            if (DepthRatio != null)
            {
                itemsElementName.Add(ItemsChoiceType32.DepthRatio);
                items.Add(DepthRatio);
            }
            if (Enabled != null)
            {
                itemsElementName.Add(ItemsChoiceType32.Enabled);
                items.Add(Enabled);
            }
            if (GapDepth != null)
            {
                itemsElementName.Add(ItemsChoiceType32.GapDepth);
                items.Add(GapDepth);
            }
            if (Inclination != null)
            {
                itemsElementName.Add(ItemsChoiceType32.Inclination);
                items.Add(Inclination);
            }
            if (Perspective != null)
            {
                itemsElementName.Add(ItemsChoiceType32.Perspective);
                items.Add(Perspective);
            }
            if (ProjectionMode != null)
            {
                itemsElementName.Add(ItemsChoiceType32.ProjectionMode);
                items.Add(ProjectionMode);
            }
            if (Rotation != null)
            {
                itemsElementName.Add(ItemsChoiceType32.Rotation);
                items.Add(Rotation);
            }
            if (Shading != null)
            {
                itemsElementName.Add(ItemsChoiceType32.Shading);
                items.Add(Shading);
            }
            if (WallThickness != null)
            {
                itemsElementName.Add(ItemsChoiceType32.WallThickness);
                items.Add(WallThickness);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType32[])itemsElementName.ToArray(typeof(ItemsChoiceType32));
            return type;
        }
    }

    public class ChartValueAxes
    {
        public ChartAxisType[] ChartAxis;
        public ChartValueAxesType Create()
        {
            ChartValueAxesType type = new ChartValueAxesType();
            ArrayList items = new ArrayList();
            if (ChartAxis != null)
            {
                items.AddRange(ChartAxis);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class ChartAxis
    {
        public string AllowLabelRotation;
        public string Angle;
        public string Arrows;
        public ChartAxisScaleBreakType ChartAxisScaleBreak;
        public ChartAxisTitleType ChartAxisTitle;
        public ChartGridLinesType ChartMajorGridLines;
        public ChartTickMarksType ChartMajorTickMarks;
        public ChartGridLinesType ChartMinorGridLines;
        public ChartTickMarksType ChartMinorTickMarks;
        public ChartStripLinesType ChartStripLines;
        public string CrossAt;
        public CustomPropertiesType CustomProperties;
        public string HideEndLabels;
        public string HideLabels;
        public string IncludeZero;
        public string Interlaced;
        public string InterlacedColor;
        public string Interval;
        public string IntervalOffset;
        public string IntervalOffsetType;
        public string IntervalType;
        public string LabelInterval;
        public string LabelIntervalOffset;
        public string LabelIntervalOffsetType;
        public string LabelIntervalType;
        public string LabelsAutoFitDisabled;
        public string Location;
        public string LogBase;
        public string LogScale;
        public string Margin;
        public string MarksAlwaysAtPlotEdge;
        public string MaxFontSize;
        public string Maximum;
        public string MinFontSize;
        public string Minimum;
        public string OffsetLabels;
        public string PreventFontGrow;
        public string PreventFontShrink;
        public string PreventLabelOffset;
        public string PreventWordWrap;
        public string Reverse;
        public bool? Scalar;
        public StyleType Style;
        public string VariableAutoInterval;
        public string Visible;
        public ChartAxisType Create(string name)
        {
            ChartAxisType type = new ChartAxisType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AllowLabelRotation != null)
            {
                itemsElementName.Add(ItemsChoiceType31.AllowLabelRotation);
                items.Add(AllowLabelRotation);
            }
            if (Angle != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Angle);
                items.Add(Angle);
            }
            if (Arrows != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Arrows);
                items.Add(Arrows);
            }
            if (ChartAxisScaleBreak != null)
            {
                itemsElementName.Add(ItemsChoiceType31.ChartAxisScaleBreak);
                items.Add(ChartAxisScaleBreak);
            }
            if (ChartAxisTitle != null)
            {
                itemsElementName.Add(ItemsChoiceType31.ChartAxisTitle);
                items.Add(ChartAxisTitle);
            }
            if (ChartMajorGridLines != null)
            {
                itemsElementName.Add(ItemsChoiceType31.ChartMajorGridLines);
                items.Add(ChartMajorGridLines);
            }
            if (ChartMajorTickMarks != null)
            {
                itemsElementName.Add(ItemsChoiceType31.ChartMajorTickMarks);
                items.Add(ChartMajorTickMarks);
            }
            if (ChartMinorGridLines != null)
            {
                itemsElementName.Add(ItemsChoiceType31.ChartMinorGridLines);
                items.Add(ChartMinorGridLines);
            }
            if (ChartMinorTickMarks != null)
            {
                itemsElementName.Add(ItemsChoiceType31.ChartMinorTickMarks);
                items.Add(ChartMinorTickMarks);
            }
            if (ChartStripLines != null)
            {
                itemsElementName.Add(ItemsChoiceType31.ChartStripLines);
                items.Add(ChartStripLines);
            }
            if (CrossAt != null)
            {
                itemsElementName.Add(ItemsChoiceType31.CrossAt);
                items.Add(CrossAt);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType31.CustomProperties);
                items.Add(CustomProperties);
            }
            if (HideEndLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType31.HideEndLabels);
                items.Add(HideEndLabels);
            }
            if (HideLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType31.HideLabels);
                items.Add(HideLabels);
            }
            if (IncludeZero != null)
            {
                itemsElementName.Add(ItemsChoiceType31.IncludeZero);
                items.Add(IncludeZero);
            }
            if (Interlaced != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Interlaced);
                items.Add(Interlaced);
            }
            if (InterlacedColor != null)
            {
                itemsElementName.Add(ItemsChoiceType31.InterlacedColor);
                items.Add(InterlacedColor);
            }
            if (Interval != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Interval);
                items.Add(Interval);
            }
            if (IntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType31.IntervalOffset);
                items.Add(IntervalOffset);
            }
            if (IntervalOffsetType != null)
            {
                itemsElementName.Add(ItemsChoiceType31.IntervalOffsetType);
                items.Add(IntervalOffsetType);
            }
            if (IntervalType != null)
            {
                itemsElementName.Add(ItemsChoiceType31.IntervalType);
                items.Add(IntervalType);
            }
            if (LabelInterval != null)
            {
                itemsElementName.Add(ItemsChoiceType31.LabelInterval);
                items.Add(LabelInterval);
            }
            if (LabelIntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType31.LabelIntervalOffset);
                items.Add(LabelIntervalOffset);
            }
            if (LabelIntervalOffsetType != null)
            {
                itemsElementName.Add(ItemsChoiceType31.LabelIntervalOffsetType);
                items.Add(LabelIntervalOffsetType);
            }
            if (LabelIntervalType != null)
            {
                itemsElementName.Add(ItemsChoiceType31.LabelIntervalType);
                items.Add(LabelIntervalType);
            }
            if (LabelsAutoFitDisabled != null)
            {
                itemsElementName.Add(ItemsChoiceType31.LabelsAutoFitDisabled);
                items.Add(LabelsAutoFitDisabled);
            }
            if (Location != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Location);
                items.Add(Location);
            }
            if (LogBase != null)
            {
                itemsElementName.Add(ItemsChoiceType31.LogBase);
                items.Add(LogBase);
            }
            if (LogScale != null)
            {
                itemsElementName.Add(ItemsChoiceType31.LogScale);
                items.Add(LogScale);
            }
            if (Margin != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Margin);
                items.Add(Margin);
            }
            if (MarksAlwaysAtPlotEdge != null)
            {
                itemsElementName.Add(ItemsChoiceType31.MarksAlwaysAtPlotEdge);
                items.Add(MarksAlwaysAtPlotEdge);
            }
            if (MaxFontSize != null)
            {
                itemsElementName.Add(ItemsChoiceType31.MaxFontSize);
                items.Add(MaxFontSize);
            }
            if (Maximum != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Maximum);
                items.Add(Maximum);
            }
            if (MinFontSize != null)
            {
                itemsElementName.Add(ItemsChoiceType31.MinFontSize);
                items.Add(MinFontSize);
            }
            if (Minimum != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Minimum);
                items.Add(Minimum);
            }
            if (OffsetLabels != null)
            {
                itemsElementName.Add(ItemsChoiceType31.OffsetLabels);
                items.Add(OffsetLabels);
            }
            if (PreventFontGrow != null)
            {
                itemsElementName.Add(ItemsChoiceType31.PreventFontGrow);
                items.Add(PreventFontGrow);
            }
            if (PreventFontShrink != null)
            {
                itemsElementName.Add(ItemsChoiceType31.PreventFontShrink);
                items.Add(PreventFontShrink);
            }
            if (PreventLabelOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType31.PreventLabelOffset);
                items.Add(PreventLabelOffset);
            }
            if (PreventWordWrap != null)
            {
                itemsElementName.Add(ItemsChoiceType31.PreventWordWrap);
                items.Add(PreventWordWrap);
            }
            if (Reverse != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Reverse);
                items.Add(Reverse);
            }
            if (Scalar != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Scalar);
                items.Add(Scalar);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Style);
                items.Add(Style);
            }
            if (VariableAutoInterval != null)
            {
                itemsElementName.Add(ItemsChoiceType31.VariableAutoInterval);
                items.Add(VariableAutoInterval);
            }
            if (Visible != null)
            {
                itemsElementName.Add(ItemsChoiceType31.Visible);
                items.Add(Visible);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType31[])itemsElementName.ToArray(typeof(ItemsChoiceType31));
            return type;
        }
    }

    public class ChartAxisScaleBreak
    {
        public string BreakLineType;
        public string CollapsibleSpaceThreshold;
        public string Enabled;
        public string IncludeZero;
        public string MaxNumberOfBreaks;
        public string Spacing;
        public StyleType Style;
        public ChartAxisScaleBreakType Create()
        {
            ChartAxisScaleBreakType type = new ChartAxisScaleBreakType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (BreakLineType != null)
            {
                itemsElementName.Add(ItemsChoiceType30.BreakLineType);
                items.Add(BreakLineType);
            }
            if (CollapsibleSpaceThreshold != null)
            {
                itemsElementName.Add(ItemsChoiceType30.CollapsibleSpaceThreshold);
                items.Add(CollapsibleSpaceThreshold);
            }
            if (Enabled != null)
            {
                itemsElementName.Add(ItemsChoiceType30.Enabled);
                items.Add(Enabled);
            }
            if (IncludeZero != null)
            {
                itemsElementName.Add(ItemsChoiceType30.IncludeZero);
                items.Add(IncludeZero);
            }
            if (MaxNumberOfBreaks != null)
            {
                itemsElementName.Add(ItemsChoiceType30.MaxNumberOfBreaks);
                items.Add(MaxNumberOfBreaks);
            }
            if (Spacing != null)
            {
                itemsElementName.Add(ItemsChoiceType30.Spacing);
                items.Add(Spacing);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType30.Style);
                items.Add(Style);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType30[])itemsElementName.ToArray(typeof(ItemsChoiceType30));
            return type;
        }
    }

    public class ChartAxisTitle
    {
        public StringLocIDType Caption;
        public string Position;
        public StyleType Style;
        public string TextOrientation;
        public ChartAxisTitleType Create()
        {
            ChartAxisTitleType type = new ChartAxisTitleType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Caption != null)
            {
                itemsElementName.Add(ItemsChoiceType26.Caption);
                items.Add(Caption);
            }
            if (Position != null)
            {
                itemsElementName.Add(ItemsChoiceType26.Position);
                items.Add(Position);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType26.Style);
                items.Add(Style);
            }
            if (TextOrientation != null)
            {
                itemsElementName.Add(ItemsChoiceType26.TextOrientation);
                items.Add(TextOrientation);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType26[])itemsElementName.ToArray(typeof(ItemsChoiceType26));
            return type;
        }
    }

    public class ChartGridLines
    {
        public string Enabled;
        public string Interval;
        public string IntervalOffset;
        public string IntervalOffsetType;
        public string IntervalType;
        public StyleType Style;
        public ChartGridLinesType Create()
        {
            ChartGridLinesType type = new ChartGridLinesType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Enabled != null)
            {
                itemsElementName.Add(ItemsChoiceType27.Enabled);
                items.Add(Enabled);
            }
            if (Interval != null)
            {
                itemsElementName.Add(ItemsChoiceType27.Interval);
                items.Add(Interval);
            }
            if (IntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType27.IntervalOffset);
                items.Add(IntervalOffset);
            }
            if (IntervalOffsetType != null)
            {
                itemsElementName.Add(ItemsChoiceType27.IntervalOffsetType);
                items.Add(IntervalOffsetType);
            }
            if (IntervalType != null)
            {
                itemsElementName.Add(ItemsChoiceType27.IntervalType);
                items.Add(IntervalType);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType27.Style);
                items.Add(Style);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType27[])itemsElementName.ToArray(typeof(ItemsChoiceType27));
            return type;
        }
    }

    public class ChartTickMarks
    {
        public string Enabled;
        public string Interval;
        public string IntervalOffset;
        public string IntervalOffsetType;
        public string IntervalType;
        public string Length;
        public StyleType Style;
        public string Type;
        public ChartTickMarksType Create()
        {
            ChartTickMarksType type = new ChartTickMarksType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Enabled != null)
            {
                itemsElementName.Add(ItemsChoiceType28.Enabled);
                items.Add(Enabled);
            }
            if (Interval != null)
            {
                itemsElementName.Add(ItemsChoiceType28.Interval);
                items.Add(Interval);
            }
            if (IntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType28.IntervalOffset);
                items.Add(IntervalOffset);
            }
            if (IntervalOffsetType != null)
            {
                itemsElementName.Add(ItemsChoiceType28.IntervalOffsetType);
                items.Add(IntervalOffsetType);
            }
            if (IntervalType != null)
            {
                itemsElementName.Add(ItemsChoiceType28.IntervalType);
                items.Add(IntervalType);
            }
            if (Length != null)
            {
                itemsElementName.Add(ItemsChoiceType28.Length);
                items.Add(Length);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType28.Style);
                items.Add(Style);
            }
            if (Type != null)
            {
                itemsElementName.Add(ItemsChoiceType28.Type);
                items.Add(Type);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType28[])itemsElementName.ToArray(typeof(ItemsChoiceType28));
            return type;
        }
    }



    public class ChartStripLine
    {
        public ActionInfoType ActionInfo;
        public string Interval;
        public string IntervalOffset;
        public string IntervalOffsetType;
        public string IntervalType;
        public string StripWidth;
        public string StripWidthType;
        public StyleType Style;
        public string TextOrientation;
        public string Title;
        public string TitleAngle;
        public StringLocIDType ToolTip;
        public ChartStripLineType Create()
        {
            ChartStripLineType type = new ChartStripLineType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType29.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Interval != null)
            {
                itemsElementName.Add(ItemsChoiceType29.Interval);
                items.Add(Interval);
            }
            if (IntervalOffset != null)
            {
                itemsElementName.Add(ItemsChoiceType29.IntervalOffset);
                items.Add(IntervalOffset);
            }
            if (IntervalOffsetType != null)
            {
                itemsElementName.Add(ItemsChoiceType29.IntervalOffsetType);
                items.Add(IntervalOffsetType);
            }
            if (IntervalType != null)
            {
                itemsElementName.Add(ItemsChoiceType29.IntervalType);
                items.Add(IntervalType);
            }
            if (StripWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType29.StripWidth);
                items.Add(StripWidth);
            }
            if (StripWidthType != null)
            {
                itemsElementName.Add(ItemsChoiceType29.StripWidthType);
                items.Add(StripWidthType);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType29.Style);
                items.Add(Style);
            }
            if (TextOrientation != null)
            {
                itemsElementName.Add(ItemsChoiceType29.TextOrientation);
                items.Add(TextOrientation);
            }
            if (Title != null)
            {
                itemsElementName.Add(ItemsChoiceType29.Title);
                items.Add(Title);
            }
            if (TitleAngle != null)
            {
                itemsElementName.Add(ItemsChoiceType29.TitleAngle);
                items.Add(TitleAngle);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType29.ToolTip);
                items.Add(ToolTip);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType29[])itemsElementName.ToArray(typeof(ItemsChoiceType29));
            return type;
        }
    }

    public class ChartCategoryAxes
    {
        public ChartAxisType[] ChartAxis;
        public ChartCategoryAxesType Create()
        {
            ChartCategoryAxesType type = new ChartCategoryAxesType();
            ArrayList items = new ArrayList();
            if (ChartAxis != null)
            {
                items.AddRange(ChartAxis);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class ChartArea
    {
        public string AlignOrientation;
        public string AlignWithChartArea;
        public ChartAlignTypeType ChartAlignType;
        public ChartCategoryAxesType ChartCategoryAxes;
        public ChartElementPositionType ChartElementPosition;
        public ChartElementPositionType ChartInnerPlotPosition;
        public ChartThreeDPropertiesType ChartThreeDProperties;
        public ChartValueAxesType ChartValueAxes;
        public string EquallySizedAxesFont;
        public string Hidden;
        public StyleType Style;
        public ChartAreaType Create(string name)
        {
            ChartAreaType type = new ChartAreaType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AlignOrientation != null)
            {
                itemsElementName.Add(ItemsChoiceType35.AlignOrientation);
                items.Add(AlignOrientation);
            }
            if (AlignWithChartArea != null)
            {
                itemsElementName.Add(ItemsChoiceType35.AlignWithChartArea);
                items.Add(AlignWithChartArea);
            }
            if (ChartAlignType != null)
            {
                itemsElementName.Add(ItemsChoiceType35.ChartAlignType);
                items.Add(ChartAlignType);
            }
            if (ChartCategoryAxes != null)
            {
                itemsElementName.Add(ItemsChoiceType35.ChartCategoryAxes);
                items.Add(ChartCategoryAxes);
            }
            if (ChartElementPosition != null)
            {
                itemsElementName.Add(ItemsChoiceType35.ChartElementPosition);
                items.Add(ChartElementPosition);
            }
            if (ChartInnerPlotPosition != null)
            {
                itemsElementName.Add(ItemsChoiceType35.ChartInnerPlotPosition);
                items.Add(ChartInnerPlotPosition);
            }
            if (ChartThreeDProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType35.ChartThreeDProperties);
                items.Add(ChartThreeDProperties);
            }
            if (ChartValueAxes != null)
            {
                itemsElementName.Add(ItemsChoiceType35.ChartValueAxes);
                items.Add(ChartValueAxes);
            }
            if (EquallySizedAxesFont != null)
            {
                itemsElementName.Add(ItemsChoiceType35.EquallySizedAxesFont);
                items.Add(EquallySizedAxesFont);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType35.Hidden);
                items.Add(Hidden);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType35.Style);
                items.Add(Style);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType35[])itemsElementName.ToArray(typeof(ItemsChoiceType35));
            return type;
        }
    }

    

    public class ChartDerivedSeries
    {
        public ChartFormulaParametersType[] ChartFormulaParameters;
        public ChartSeriesType[] ChartSeries;
        public ChartDerivedSeriesTypeDerivedSeriesFormula[] DerivedSeriesFormula;
        public string[] SourceChartSeriesName;
        public ChartDerivedSeriesType Create()
        {
            ChartDerivedSeriesType type = new ChartDerivedSeriesType();
            ArrayList items = new ArrayList();
            if (ChartFormulaParameters != null)
            {
                items.AddRange(ChartFormulaParameters);
            }
            if (ChartSeries != null)
            {
                items.AddRange(ChartSeries);
            }
            if (DerivedSeriesFormula != null)
            {
                items.AddRange(DerivedSeriesFormula);
            }
            if (SourceChartSeriesName != null)
            {
                items.AddRange(SourceChartSeriesName);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class ChartSeries
    {
        public string CategoryAxisName;
        public string ChartAreaName;
        public ChartDataLabelType ChartDataLabel;
        public ChartDataPointsType ChartDataPoints;
        public ChartEmptyPointsType ChartEmptyPoints;
        public ChartItemInLegendType ChartItemInLegend;
        public ChartMarkerType ChartMarker;
        public ChartSmartLabelType ChartSmartLabel;
        public CustomPropertiesType CustomProperties;
        public string Hidden;
        public string LegendName;
        public StyleType Style;
        public string Subtype;
        public string Type;
        public string ValueAxisName;
        public ChartSeriesType Create(string name)
        {
            ChartSeriesType type = new ChartSeriesType();
            type.Name = name;
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (CategoryAxisName != null)
            {
                itemsElementName.Add(ItemsChoiceType25.CategoryAxisName);
                items.Add(CategoryAxisName);
            }
            if (ChartAreaName != null)
            {
                itemsElementName.Add(ItemsChoiceType25.ChartAreaName);
                items.Add(ChartAreaName);
            }
            if (ChartDataLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType25.ChartDataLabel);
                items.Add(ChartDataLabel);
            }
            if (ChartDataPoints != null)
            {
                itemsElementName.Add(ItemsChoiceType25.ChartDataPoints);
                items.Add(ChartDataPoints);
            }
            if (ChartEmptyPoints != null)
            {
                itemsElementName.Add(ItemsChoiceType25.ChartEmptyPoints);
                items.Add(ChartEmptyPoints);
            }
            if (ChartItemInLegend != null)
            {
                itemsElementName.Add(ItemsChoiceType25.ChartItemInLegend);
                items.Add(ChartItemInLegend);
            }
            if (ChartMarker != null)
            {
                itemsElementName.Add(ItemsChoiceType25.ChartMarker);
                items.Add(ChartMarker);
            }
            if (ChartSmartLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType25.ChartSmartLabel);
                items.Add(ChartSmartLabel);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType25.CustomProperties);
                items.Add(CustomProperties);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType25.Hidden);
                items.Add(Hidden);
            }
            if (LegendName != null)
            {
                itemsElementName.Add(ItemsChoiceType25.LegendName);
                items.Add(LegendName);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType25.Style);
                items.Add(Style);
            }
            if (Subtype != null)
            {
                itemsElementName.Add(ItemsChoiceType25.Subtype);
                items.Add(Subtype);
            }
            if (Type != null)
            {
                itemsElementName.Add(ItemsChoiceType25.Type);
                items.Add(Type);
            }
            if (ValueAxisName != null)
            {
                itemsElementName.Add(ItemsChoiceType25.ValueAxisName);
                items.Add(ValueAxisName);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType25[])itemsElementName.ToArray(typeof(ItemsChoiceType25));
            return type;
        }
    }

    public class ChartDataLabel
    {
        public ActionInfoType ActionInfo;
        public StringLocIDType Label;
        public string Position;
        public string Rotation;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public string UseValueAsLabel;
        public string Visible;
        public ChartDataLabelType Create()
        {
            ChartDataLabelType type = new ChartDataLabelType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType19.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Label != null)
            {
                itemsElementName.Add(ItemsChoiceType19.Label);
                items.Add(Label);
            }
            if (Position != null)
            {
                itemsElementName.Add(ItemsChoiceType19.Position);
                items.Add(Position);
            }
            if (Rotation != null)
            {
                itemsElementName.Add(ItemsChoiceType19.Rotation);
                items.Add(Rotation);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType19.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType19.ToolTip);
                items.Add(ToolTip);
            }
            if (UseValueAsLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType19.UseValueAsLabel);
                items.Add(UseValueAsLabel);
            }
            if (Visible != null)
            {
                itemsElementName.Add(ItemsChoiceType19.Visible);
                items.Add(Visible);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType19[])itemsElementName.ToArray(typeof(ItemsChoiceType19));
            return type;
        }
    }



    public class ChartDataPoint
    {
        public ActionInfoType ActionInfo;
        public string AxisLabel;
        public ChartDataLabelType ChartDataLabel;
        public ChartDataPointValuesType ChartDataPointValues;
        public ChartItemInLegendType ChartItemInLegend;
        public ChartMarkerType ChartMarker;
        public CustomPropertiesType CustomProperties;
        public string DataElementName;
        public ChartDataPointTypeDataElementOutput? DataElementOutput;
        public StyleType Style;
        public StringLocIDType ToolTip;
        public ChartDataPointType Create()
        {
            ChartDataPointType type = new ChartDataPointType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType22.ActionInfo);
                items.Add(ActionInfo);
            }
            if (AxisLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType22.AxisLabel);
                items.Add(AxisLabel);
            }
            if (ChartDataLabel != null)
            {
                itemsElementName.Add(ItemsChoiceType22.ChartDataLabel);
                items.Add(ChartDataLabel);
            }
            if (ChartDataPointValues != null)
            {
                itemsElementName.Add(ItemsChoiceType22.ChartDataPointValues);
                items.Add(ChartDataPointValues);
            }
            if (ChartItemInLegend != null)
            {
                itemsElementName.Add(ItemsChoiceType22.ChartItemInLegend);
                items.Add(ChartItemInLegend);
            }
            if (ChartMarker != null)
            {
                itemsElementName.Add(ItemsChoiceType22.ChartMarker);
                items.Add(ChartMarker);
            }
            if (CustomProperties != null)
            {
                itemsElementName.Add(ItemsChoiceType22.CustomProperties);
                items.Add(CustomProperties);
            }
            if (DataElementName != null)
            {
                itemsElementName.Add(ItemsChoiceType22.DataElementName);
                items.Add(DataElementName);
            }
            if (DataElementOutput != null)
            {
                itemsElementName.Add(ItemsChoiceType22.DataElementOutput);
                items.Add(DataElementOutput);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType22.Style);
                items.Add(Style);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType22.ToolTip);
                items.Add(ToolTip);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType22[])itemsElementName.ToArray(typeof(ItemsChoiceType22));
            return type;
        }
    }

    public class ChartDataPointValues
    {
        public string End;
        public string High;
        public string Low;
        public string Mean;
        public string Median;
        public string Size;
        public string Start;
        public string X;
        public string Y;
        public ChartDataPointValuesType Create()
        {
            ChartDataPointValuesType type = new ChartDataPointValuesType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (End != null)
            {
                itemsElementName.Add(ItemsChoiceType18.End);
                items.Add(End);
            }
            if (High != null)
            {
                itemsElementName.Add(ItemsChoiceType18.High);
                items.Add(High);
            }
            if (Low != null)
            {
                itemsElementName.Add(ItemsChoiceType18.Low);
                items.Add(Low);
            }
            if (Mean != null)
            {
                itemsElementName.Add(ItemsChoiceType18.Mean);
                items.Add(Mean);
            }
            if (Median != null)
            {
                itemsElementName.Add(ItemsChoiceType18.Median);
                items.Add(Median);
            }
            if (Size != null)
            {
                itemsElementName.Add(ItemsChoiceType18.Size);
                items.Add(Size);
            }
            if (Start != null)
            {
                itemsElementName.Add(ItemsChoiceType18.Start);
                items.Add(Start);
            }
            if (X != null)
            {
                itemsElementName.Add(ItemsChoiceType18.X);
                items.Add(X);
            }
            if (Y != null)
            {
                itemsElementName.Add(ItemsChoiceType18.Y);
                items.Add(Y);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType18[])itemsElementName.ToArray(typeof(ItemsChoiceType18));
            return type;
        }
    }

    public class ChartItemInLegend
    {
        public ActionInfoType ActionInfo;
        public string Hidden;
        public string LegendText;
        public StringLocIDType ToolTip;
        public ChartItemInLegendType Create()
        {
            ChartItemInLegendType type = new ChartItemInLegendType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ActionInfo != null)
            {
                itemsElementName.Add(ItemsChoiceType21.ActionInfo);
                items.Add(ActionInfo);
            }
            if (Hidden != null)
            {
                itemsElementName.Add(ItemsChoiceType21.Hidden);
                items.Add(Hidden);
            }
            if (LegendText != null)
            {
                itemsElementName.Add(ItemsChoiceType21.LegendText);
                items.Add(LegendText);
            }
            if (ToolTip != null)
            {
                itemsElementName.Add(ItemsChoiceType21.ToolTip);
                items.Add(ToolTip);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType21[])itemsElementName.ToArray(typeof(ItemsChoiceType21));
            return type;
        }
    }

    public class ChartMarker
    {
        public string Size;
        public StyleType Style;
        public string Type;
        public ChartMarkerType Create()
        {
            ChartMarkerType type = new ChartMarkerType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Size != null)
            {
                itemsElementName.Add(ItemsChoiceType20.Size);
                items.Add(Size);
            }
            if (Style != null)
            {
                itemsElementName.Add(ItemsChoiceType20.Style);
                items.Add(Style);
            }
            if (Type != null)
            {
                itemsElementName.Add(ItemsChoiceType20.Type);
                items.Add(Type);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType20[])itemsElementName.ToArray(typeof(ItemsChoiceType20));
            return type;
        }
    }

    public class ChartEmptyPoints
    {
        public ActionInfoType[] ActionInfo;
        public string[] AxisLabel;
        public ChartDataLabelType[] ChartDataLabel;
        public ChartMarkerType[] ChartMarker;
        public CustomPropertiesType[] CustomProperties;
        public StyleType[] Style;
        public StringLocIDType[] ToolTip;
        public ChartEmptyPointsType Create()
        {
            ChartEmptyPointsType type = new ChartEmptyPointsType();
            ArrayList items = new ArrayList();
            if (ActionInfo != null)
            {
                items.AddRange(ActionInfo);
            }
            if (AxisLabel != null)
            {
                items.AddRange(AxisLabel);
            }
            if (ChartDataLabel != null)
            {
                items.AddRange(ChartDataLabel);
            }
            if (ChartMarker != null)
            {
                items.AddRange(ChartMarker);
            }
            if (CustomProperties != null)
            {
                items.AddRange(CustomProperties);
            }
            if (Style != null)
            {
                items.AddRange(Style);
            }
            if (ToolTip != null)
            {
                items.AddRange(ToolTip);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class ChartSmartLabel
    {
        public string AllowOutSidePlotArea;
        public string CalloutBackColor;
        public string CalloutLineAnchor;
        public string CalloutLineColor;
        public string CalloutLineStyle;
        public string CalloutLineWidth;
        public string CalloutStyle;
        public ChartNoMoveDirectionsType ChartNoMoveDirections;
        public string Disabled;
        public string MarkerOverlapping;
        public string MaxMovingDistance;
        public string MinMovingDistance;
        public string ShowOverlapped;
        public ChartSmartLabelType Create()
        {
            ChartSmartLabelType type = new ChartSmartLabelType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (AllowOutSidePlotArea != null)
            {
                itemsElementName.Add(ItemsChoiceType24.AllowOutSidePlotArea);
                items.Add(AllowOutSidePlotArea);
            }
            if (CalloutBackColor != null)
            {
                itemsElementName.Add(ItemsChoiceType24.CalloutBackColor);
                items.Add(CalloutBackColor);
            }
            if (CalloutLineAnchor != null)
            {
                itemsElementName.Add(ItemsChoiceType24.CalloutLineAnchor);
                items.Add(CalloutLineAnchor);
            }
            if (CalloutLineColor != null)
            {
                itemsElementName.Add(ItemsChoiceType24.CalloutLineColor);
                items.Add(CalloutLineColor);
            }
            if (CalloutLineStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType24.CalloutLineStyle);
                items.Add(CalloutLineStyle);
            }
            if (CalloutLineWidth != null)
            {
                itemsElementName.Add(ItemsChoiceType24.CalloutLineWidth);
                items.Add(CalloutLineWidth);
            }
            if (CalloutStyle != null)
            {
                itemsElementName.Add(ItemsChoiceType24.CalloutStyle);
                items.Add(CalloutStyle);
            }
            if (ChartNoMoveDirections != null)
            {
                itemsElementName.Add(ItemsChoiceType24.ChartNoMoveDirections);
                items.Add(ChartNoMoveDirections);
            }
            if (Disabled != null)
            {
                itemsElementName.Add(ItemsChoiceType24.Disabled);
                items.Add(Disabled);
            }
            if (MarkerOverlapping != null)
            {
                itemsElementName.Add(ItemsChoiceType24.MarkerOverlapping);
                items.Add(MarkerOverlapping);
            }
            if (MaxMovingDistance != null)
            {
                itemsElementName.Add(ItemsChoiceType24.MaxMovingDistance);
                items.Add(MaxMovingDistance);
            }
            if (MinMovingDistance != null)
            {
                itemsElementName.Add(ItemsChoiceType24.MinMovingDistance);
                items.Add(MinMovingDistance);
            }
            if (ShowOverlapped != null)
            {
                itemsElementName.Add(ItemsChoiceType24.ShowOverlapped);
                items.Add(ShowOverlapped);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType24[])itemsElementName.ToArray(typeof(ItemsChoiceType24));
            return type;
        }
    }

    public class ChartNoMoveDirections
    {
        public string Down;
        public string DownLeft;
        public string DownRight;
        public string Left;
        public string Right;
        public string Up;
        public string UpLeft;
        public string UpRight;
        public ChartNoMoveDirectionsType Create()
        {
            ChartNoMoveDirectionsType type = new ChartNoMoveDirectionsType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (Down != null)
            {
                itemsElementName.Add(ItemsChoiceType23.Down);
                items.Add(Down);
            }
            if (DownLeft != null)
            {
                itemsElementName.Add(ItemsChoiceType23.DownLeft);
                items.Add(DownLeft);
            }
            if (DownRight != null)
            {
                itemsElementName.Add(ItemsChoiceType23.DownRight);
                items.Add(DownRight);
            }
            if (Left != null)
            {
                itemsElementName.Add(ItemsChoiceType23.Left);
                items.Add(Left);
            }
            if (Right != null)
            {
                itemsElementName.Add(ItemsChoiceType23.Right);
                items.Add(Right);
            }
            if (Up != null)
            {
                itemsElementName.Add(ItemsChoiceType23.Up);
                items.Add(Up);
            }
            if (UpLeft != null)
            {
                itemsElementName.Add(ItemsChoiceType23.UpLeft);
                items.Add(UpLeft);
            }
            if (UpRight != null)
            {
                itemsElementName.Add(ItemsChoiceType23.UpRight);
                items.Add(UpRight);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType23[])itemsElementName.ToArray(typeof(ItemsChoiceType23));
            return type;
        }
    }





    public class ChartData
    {
        public ChartDerivedSeriesCollectionType[] ChartDerivedSeriesCollection;
        public ChartSeriesCollectionType[] ChartSeriesCollection;
        public ChartDataType Create()
        {
            ChartDataType type = new ChartDataType();
            ArrayList items = new ArrayList();
            if (ChartDerivedSeriesCollection != null)
            {
                items.AddRange(ChartDerivedSeriesCollection);
            }
            if (ChartSeriesCollection != null)
            {
                items.AddRange(ChartSeriesCollection);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class ChartMember
    {
        public ChartMembersType[] ChartMembers;
        public CustomPropertiesType[] CustomProperties;
        public string[] DataElementName;
        public ChartMemberTypeDataElementOutput[] DataElementOutput;
        public GroupType[] Group;
        public StringLocIDType[] Label;
        public SortExpressionsType[] SortExpressions;
        public ChartMemberType Create()
        {
            ChartMemberType type = new ChartMemberType();
            ArrayList items = new ArrayList();
            if (ChartMembers != null)
            {
                items.AddRange(ChartMembers);
            }
            if (CustomProperties != null)
            {
                items.AddRange(CustomProperties);
            }
            if (DataElementName != null)
            {
                items.AddRange(DataElementName);
            }
            if (DataElementOutput != null)
            {
                items.AddRange(DataElementOutput);
            }
            if (Group != null)
            {
                items.AddRange(Group);
            }
            if (Label != null)
            {
                items.AddRange(Label);
            }
            if (SortExpressions != null)
            {
                items.AddRange(SortExpressions);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class ChartHierarchy
    {
        public ChartMembersType[] ChartMembers;
        public ChartHierarchyType Create()
        {
            ChartHierarchyType type = new ChartHierarchyType();
            ArrayList items = new ArrayList();
            if (ChartMembers != null)
            {
                items.AddRange(ChartMembers);
            }

            type.Items = items.ToArray();
            return type;
        }
    }

    public class QueryParameter
    {
        public StringWithDataTypeAttribute[] Value;
        public QueryParameterType Create(string name)
        {
            QueryParameterType type = new QueryParameterType();
            type.Name = name;
            ArrayList items = new ArrayList();
            if (Value != null)
            {
                items.AddRange(Value);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class Query
    {
        public string CommandText;
        public QueryTypeCommandType? CommandType;
        public string DataSourceName;
        public QueryParametersType QueryParameters;
        public uint? Timeout;
        public QueryType Create()
        {
            QueryType type = new QueryType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (CommandText != null)
            {
                itemsElementName.Add(ItemsChoiceType1.CommandText);
                items.Add(CommandText);
            }
            if (CommandType != null)
            {
                itemsElementName.Add(ItemsChoiceType1.CommandType);
                items.Add(CommandType);
            }
            if (DataSourceName != null)
            {
                itemsElementName.Add(ItemsChoiceType1.DataSourceName);
                items.Add(DataSourceName);
            }
            if (QueryParameters != null)
            {
                itemsElementName.Add(ItemsChoiceType1.QueryParameters);
                items.Add(QueryParameters);
            }
            if (Timeout != null)
            {
                itemsElementName.Add(ItemsChoiceType1.Timeout);
                items.Add(Timeout);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType1[])itemsElementName.ToArray(typeof(ItemsChoiceType1));
            return type;
        }
    }

    public class Field
    {
        public string[] DataField;
        public StringWithDataTypeAttribute[] Value;
        public FieldType Create(string name)
        {
            FieldType type = new FieldType();
            type.Name = name;
            ArrayList items = new ArrayList();
            if (DataField != null)
            {
                items.AddRange(DataField);
            }
            if (Value != null)
            {
                items.AddRange(Value);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class DataSet
    {
        public DataSetTypeAccentSensitivity[] AccentSensitivity;
        public DataSetTypeCaseSensitivity[] CaseSensitivity;
        public string[] Collation;
        public FieldsType[] Fields;
        public FiltersType[] Filters;
        public DataSetTypeInterpretSubtotalsAsDetails[] InterpretSubtotalsAsDetails;
        public DataSetTypeKanatypeSensitivity[] KanatypeSensitivity;
        public QueryType[] Query;
        public DataSetTypeWidthSensitivity[] WidthSensitivity;
        public DataSetType Create(string name)
        {
            DataSetType type = new DataSetType();
            type.Name = name;
            ArrayList items = new ArrayList();
            if (AccentSensitivity != null)
            {
                items.AddRange(AccentSensitivity);
            }
            if (CaseSensitivity != null)
            {
                items.AddRange(CaseSensitivity);
            }
            if (Collation != null)
            {
                items.AddRange(Collation);
            }
            if (Fields != null)
            {
                items.AddRange(Fields);
            }
            if (Filters != null)
            {
                items.AddRange(Filters);
            }
            if (InterpretSubtotalsAsDetails != null)
            {
                items.AddRange(InterpretSubtotalsAsDetails);
            }
            if (KanatypeSensitivity != null)
            {
                items.AddRange(KanatypeSensitivity);
            }
            if (Query != null)
            {
                items.AddRange(Query);
            }
            if (WidthSensitivity != null)
            {
                items.AddRange(WidthSensitivity);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



    public class ConnectionProperties
    {
        public string ConnectString;
        public string DataProvider;
        public bool? IntegratedSecurity;
        public StringLocIDType Prompt;
        public ConnectionPropertiesType Create()
        {
            ConnectionPropertiesType type = new ConnectionPropertiesType();
            ArrayList items = new ArrayList();
            ArrayList itemsElementName = new ArrayList();
            if (ConnectString != null)
            {
                itemsElementName.Add(ItemsChoiceType.ConnectString);
                items.Add(ConnectString);
            }
            if (DataProvider != null)
            {
                itemsElementName.Add(ItemsChoiceType.DataProvider);
                items.Add(DataProvider);
            }
            if (IntegratedSecurity != null)
            {
                itemsElementName.Add(ItemsChoiceType.IntegratedSecurity);
                items.Add(IntegratedSecurity);
            }
            if (Prompt != null)
            {
                itemsElementName.Add(ItemsChoiceType.Prompt);
                items.Add(Prompt);
            }

            type.Items = items.ToArray();
            type.ItemsElementName = (ItemsChoiceType[])itemsElementName.ToArray(typeof(ItemsChoiceType));
            return type;
        }
    }

    public class DataSource
    {
        public ConnectionPropertiesType[] ConnectionProperties;
        public string[] DataSourceReference;
        public bool[] Transaction;
        public DataSourceType Create(string name)
        {
            DataSourceType type = new DataSourceType();
            type.Name = name;
            ArrayList items = new ArrayList();
            if (ConnectionProperties != null)
            {
                items.AddRange(ConnectionProperties);
            }
            if (DataSourceReference != null)
            {
                items.AddRange(DataSourceReference);
            }
            if (Transaction != null)
            {
                items.AddRange(Transaction);
            }

            type.Items = items.ToArray();
            return type;
        }
    }



}


