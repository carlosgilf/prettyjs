using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text;
using EnvDTE80;
using EnvDTE;
using System.Windows.Forms;
using Microsoft.VisualStudio.Editor;
using System.Text;
using HtmlAgilityPack;
using System.IO;

namespace Jrt.PrettyJs
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidPrettyJsPkgString)]
    public sealed class PrettyJsPackage : Package
    {
        //JsFormatter formatter = new JsFormatter();

        private Beautifier beautifier = new Beautifier();
        public CodeOption option = new CodeOption();

        public string GetSelectedText()
        {
            IVsTextManager txtMgr = (IVsTextManager)GetService(typeof(SVsTextManager));
            IVsTextView txtView = null;
            string selectedText = string.Empty;

            int mustHaveFocus = 1;
            txtMgr.GetActiveView(mustHaveFocus, null, out txtView);

            txtView.GetSelectedText(out selectedText);
            return selectedText;
        }

        private IWpfTextView GetActiveTextView()
        {
            IWpfTextView view = null;
            IVsTextView vTextView = null;

            IVsTextManager txtMgr =
            (IVsTextManager)GetService(typeof(SVsTextManager));

            int mustHaveFocus = 1;
            txtMgr.GetActiveView(mustHaveFocus, null, out vTextView);

            IVsUserData userData = vTextView as IVsUserData;
            if (null != userData)
            {
                IWpfTextViewHost viewHost;
                object holder;
                Guid guidViewHost = DefGuidList.guidIWpfTextViewHost;
                userData.GetData(ref guidViewHost, out holder);
                viewHost = (IWpfTextViewHost)holder;
                view = viewHost.TextView;
            }

            return view;
        }


        //public void FormatAllCode()
        //{
        //    IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
        //    IWpfTextView view = GetActiveTextView();
        //    //String selectedText = view.Selection.SelectedSpans[0].GetText();
        //    var allText = view.TextSnapshot.GetText();
        //    string formatedCode = formatter.Format(allText);
        //    var s = new Span(0, 1);
        //    view.TextBuffer.Replace(new Span(0, allText.Length), formatedCode);
        //}

        public void Format(bool isFormatAll)
        {
            bool handled = false;
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            IWpfTextView view = GetActiveTextView();
            DTE2 dte2 = GetService(typeof(SDTE)) as EnvDTE80.DTE2;

            Document activeDoc = dte2.ActiveDocument;
            if (activeDoc == null)
            {
                MessageBox.Show("没有活动文档。");
                return;
            }

            TextDocument textDoc = activeDoc.Object("TextDocument") as TextDocument;
            if (textDoc == null)
            {
                MessageBox.Show("请选择要插入的文档。");
                return;
            }

            string lang = textDoc.Language.ToUpper();
            if (//lang == "CSHARP" || 
                lang == "BASIC")
            {
                MessageBox.Show("不能格式化VB代码。");
                return;
            }

            try
            {
                if (isFormatAll)
                {
                    if (lang == "HTML")
                    {
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        var allText = view.TextSnapshot.GetText();
                        doc.LoadHtml(allText);
                        if (!dte2.UndoContext.IsOpen)
                        {
                            dte2.UndoContext.Open("格式化文档", false);
                            handled = true;
                        }


                        foreach (HtmlNode script in doc.DocumentNode.SelectNodes("//script"))
                        {
                            int indent = 1;
                            string space = "";
                            if (script.PreviousSibling!=null)
	                        {
                                var node = script.PreviousSibling;
                                var prevNodeHtml = node.OuterHtml;
                                while (true)
                                {
                                    if (node.PreviousSibling == null)
                                    {
                                        break;
                                    }
                                    prevNodeHtml = node.PreviousSibling.OuterHtml + prevNodeHtml;
                                    if (node.PreviousSibling.OuterHtml.IndexOf('\r')>-1
                                        ||node.PreviousSibling.OuterHtml.IndexOf('\n')>-1
                                        )
                                    {
                                        break;
                                    }
                                    node = node.PreviousSibling;
                                }
                                
                                int spaceCount = 0;
                                for (int i = prevNodeHtml.Length - 1; i >= 0; i--)
                                {
                                    if ("\r\n".IndexOf(prevNodeHtml[i]) >= 0)
                                    {
                                        break;
                                    }
                                    if (prevNodeHtml[i] == '\t')
                                    {
                                        space += prevNodeHtml[i];
                                        spaceCount += 4;
                                    }
                                    else
                                    {
                                        space += " ";
                                        spaceCount += 1;
                                    }
                                }
                                indent = spaceCount/4 + 1;
	                        }
                            beautifier.Indent = indent;
                            beautifier.activeOffset = 0;
                            beautifier.js_beautify(script.InnerHtml.TrimStart());
                            script.InnerHtml = "\r\n" + "".PadLeft(indent * 4, ' ') + beautifier.output + "\r\n" + space;
                            //doc.Save(
                            //var span = new Span();
                            //view.TextBuffer.Delete();
                        }

                        StringBuilder sb = new StringBuilder();
                        StringWriter sw = new StringWriter(sb);
                        doc.Save(sw);
                        view.TextBuffer.Replace(new Span(0, allText.Length), sb.ToString());
                    }
                    else 
                    {
                        if (!dte2.UndoContext.IsOpen)
                        {
                            dte2.UndoContext.Open("格式化文档", false);
                            handled = true;
                        }
                        EditPoint objEditPt = textDoc.StartPoint.CreateEditPoint();
                        EditPoint activPt = textDoc.Selection.ActivePoint.CreateEditPoint();
                        string firstSt = activPt.GetText(objEditPt);
                        int activeOffset = firstSt.Length - 1;
                        EditPoint objMovePt = textDoc.EndPoint.CreateEditPoint();
                        objEditPt.StartOfDocument();
                        objMovePt.EndOfDocument();
                        string sql = objMovePt.GetLines(1, objMovePt.Line + 1);
                        beautifier.Indent = 0;
                        beautifier.activeOffset = activeOffset;
                        beautifier.js_beautify(sql);
                        objEditPt.ReplaceText(objMovePt, beautifier.output, (int)vsEPReplaceTextOptions.vsEPReplaceTextKeepMarkers);

                        textDoc.Selection.MoveToAbsoluteOffset(beautifier.activeFormatedOffset + 1, false); 
                    }
                }
                else
                {
                    TextSelection objTextSelection = (TextSelection)dte2.ActiveDocument.Selection;
                    EditPoint editPoint = textDoc.Selection.ActivePoint.CreateEditPoint();
                    if (!textDoc.Selection.IsEmpty)
                    {
                        if (!dte2.UndoContext.IsOpen)
                        {
                            dte2.UndoContext.Open("格式化选中代码", false);
                            handled = true;
                        }
                        int moveLineCount = 0;
                        bool atEndLine = false;
                        //选区扩充到第一行的开头位置,以及最后一行的结束位置
                        int topLine = objTextSelection.ActivePoint.Line;
                        int bottomLine = objTextSelection.AnchorPoint.Line;

                        if (objTextSelection.ActivePoint.Line > objTextSelection.AnchorPoint.Line)
                        {
                            objTextSelection.SwapAnchor();
                            topLine = objTextSelection.ActivePoint.Line;
                            bottomLine = objTextSelection.AnchorPoint.Line;
                        }
                        objTextSelection.MoveTo(bottomLine, 1, false);
                        objTextSelection.EndOfLine(false);
                        objTextSelection.MoveTo(topLine, 1, true);
                        string text = textDoc.Selection.Text;

                        //上一行最后一个字符
                        string prevLineChar = "";
                        textDoc.Selection.Delete(1);
                        try
                        {
                            if (topLine > 1)
                            {
                                int tLine = topLine - 1;
                                objTextSelection.MoveTo(tLine, 1, true);
                                //int moveLineCount = 1;
                                moveLineCount = 1;
                                while (objTextSelection.Text.Trim() == "")
                                {
                                    if (tLine > 1)
                                    {
                                        tLine--;
                                        objTextSelection.MoveTo(tLine, 1, true);
                                        moveLineCount++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                string topLineText = objTextSelection.Text;
                                if (topLineText.Trim() != "")
                                {
                                    int indent = beautifier.StringToIndent(topLineText);
                                    topLineText = topLineText.Trim();
                                    string lastStr = topLineText[topLineText.Length - 1].ToString();
                                    string endChars = "{[";

                                    if (endChars.IndexOf(lastStr) >= 0)
                                    {
                                        indent++;
                                    }
                                    beautifier.Indent = indent;
                                    int endLine = topLine + moveLineCount;
                                    if (endLine < textDoc.EndPoint.Line)
                                    {
                                        objTextSelection.MoveTo(topLine + moveLineCount, 1, false);
                                    }
                                    else
                                    {
                                        atEndLine = true;
                                    }
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append('\t', indent);
                                    prevLineChar = sb.ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //string excptionMsg = ExceptionExtensions.ToFullStackTrace(ex);
                            //MessageBox.Show("格式化代码时出现错误:" + ex.Message + ":" + excptionMsg);
                        }

                        try
                        {
                            beautifier.js_beautify(text);
                            editPoint.Insert(prevLineChar + beautifier.output);
                            if (atEndLine)
                            {
                                objTextSelection.EndOfDocument(false);
                            }
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("格式化代码时出现错误:beautify:" + ex.Message);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("格式化代码时出现错误:" + ex.Message);
            }
            finally
            {
                if (handled)
                {
                    dte2.UndoContext.Close();
                }
            }
        }

        public void AddRegionCallback(object server, EventArgs e)
        {
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            DTE2 dte2 = GetService(typeof(SDTE)) as EnvDTE80.DTE2;

            Document activeDoc = dte2.ActiveDocument;
            if (activeDoc == null)
            {
                MessageBox.Show("没有活动文档。");
                return;
            }

            TextDocument textDoc = activeDoc.Object("TextDocument") as TextDocument;
            if (textDoc == null)
            {
                MessageBox.Show("请选择要插入的文档。");
                return;
            }
            TextSelection objTextSelection = textDoc.Selection;
            EditPoint editPoint = textDoc.Selection.ActivePoint.CreateEditPoint();
            if (!textDoc.Selection.IsEmpty)
            {
                string regionSpace = "";


                //选区扩充到第一行的开头位置,以及最后一行的结束位置
                int topLine = objTextSelection.ActivePoint.Line;
                int bottomLine = objTextSelection.AnchorPoint.Line;

                if (objTextSelection.ActivePoint.Line > objTextSelection.AnchorPoint.Line)
                {
                    objTextSelection.SwapAnchor();
                    topLine = objTextSelection.ActivePoint.Line;
                    bottomLine = objTextSelection.AnchorPoint.Line;
                }
                objTextSelection.StartOfLine(vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn, true);
                string text = objTextSelection.Text;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '\t' || text[i] == ' ')
                    {
                        regionSpace += text[i];
                    }
                    else
                    {
                        break;
                    }
                }
                EditPoint topPoint = objTextSelection.ActivePoint.CreateEditPoint();
                topPoint.Insert(regionSpace + "//##\r\n");
                objTextSelection.MoveTo(objTextSelection.AnchorPoint.Line, 1, false);
                objTextSelection.EndOfLine(false);
                EditPoint topPoint1 = objTextSelection.AnchorPoint.CreateEditPoint();
                topPoint1.Insert("\r\n" + regionSpace + "//#end");
                
                object customIn = new object();
                object customOut = new object();
                try
                {
                    //raising command "Edit.ToggleOutliningExpansion"
                    //parameters are its GUID and its ID
                    dte2.Commands.Raise("{1496A755-94DE-11D0-8C3F-00C04FC2AAE2}", 129, ref customIn, ref customOut);
                }
                catch (Exception xcp)
                {
                    throw xcp;
                }

            }
        }

        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public PrettyJsPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }


        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            SetCodeOption();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                //// Create the command for the menu item.
                //CommandID menuCommandID = new CommandID(GuidList.guidPrettyJsCmdSet, (int)PkgCmdIDList.cmdFormatJs);
                //MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
                //mcs.AddCommand( menuItem );
                CommandID menuCommandID = null;
                menuCommandID = new CommandID(GuidList.guidPrettyJsCmdSet, (int)PkgCmdIDList.cmdFormatJs);
                MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID);
                mcs.AddCommand(menuItem);

                menuCommandID = new CommandID(GuidList.guidPrettyJsCmdSet, (int)PkgCmdIDList.cmdFormatSelectedJs);
                MenuCommand selectedJsMenuItem = new MenuCommand(menuSelectedJsCallback, menuCommandID);
                mcs.AddCommand(selectedJsMenuItem);


                menuCommandID = new CommandID(GuidList.guidPrettyJsCmdSet, (int)PkgCmdIDList.cmdSettings);
                MenuCommand settingsMenuItem = new MenuCommand(settingsCallback, menuCommandID);
                mcs.AddCommand(settingsMenuItem);

                menuCommandID = new CommandID(GuidList.guidPrettyJsCmdSet, (int)PkgCmdIDList.cmdAddToRegion);
                MenuCommand addRegionMenuItem = new MenuCommand(AddRegionCallback, menuCommandID);
                mcs.AddCommand(addRegionMenuItem);

            }
        }
        #endregion


        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            Format(true);
        }

        private void menuSelectedJsCallback(object sender, EventArgs e)
        {
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            Format(false);
        }

        private void settingsCallback(object sender, EventArgs e)
        {
            JsFormatSettings settings = new JsFormatSettings(this);
            DialogResult result = settings.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetCodeOption();
            }
            return;

        }

        private void SetCodeOption()
        {
            beautifier.Style = option.Style;
            beautifier.IdentStr = option.IdentStr;
            beautifier.AddSpaceAfterCtrlWord = option.AddSpaceAfterCtrlWord;
            beautifier.MaxBlankLine = option.MaxBlankLine;
            beautifier.KeepBlankLineCount = option.KeepBlankLineCount;
            beautifier.RemoveBlankLine = option.RemoveBlankLine;
        }

        ///// <summary>
        ///// This function is the callback used to execute a command when the a menu item is clicked.
        ///// See the Initialize method to see how the menu item is associated to this function using
        ///// the OleMenuCommandService service and the MenuCommand class.
        ///// </summary>
        //private void MenuItemCallback(object sender, EventArgs e)
        //{
        //    // Show a Message Box to prove we were here
        //    IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
        //    Guid clsid = Guid.Empty;
        //    int result;
        //    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
        //               0,
        //               ref clsid,
        //               "PrettyJs",
        //               string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
        //               string.Empty,
        //               0,
        //               OLEMSGBUTTON.OLEMSGBUTTON_OK,
        //               OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
        //               OLEMSGICON.OLEMSGICON_INFO,
        //               0,        // false
        //               out result));
        //}

    }
}
