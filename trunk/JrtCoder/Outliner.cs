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
using Microsoft.Win32;
using Extensibility;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE80;
using System;
using System.Diagnostics;
using System.Collections;

namespace JrtCoder
{
    public class Outliner
    {
        DTE2 applicationObject;
        public string startpattern;
        public string endpattern;

        // set the application object to refer to 
        public void setApplicationObject(DTE2 appobj)
        {
            applicationObject = appobj;
        }

        private bool CheckLanguage(EnvDTE.Document Doc)
        {
            bool canOutlin = true;
            //if (Doc.Language == "HTML/XML")
            //{
            //    startpattern = "<!--#region";
            //    endpattern = "<!--#endregion";
            //}
            //else 
            if (Doc.Language == "C/C++" || Doc.Language == "JScript")
            {
                startpattern = "//##";
                endpattern = "//#end";
            }
            else if (Doc.Language.ToUpper() == "SQL" || Doc.Language.ToUpper().IndexOf("T-SQL")>=0)
            {
                startpattern = "--##";
                endpattern = "--#end";
            }
            else
            {
                canOutlin = false;
            }
            return canOutlin;
        }

        public bool doLineEvent(EnvDTE.TextPoint StartPoint, EnvDTE.TextPoint EndPoint, int Hint,bool sameLine)
        {
            if (CheckLanguage(applicationObject.ActiveDocument))
            {
                TextSelection selection = (TextSelection)applicationObject.ActiveDocument.Selection;
                if ((((Hint & 1) == 0) && ((Hint & 8) == 0)) && ((Hint & 0x20) == 0))
                {
                    int line = selection.ActivePoint.Line;
                    int lineCharOffset = selection.ActivePoint.LineCharOffset;
                    int tempLine = line - 1;
                    if (sameLine)
                    {
                        tempLine = line;
                    }
                    if (tempLine == StartPoint.Line)
                    {
                        int endLine = StartPoint.Line;
                        Stack st = new Stack();
                        EditPoint activPt = selection.ActivePoint.CreateEditPoint();
                        string text = "";
                        if (sameLine)
                        {
                            text = activPt.GetLines(activPt.Line, activPt.Line + 1);
                        }
                        else
                        {
                            text = activPt.GetLines(activPt.Line - 1, activPt.Line);
                        }
                        if (text.IndexOf(endpattern) >= 0)
                        {
                            while (true)
                            {
                                text = activPt.GetLines(endLine, endLine + 1);
                                if (text.TrimStart().IndexOf(startpattern) == 0)
                                {
                                    if (st.Count>1)
                                    {
                                        st.Pop();
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (endLine > 1)
                                {
                                    if (text.TrimStart().IndexOf(endpattern) == 0)
                                    {
                                        st.Push(selection.CurrentLine);
                                    }
                                    endLine--;
                                    activPt.LineUp(1);
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            selection.MoveTo(endLine, 1, false);
                            selection.EndOfLine(false);
                            if (sameLine)
                            {
                                selection.MoveToLineAndOffset(line, 1, true);
                            }
                            else
                            {
                                selection.MoveToLineAndOffset(line - 1, 1, true);
                            }
                            selection.EndOfLine(true);
                            selection.OutlineSection();
                            selection.MoveToLineAndOffset(line, lineCharOffset, false);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void doDocEvent(EnvDTE.Document Doc)
        {
            if (CheckLanguage(Doc))
            {
                TextSelection sel = (TextSelection)Doc.Selection;
                int[] lStartLine = new int[101];
                int[] lStartCol = new int[101];
                int[] lEndLine = new int[101];
                int[] lEndCol = new int[101];

                int endIndex;
                int startIndex;
                //move to the beginning of the document 
                sel.StartOfDocument(false);
                endIndex = 0;
                EnvDTE.TextRanges textRanges = null;
                int findOption=(int)vsFindOptions.vsFindOptionsMatchInHiddenText;
                while (sel.FindPattern(endpattern, findOption, ref textRanges))
                {
                    endIndex += 1;
                    textRanges = null;
                }
                //now we know how many patterns we have 
                lStartLine = new int[endIndex + 100 + 1];
                lStartCol = new int[endIndex + 100 + 1];
                lEndLine = new int[endIndex + 100 + 1];
                lEndCol = new int[endIndex + 100 + 1];

                sel.StartOfDocument(false);
                endIndex = 0;
                while (sel.FindPattern(endpattern, findOption, ref textRanges))
                {
                    //if we found the end of a Region, save the position 
                    sel.EndOfLine(false);
                    lEndLine[endIndex] = sel.TopPoint.Line;
                    lEndCol[endIndex] = sel.TopPoint.LineCharOffset;
                    endIndex += 1;
                    textRanges = null;
                }
                textRanges = null;
                //move to the beginning of the document 
                sel.StartOfDocument(false);
                startIndex = 0;
                while (sel.FindPattern(startpattern, findOption, ref textRanges))
                {
                    sel.EndOfLine(false);
                    int topLine = sel.ActivePoint.Line;
                    int topLineOffset = sel.ActivePoint.LineCharOffset;
                    

                    if (sel.ActivePoint.Line > sel.AnchorPoint.Line)
                    {
                        topLine = sel.AnchorPoint.Line;
                        topLineOffset = sel.ActivePoint.LineCharOffset;
                    }

                    lStartLine[startIndex] = topLine;
                    lStartCol[startIndex] = topLineOffset;
                    startIndex += 1;
                    textRanges = null;
                }
                if ((startIndex != endIndex))
                {
                    //error 
                    Debug.WriteLine("Error: missing either //#region or //#endregion");
                    return;
                }
                int i;
                int j;
                for (i = startIndex - 1; i >= 0; i--)
                {
                    //first take the last //#region and find the matching //#endregion 
                    sel.MoveToLineAndOffset(lStartLine[i], lStartCol[i], false);
                    j = 0;
                    while (lEndLine[j] < lStartLine[i])
                    {
                        j += 1;
                    }
                    //we found the matchin //#endregion 
                    sel.MoveToLineAndOffset(lEndLine[j], lEndCol[j], true);
                    sel.SwapAnchor();
                    sel.OutlineSection();
                    sel.LineDown(false, 1);
                    lEndLine[j] = -1;
                }
            }

        }



    }
}


