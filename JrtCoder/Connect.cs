#region Disclaimer/Info
/*
 * PrettyJs  - http://jintan.cnblogs.com
 * Copyright (c) 靳如坦.  All rights reserved.
 * 
 * The contents of this file are subject to the Mozilla Public
 * License Version 1.1 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of
 * the License at http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an 
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or
 * implied. See the License for the specific language governing
 * rights and limitations under the License.
 */
#endregion
using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JrtCoder
{
    /// <summary>用于实现外接程序的对象。</summary>
    /// <seealso class='IDTExtensibility2' />
    [GuidAttribute("F7A9F257-1176-46b2-B383-8FA891CD22F1"), ProgId("JrtCoder.Connect")]
    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
        private Beautifier beautifier = new Beautifier();
        public CodeOption option = new CodeOption();
        private Outliner outliner = new Outliner();
        bool isReadConfig = false;
        const string Format = "JrtFormat";
        const string FormatAll = "JavascriptFormat";
        const string FormatSelected = "FormatSelectedText";
        const string FormatSettings = "FromatSettings";
        const string AddRegion = "AddRegion";

        DocumentEvents docEvents;
        EnvDTE.TextEditorEvents eventTextEditor;
        TextDocumentKeyPressEvents eventTextEditor2;

        private static bool _initialized = false;
        private static UsefulFunctions _usefulFunctions;

        //添加顶级菜单
        CommandBarPopup jrtCoderCmd = null;
        Command formatAllCmd = null;
        Command formatSelectedCmd = null;
        Command formatSettingsCmd = null;
        Command AddRegionCmd = null;

        private string GetFullCmd(string cmdName)
        {
            return _addInInstance.ProgID + "." + cmdName;
        }

        /// <summary>实现外接程序对象的构造函数。请将您的初始化代码置于此方法内。</summary>
        public Connect()
        {
            if (!isReadConfig)
            {
                try
                {
                    if (option == null)
                    {
                        option = new CodeOption();
                    }
                    option.Load();

                    isReadConfig = true;
                }
                catch (System.Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            beautifier = new Beautifier();
            SetCodeOption();
        }

        /// <summary>实现 IDTExtensibility2 接口的 OnConnection 方法。接收正在加载外接程序的通知。</summary>
        /// <param term='application'>宿主应用程序的根对象。</param>
        /// <param term='connectMode'>描述外接程序的加载方式。</param>
        /// <param term='addInInst'>表示此外接程序的对象。</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;
            if ((connectMode == ext_ConnectMode.ext_cm_UISetup || connectMode == Extensibility.ext_ConnectMode.ext_cm_Startup)&&!_initialized)
            {
                _usefulFunctions = new UsefulFunctions(_applicationObject, _addInInstance);
                string keyGlobal = "Global::";

                outliner.setApplicationObject(_applicationObject);
                docEvents = _applicationObject.Events.get_DocumentEvents(null);
                docEvents.DocumentOpened += new _dispDocumentEvents_DocumentOpenedEventHandler(docEvents_DocumentOpened);
                eventTextEditor = _applicationObject.Events.get_TextEditorEvents(null);
                eventTextEditor.LineChanged += new _dispTextEditorEvents_LineChangedEventHandler(eventTextEditor_LineChanged);
                EnvDTE80.Events2 events = (EnvDTE80.Events2)_applicationObject.Events;
                eventTextEditor2 = events.get_TextDocumentKeyPressEvents(null);
                eventTextEditor2.BeforeKeyPress += new _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler(eventTextEditor2_BeforeKeyPress);

                object[] contextGUIDS = new object[] { };
                Commands2 commands = (Commands2)_applicationObject.Commands;
                string toolsMenuName;

                try
                {
                    //若要将此命令移动到另一个菜单，则将“工具”一词更改为此菜单的英文版。
                    //  此代码将获取区域性，将其追加到菜单名中，然后将此命令添加到该菜单中。
                    //  您会在此文件中看到全部顶级菜单的列表
                    //  CommandBar.resx.
                    string resourceName;
                    ResourceManager resourceManager = new ResourceManager("JrtCoder.CommandBar", Assembly.GetExecutingAssembly());
                    CultureInfo cultureInfo = new CultureInfo(_applicationObject.LocaleID);

                    if (cultureInfo.TwoLetterISOLanguageName == "zh")
                    {
                        System.Globalization.CultureInfo parentCultureInfo = cultureInfo.Parent;
                        resourceName = String.Concat(parentCultureInfo.Name, "Tools");
                        keyGlobal = "全局::";
                    }
                    else
                    {
                        resourceName = String.Concat(cultureInfo.TwoLetterISOLanguageName, "Tools");
                    }
                    toolsMenuName = resourceManager.GetString(resourceName);
                }
                catch
                {
                    //我们试图查找“工具”一词的本地化版本，但未能找到。
                    //  默认值为 en-US 单词，该值可能适用于当前区域性。
                    toolsMenuName = "Tools";
                }

                //将此命令置于“工具”菜单上。
                //查找 MenuBar 命令栏，该命令栏是容纳所有主菜单项的顶级命令栏:
                Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];

                //在 MenuBar 命令栏上查找“工具”命令栏:
                CommandBarControl toolsControl = menuBarCommandBar.Controls[toolsMenuName];
                CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;

                //如果希望添加多个由您的外接程序处理的命令，可以重复此 try/catch 块，
                //  只需确保更新 QueryStatus/Exec 方法，使其包含新的命令名。
                try
                {


                    try
                    {
                        formatAllCmd = _applicationObject.Commands.Item(GetFullCmd(FormatAll), -1);
                        formatSelectedCmd = _applicationObject.Commands.Item(GetFullCmd(FormatSelected), -1);
                        formatSettingsCmd = _applicationObject.Commands.Item(GetFullCmd(FormatSettings), -1);
                        AddRegionCmd = _applicationObject.Commands.Item(GetFullCmd(AddRegion), -1);
                    }
                    catch (System.Exception e)
                    {

                    }

                    try
                    {
                        if (formatAllCmd == null)
                        {
                            formatAllCmd = commands.AddNamedCommand2(_addInInstance, FormatAll, "格式化Js", "格式化全部javascript代码", true, 59, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                            

                        }
                        if (formatSelectedCmd == null)
                        {
                            formatSelectedCmd = commands.AddNamedCommand2(_addInInstance, FormatSelected, "格式化选定的Js", "格式化选定的javascript代码", true, 59, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                            try
                            {
                                CommandBar cb = _usefulFunctions.GetCommandBar("HTML Context", null);
                                formatSelectedCmd.AddControl(cb, cb.accChildCount + 1);
                                cb = _usefulFunctions.GetCommandBar("Script Context", null);
                                formatSelectedCmd.AddControl(cb, cb.accChildCount + 1);
                                cb = _usefulFunctions.GetCommandBar("ASPX Context", null);
                                formatSelectedCmd.AddControl(cb, cb.accChildCount + 1);
                            }
                            catch (System.Exception)
                            { }
                            
                        }
                        if (AddRegionCmd == null)
                        {
                            AddRegionCmd = commands.AddNamedCommand2(_addInInstance, AddRegion, "加入折叠区域", "加入折叠区域", true, 72, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                            
                            try
                            {
                                CommandBar cb = _usefulFunctions.GetCommandBar("HTML Context", null);
                                AddRegionCmd.AddControl(cb, cb.accChildCount + 1);
                                cb = _usefulFunctions.GetCommandBar("Script Context", null);
                                AddRegionCmd.AddControl(cb, cb.accChildCount + 1);
                                cb = _usefulFunctions.GetCommandBar("ASPX Context", null);
                                AddRegionCmd.AddControl(cb, cb.accChildCount + 1);
                            }
                            catch (System.Exception)
                            { }
                        }
                        if (formatSettingsCmd == null)
                        {
                            formatSettingsCmd = commands.AddNamedCommand2(_addInInstance, FormatSettings, "js格式化参数选项", "js格式化参数配置", true, 59, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                        }
                   
                        formatAllCmd.Bindings = new object[] { keyGlobal + "ctrl+R,ctrl+F" };
                        formatSelectedCmd.Bindings = new object[] { keyGlobal + "ctrl+R,ctrl+G" };
                        AddRegionCmd.Bindings = new object[] { keyGlobal + "ctrl+alt+K" };
                    }
                    catch (System.Exception e)
                    {

                    }
      
                    foreach (CommandBarControl control in toolsPopup.Controls)
                    {
                        if (control.Caption == "JrtCoder")
                        {
                            jrtCoderCmd = control as CommandBarPopup;
                            break;
                        }
                    }
                    if (jrtCoderCmd == null)
                    {
                        try
                        {
                            jrtCoderCmd = (CommandBarPopup)toolsPopup.Controls.Add(vsCommandBarType.vsCommandBarTypePopup, 1, null, 1, false);
                            jrtCoderCmd.Caption = "JrtCoder";
                            if ((jrtCoderCmd != null))
                            {
                                formatAllCmd.AddControl(jrtCoderCmd.CommandBar, 1);
                                formatSelectedCmd.AddControl(jrtCoderCmd.CommandBar, 2);
                                formatSettingsCmd.AddControl(jrtCoderCmd.CommandBar, 3);

                            }
                        }
                        catch (System.Exception e)
                        {
                        }
                    }
                    jrtCoderCmd.Visible = true;
                }
                catch (System.ArgumentException)
                {
                    //如果出现此异常，原因很可能是由于具有该名称的命令已存在。如果确实如此，则无需重新创建此命令，并且可以放心忽略此异常。
                }
                _initialized = true;
            }
        }

        void eventTextEditor2_BeforeKeyPress(string Keypress, TextSelection Selection, bool InStatementCompletion, ref bool CancelKeypress)
        {
            Document activeDoc = _applicationObject.DTE.ActiveDocument;
            if (activeDoc == null)
            {
                return;
            }
            else if (activeDoc.Language == "JScript" || activeDoc.Language.ToUpper().IndexOf("SQL") >= 0)
            {
                if (option.AutoCompleteBracket)
                {
                    if (Keypress == "}")
                    {
                        EditPoint ep = Selection.ActivePoint.CreateEditPoint();
                        EditPoint sp = ep.CreateEditPoint();
                        sp.CharLeft(1);

                        sp.StartOfDocument();
                        string txt = sp.GetText(ep);
                        if (txt != "")
                        {
                            txt += "}";
                            VSBlockInfo block = beautifier.GetBLOCK(txt);
                            if (block.text != "")
                            {
                                sp.LineDown(block.line - 1);
                                beautifier.Indent = block.indent;
                                beautifier.js_beautify(block.text);
                                StringBuilder sb = new StringBuilder();
                                string formatedCode = beautifier.output.Remove(beautifier.output.Length - 1, 1);
                                sb.Append('\t', block.indent);
                                sb.Append(formatedCode);

                                //sp.Delete(txt.Length-1);
                                //sp.Insert(sb.ToString());

                                ep.ReplaceText(sp, sb.ToString(), (int)vsEPReplaceTextOptions.vsEPReplaceTextKeepMarkers);
                                return;
                            }

                        }
                    }
                    else if (Keypress == " " || Keypress == "\t")
                    {
                        try
                        {
                            bool outLined = outliner.doLineEvent(Selection.ActivePoint, Selection.ActivePoint, 0, true);
                            if (outLined)
                            {
                                CancelKeypress = true;
                            }
                        }
                        catch (System.Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }

                    }
                }
            }
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

        void eventTextEditor_LineChanged(TextPoint StartPoint, TextPoint EndPoint, int Hint)
        {
            outliner.doLineEvent(StartPoint, EndPoint, Hint,false);
        }

        void docEvents_DocumentOpened(Document Document)
        {
            outliner.doDocEvent(Document);
        }

        /// <summary>实现 IDTExtensibility2 接口的 OnDisconnection 方法。接收正在卸载外接程序的通知。</summary>
        /// <param term='disconnectMode'>描述外接程序的卸载方式。</param>
        /// <param term='custom'>特定于宿主应用程序的参数数组。</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
            if (eventTextEditor2 != null)
            {
                //eventTextEditor2.BeforeKeyPress -= new _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler(eventTextEditor2_BeforeKeyPress);
            }

        }

        /// <summary>实现 IDTExtensibility2 接口的 OnAddInsUpdate 方法。当外接程序集合已发生更改时接收通知。</summary>
        /// <param term='custom'>特定于宿主应用程序的参数数组。</param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>实现 IDTExtensibility2 接口的 OnStartupComplete 方法。接收宿主应用程序已完成加载的通知。</summary>
        /// <param term='custom'>特定于宿主应用程序的参数数组。</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {
        }

        /// <summary>实现 IDTExtensibility2 接口的 OnBeginShutdown 方法。接收正在卸载宿主应用程序的通知。</summary>
        /// <param term='custom'>特定于宿主应用程序的参数数组。</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
        }

        /// <summary>实现 IDTCommandTarget 接口的 QueryStatus 方法。此方法在更新该命令的可用性时调用</summary>
        /// <param term='commandName'>要确定其状态的命令的名称。</param>
        /// <param term='neededText'>该命令所需的文本。</param>
        /// <param term='status'>该命令在用户界面中的状态。</param>
        /// <param term='commandText'>neededText 参数所要求的文本。</param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                if (commandName.StartsWith(_addInInstance.ProgID + "."))
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
            }
        }

        /// <summary>实现 IDTCommandTarget 接口的 Exec 方法。此方法在调用该命令时调用。</summary>
        /// <param term='commandName'>要执行的命令的名称。</param>
        /// <param term='executeOption'>描述该命令应如何运行。</param>
        /// <param term='varIn'>从调用方传递到命令处理程序的参数。</param>
        /// <param term='varOut'>从命令处理程序传递到调用方的参数。</param>
        /// <param term='handled'>通知调用方此命令是否已被处理。</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            handled = false;
            if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault && commandName.StartsWith(_addInInstance.ProgID + "."))
            {

                if (commandName == GetFullCmd(FormatSettings))
                {
                    JsFormatSettings settings = new JsFormatSettings(this);
                    DialogResult result = settings.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        SetCodeOption();
                    }
                    handled = true;
                    return;
                }

                Document activeDoc = _applicationObject.DTE.ActiveDocument;
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
                if (lang == "CSHARP" || lang == "BASIC")
                {
                    MessageBox.Show("不能格式化C#或者VB代码。");
                    return;
                }
                if (commandName == GetFullCmd(FormatAll))
                {
                    try
                    {
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
                        outliner.doDocEvent(activeDoc);
                        //textDoc.Selection.GotoLine(curreLine, false);
                        textDoc.Selection.MoveToAbsoluteOffset(beautifier.activeFormatedOffset+1, false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("格式化代码时出现错误:" + ex.Message);
                    }

                }
                else if (commandName == GetFullCmd(AddRegion))
                {
                    TextSelection objTextSelection = (TextSelection)_applicationObject.ActiveDocument.Selection;
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
                        objTextSelection.MoveToLineAndOffset(topLine, 1, true);
                        objTextSelection.EndOfLine(true);
                        //objTextSelection.SwapAnchor();
                        objTextSelection.OutlineSection();
                        objTextSelection.StartOfLine(vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn, false);

                    }
                }
                else if (commandName == GetFullCmd(FormatSelected))
                {
                    try
                    {
                        TextSelection objTextSelection = (TextSelection)_applicationObject.ActiveDocument.Selection;

                        EditPoint editPoint = textDoc.Selection.ActivePoint.CreateEditPoint();
                        if (!textDoc.Selection.IsEmpty)
                        {
                            if (!_applicationObject.DTE.UndoContext.IsOpen)
                            {
                                _applicationObject.DTE.UndoContext.Open(commandName, false);
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
                                        int spaceCount = 0;
                                        for (int i = 0; i < topLineText.Length; i++)
                                        {
                                            if (topLineText[i] == '\t')
                                            {
                                                spaceCount += 4;
                                            }
                                            else if (topLineText[i] == ' ')
                                            {
                                                spaceCount += 1;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        int indent = spaceCount / 4;
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
                                string excptionMsg = ExceptionExtensions.ToFullStackTrace(ex);
                                MessageBox.Show("格式化代码时出现错误:" + ex.Message + ":" + excptionMsg);
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

                            if (handled)
                            {
                                _applicationObject.DTE.UndoContext.Close();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("格式化代码时出现错误:" + ex.Message);
                    }

                }
                handled = true;
            }
        }
        private DTE2 _applicationObject;
        private AddIn _addInInstance;



    }



}