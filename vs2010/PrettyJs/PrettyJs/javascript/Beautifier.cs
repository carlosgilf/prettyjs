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


namespace Jrt.PrettyJs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Web;

    public class Beautifier
    {
        public Beautifier()
        {
            this.whitespace = this.make_array("\n\r\t ");
            this.wordchar = this.make_array("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_$");

            //运算符号
            this.punct = this.make_array(".,=?:*&%^+-*<>!|");
            this.keyword = this.make_list("if,else,function,for,while,switch,case,default");
            this.control = this.make_list("if,else,for,while");
        }

        private string get_next_token(ref string text, ref int pos, out TK token)
        {
            char ch;
            string str;
            string str2;
            int length = text.Length;
            int num2 = 0;
            token = TK.UNKNOWN;

            do
            {
                if (pos >= length)
                {
                    token = TK.EOF;
                    return null;
                }
                ch = text[pos];
                pos++;
                if (ch == '\n')
                {
                    curreTokenLine++;
                }
                if (ch == '\n')
                {
                    inEqualOp = false;
                    num2++;
                    if (lastword != ";" && (lasttok == TK.WORD || lasttok == TK.END_EXPR))
                    {
                        token = TK.NEW_LINE;
                        return ch.ToString();
                    }
                }
            }
            while (this.in_array(ch, this.whitespace));

            if (num2 > 1)
            {
                if (removeBlankLine != BlankLineOption.None)
                {
                    int max = removeBlankLine == BlankLineOption.RemoveOtiose ? MaxBlankLine : 1;
                    int keepLine = removeBlankLine == BlankLineOption.RemoveOtiose ? KeepBlankLineCount + 1 : 0;
                    //是否去除多余的空行
                    if (num2 >= max)
                    {
                        num2 = keepLine;
                    }
                }
                for (int i = 1; i < num2; i++)
                {
                    this.nl();
                }
            }
            if (!this.in_array(ch, this.wordchar))
            {
                switch (ch)
                {
                    case '(':
                    case '[':
                        token = TK.START_EXPR;
                        return ch.ToString();

                    case ')':
                    case ']':
                        if (ch == ')' && _cases == CASE.SWITCH)
                        {
                            token = TK.START_SWITCH;
                            return ch.ToString();
                        }

                        token = TK.END_EXPR;
                        return ch.ToString();

                    case '{':
                        token = TK.START_BLOCK;
                        return ch.ToString();

                    case '}':
                        if (_cases == CASE.CASE)
                            this.case_pop();
                        token = TK.END_BLOCK;
                        return ch.ToString();

                    case ';':
                        token = TK.END_COMMAND;
                        return ch.ToString();
                    //case ':':
                    //    token = TK.JSON;
                    //    return ch.ToString();
                }
                if (ch != '/')
                {
                    goto CheckPunct;
                }
                if (text[pos] != '*')
                {
                    if (text[pos] == '/')
                    {
                        string str3 = ch.ToString();
                        while ((text[pos] != '\r') && (text[pos] != '\n'))
                        {
                            str3 = str3 + text[pos];
                            pos++;
                            if (pos >= length)
                            {
                                break;
                            }
                        }
                        if (pos > length && text[pos] == '\n')
                        {
                            curreTokenLine++;
                        }
                        pos++;
                        token = TK.COMMENT;
                        return str3;
                    }
                    goto CheckPunct;
                }
                str2 = "";
                pos++;
                if (pos < length)
                {
                    while ((((text[pos] != '*') || ((pos + 1) >= length)) || (text[pos + 1] != '/')) && (pos < length))
                    {
                        if (text[pos] == '\n')
                        {
                            curreTokenLine++;
                        }
                        str2 = str2 + text[pos];
                        pos++;
                        if (pos >= length)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                str = ch.ToString();
                if (pos < length)
                {
                    while (this.in_array(text[pos], this.wordchar))
                    {
                        if (text[pos] == '\n')
                        {
                            curreTokenLine++;
                        }
                        str = str + text[pos];
                        pos++;
                        if (pos == length)
                        {
                            break;
                        }
                    }
                }

                if (str == "case" || str == "default")
                {
                    if (_cases == CASE.CASE)
                        this.case_pop();
                    token = TK.START_CASE;
                }
                else
                {
                    token = TK.WORD;
                }
                return str;
            }
            pos += 2;
            token = TK.BLOCK_COMMENT;
            return ("/*" + str2 + "*/");

        CheckPunct:
            if (((ch != '\'') && (ch != '"')) && ((ch != '/') || (((this.lasttok != TK.START_EXPR) && (this.lasttok != TK.PUNCT)) && ((this.lasttok != TK.EOF) && (this.lasttok != TK.END_COMMAND)))))
            {
                if (!this.in_array(ch, this.punct))
                {
                    //除法操作运算的情况
                    if (ch == '/')
                    {
                        token = TK.PUNCT;
                        return ch.ToString();
                    }
                    return ch.ToString();
                }
                str = ch.ToString();
                if (pos < length)
                {
                    //08-12-5 fixed :var s=.1这种情况格式化后的效果应该是var s = .1而不是var s =. 1，
                    //所以后面加了一个判断下一个符号是否为‘.’&& text[pos]!='.'
                    while (this.in_array(text[pos], this.punct) && text[pos] != '.')
                    {
                        str = str + text[pos];
                        pos++;
                        if (pos >= length)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                char ch2 = ch;
                ch = '\0';
                str = "";
                bool flag = false;
                if (pos < length)
                {
                    while (flag || (text[pos] != ch2))
                    {
                        str = str + text[pos];
                        if (!flag)
                        {
                            flag = text[pos] == '\\';
                        }
                        else
                        {
                            flag = false;
                        }
                        pos++;
                        if (pos >= length)
                        {
                            break;
                        }
                    }
                }
                pos++;
                if (this.lasttok == TK.END_COMMAND)
                {
                    this.nl();
                }
                token = TK.STRING;
                return (ch2.ToString() + str + ch2.ToString());
            }
            token = TK.PUNCT;
            return str;
        }


        public VSBlockInfo GetBLOCK(string js)
        {
            Stack<TokenInfo> stack = new Stack<TokenInfo>();
            VSBlockInfo block = new VSBlockInfo();
            this.ins = new List<IN>();
            TokenInfo beforToken = null;
            string str;
            this.sb = new StringBuilder();
            this.lastword = "";
            this.lasttok = TK.EOF;
            this._in = IN.BLOCK;
            this.in_push(this._in);
            int pos = 0;
            TK token = TK.UNKNOWN;
            curreTokenLine = 1;
            while (true)
            {
                str = this.get_next_token(ref js, ref pos, out token);

                switch (token)
                {
                    case TK.START_BLOCK:
                        stack.Push(new TokenInfo(str, token, pos, beforToken, curreTokenLine));
                        break;
                    case TK.END_BLOCK:
                        if (pos == js.Length)
                        {
                            if (stack.Count > 0)
                            {
                                TokenInfo startBlockToken = stack.Peek();
                                block.startBlock = startBlockToken;
                                TokenInfo startToken = startBlockToken.lastToken;

                                bool isJson = false;
                                if (startBlockToken.lastToken.token == TK.PUNCT && startBlockToken.lastToken.text == ",")
                                {
                                    if (startBlockToken.lastToken.lastToken != null && startBlockToken.lastToken.lastToken.token == TK.END_BLOCK)
                                    {
                                        isJson = true;
                                    }
                                }

                                if (startToken.token == TK.NEW_LINE)
                                {
                                    startToken = startToken.lastToken;
                                }
                                int stratLine = startToken.line;
                                block.line = stratLine;
                                startToken = startToken.lastToken;
                                while (startToken.line == stratLine)
                                {
                                    block.line = startToken.line;
                                    if (startToken.line == 0)
                                    {
                                        break;
                                    }
                                    if (startToken.lastToken == null)
                                    {
                                        break;
                                    }
                                    startToken = startToken.lastToken;
                                    block.line = startToken.line + 1;
                                }

                                int lastIndex = 0;
                                int postion = startToken.pos;
                                for (int i = startToken.pos; i >= 0; i--)
                                {
                                    postion = i;
                                    if (whitespace.Contains(js[i]))
                                    {
                                        lastIndex++;
                                        if (js[i] == '\n')
                                        {
                                            break;
                                        }
                                        if (js[i] == '\r')
                                        {
                                            if (js[i + 1] == '\n')
                                            {
                                                postion = i + 1;
                                            }

                                            break;
                                        }
                                    }

                                }

                                //上一行语句的最后一个字符
                                string prevStatementLastWord = "";

                                int prevStatementPostion = postion;

                                if (postion > 0)
                                {
                                    int prevForStart = postion - 1;
                                    if (js[prevForStart] == '\r')
                                    {
                                        prevForStart = prevForStart - 1;
                                    }
                                    for (int i = prevForStart; i >= 0; i--)
                                    {
                                        prevStatementPostion = i;
                                        if (whitespace.Contains(js[i]))
                                        {
                                            lastIndex++;
                                            if (js[i] == '\n')
                                            {
                                                break;
                                            }
                                            if (js[i] == '\r')
                                            {
                                                if (js[i + 1] == '\n')
                                                {
                                                    prevStatementPostion = i + 1;
                                                }
                                                break;
                                            }
                                        }

                                    }


                                    block.prevStatementLastWord = prevStatementLastWord;
                                    for (int i = postion; i >= 0; i--)
                                    {
                                        if (!whitespace.Contains(js[i]))
                                        {
                                            if (js[i] != '\n' && js[i] != '\r')
                                            {
                                                prevStatementLastWord = js[i].ToString();
                                                block.prevStatementLastWord = prevStatementLastWord;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (postion == 0)
                                {
                                    postion = -1;
                                }
                                string result = js.Substring(postion + 1, js.Length - postion - 1);

                                int spaceCount = 0;
                                if (prevStatementPostion > 0)
                                {
                                    for (int i = prevStatementPostion + 1; i >= 0; i++)
                                    {
                                        if (js[i] == '\t')
                                        {
                                            spaceCount += 4;
                                        }
                                        else if (js[i] == ' ')
                                        {
                                            spaceCount += 1;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                int indent = spaceCount / 4;

                                string endChars = "{[";

                                if (prevStatementLastWord != "" && endChars.IndexOf(prevStatementLastWord) >= 0)
                                {
                                    indent++;
                                }
                                //if (isJson)
                                //{
                                //    indent++;
                                //}

                                block.indent = indent;

                                block.column = lastIndex;
                                block.text = result;
                                if (startBlockToken.lastToken != null)
                                {
                                    block.befor = startToken.token.ToString();
                                }
                                return block;
                            }
                            else
                            {
                                return block;
                            }
                        }
                        else
                        {
                            if (stack.Count > 0)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
                if (pos >= js.Length)
                {
                    break;
                }
                beforToken = new TokenInfo(str, token, pos, beforToken, curreTokenLine);
                this.lasttok = token;
                this.lastword = str.ToLower();
            }
            return block;
        }


        public void cleanCtl()
        {
            if (this.isInCtlBlock == false && nestedCtlList.Count > 0 && (lasttok == TK.NEW_LINE || lasttok == TK.END_COMMAND))
            {
                for (int i = 0; i < nestedCtlList.Count; i++)
                {
                    this.un_indent();
                }
                nestedCtlList.Clear();
            }
        }

        public void js_beautify(string js_source_text)
        {
            string str;
            this.sb = new StringBuilder();
            nestedCtlList = new List<string>();
            needRemoveFirstBlankLine = false;
            this.lastword = "";
            //this.indent = 0;
            this.lasttok = TK.EOF;
            this._in = IN.BLOCK;
            this.in_push(this._in);
            int pos = 0;

            int lastPos = 0;
            activeFormatedOffset = 0;
            int startSwitchBlockCount = 0;//switch语句时的{出现的总数
            isFindPos = false;

            TK uNKNOWN = TK.UNKNOWN;
        Next_token:
            str = this.get_next_token(ref js_source_text, ref pos, out uNKNOWN);
            if (str == null)
            {
                return;
            }
            if (activeOffset >= lastPos && activeOffset < pos)
            {
                offset = str.Length - (pos - activeOffset - 1);
                if (offset < 0)
                {
                    offset = 0;
                }
                isFindPos = true;
                this.activeFormatedOffset = sb.ToString().Length + offset;
            }
            else
            {
                isFindPos = false;
            }
            lastPos = pos;

            if (this.isDebugEnabled)
            {
                this.proto("[" + uNKNOWN.ToString() + "]>");
            }
            if (uNKNOWN == TK.EOF)
            {
                return;
            }
            //if (str == null)
            //{
            //    return;
            //}


            if (uNKNOWN != TK.WORD)
            {
                cleanCtl();
            }
            //if (uNKNOWN==TK.NEW_LINE)
            //{
            //    inEqualOp = false;
            //}

            switch (uNKNOWN)
            {
                case TK.UNKNOWN:
                    if ((str == "\n") && (this.lasttok == TK.WORD || this.lasttok == TK.START_CASE))
                    {
                        this.write(";", new string[0]);
                    }
                    this.write(str, new string[0]);
                    goto GetLastInfo;
                case TK.START_CASE:
                    if (this.lasttok != TK.START_BLOCK)
                    {
                        this.un_indent();
                    }
                    if (this.lasttok == TK.PUNCT)//|| this.lasttok == TK.END_BLOCK
                    {
                        this.do_indent();
                    }
                    this.nl();
                    this.write(str + " ", new string[0]);
                    this.case_push(CASE.CASE);
                    goto GetLastInfo;
                case TK.WORD:
                    {

                        //if (str == "else")
                        //{
                        //    this.isInCtlBlock = true;
                        //}

                        // if块内只有一句代码的情况。eg:if(a) exp;else expression; 
                        if (
                            this.isInCtlBlock && (InEnums(this.lasttok, TK.END_EXPR, TK.NEW_LINE, TK.COMMENT, TK.BLOCK_COMMENT) || this.lastword == "else")
                              || str == "else"
                            )
                        {
                            if (InEnums(this.lasttok, TK.COMMENT, TK.BLOCK_COMMENT))
                            {
                                removeLastNL();
                            }

                            if (str == "if" && lastword == "else")
                            {
                                this.write(" ", new string[0]);
                            }
                            else
                            {
                                this.do_indent();
                                if (this.control.Contains(str) && str != "else")
                                {
                                    nestedCtlList.Add(str);
                                    this.nl();
                                }
                                else
                                {
                                    if (str == "else")
                                    {
                                        this.un_indent();
                                        for (int i = nestedCtlList.Count - 1; i >= 0; i--)
                                        {
                                            if (nestedCtlList[i] == "if")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                this.un_indent();
                                                nestedCtlList.Remove(nestedCtlList[i]);
                                            }
                                        }
                                        this.nl();
                                    }
                                    else
                                    {
                                        this.nl();
                                        this.un_indent();
                                    }
                                }

                                this.isInCtlBlock = false;
                            }
                        }
                        else
                        {
                            cleanCtl();

                            if (lasttok == TK.NEW_LINE)
                            {
                                this.nl();
                            }
                            else if (lastword == ":" && _cases == CASE.CASE)
                            {
                                this.do_indent();
                                this.nl();
                            }
                            else if ((this.lasttok == TK.END_COMMAND) || (!(str.ToLower() == "break") && !(str.ToLower() == "else")))
                            {
                                #region MyRegion
                                if (this.lasttok == TK.END_BLOCK)
                                {
                                    if (str.ToLower() != "else")
                                    {
                                        //如果要在每个{}后面加一个空行，则取消掉注释
                                        //this.nl();
                                    }
                                    else
                                    {
                                        this.write(" ", new string[0]);
                                    }
                                }
                                if ((this.lasttok == TK.END_COMMAND) && (this._in == IN.BLOCK))
                                {
                                    this.nl();
                                }
                                else if ((this.lasttok == TK.END_COMMAND) && (this._in == IN.EXPR))
                                {
                                    this.write(" ", new string[0]);
                                }
                                else if (this.lasttok == TK.WORD)
                                {
                                    this.write(" ", new string[0]);
                                }
                                else if (this.lasttok == TK.START_BLOCK || this.lasttok == TK.END_BLOCK)
                                {
                                    this.nl();
                                }
                                else if (this.lasttok == TK.STRING)
                                {
                                    //2008-12-1去掉该段，会影响正则表达式：if (json.match(/^\d+$/g)) {} 
                                    //this.write(";", new string[0]);
                                    //this.nl();

                                    //正则表达式
                                    if (!lastword.EndsWith("/"))
                                    {
                                        //this.write(";", new string[0]);//补";"
                                        this.nl();
                                    }
                                }
                                else if (this.lasttok == TK.END_EXPR && this.lasttok == TK.START_SWITCH)
                                {
                                    if (Inners[0] == Inner.Flow)
                                    {
                                        this.do_indent();
                                        this.nl();
                                        this.un_indent();
                                    }
                                    else
                                    {
                                        this.nl();
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                if (lasttok != TK.EOF)
                                {
                                    this.nl();
                                }
                            }
                        }

                        //代码着色
                        List<string> list = new List<string>();
                        list.AddRange(new string[] { "function" });
                        if (list.Contains(str))
                        {
                            this.write(str, new string[] { "color:blue;" });
                        }
                        else
                        {
                            this.write(str, new string[0]);
                        }

                        if (control.Contains(str))
                        {
                            this.isInCtlBlock = true;
                        }
                        goto GetLastInfo;
                    }
                case TK.START_EXPR:
                    this.in_push(IN.EXPR);
                    if (this.lastword == "switch")
                    {
                        this.case_push(CASE.SWITCH);
                        startSwitchBlockCount = ins.Count;
                    }
                    else if (cases.Count > 0)
                    {
                        this.case_push(CASE.EXPR);
                    }
                    if (this.keyword.Contains(lastword))
                    {
                        //内部流程操作
                        this.Inners.Add(Inner.Flow);
                    }
                    else
                    {
                        //普通的运算
                        this.Inners.Add(Inner.Exp);
                    }
                    if (this.lasttok != TK.END_EXPR && this.lasttok != TK.START_SWITCH)
                    {
                        if (((this.lasttok != TK.WORD && this.lasttok != TK.START_CASE) && (this.lasttok != TK.START_EXPR)) && (this.lasttok != TK.PUNCT))
                        {
                            this.write(" ", new string[0]);
                        }
                        else if (((this.lastword == "if") || (this.lastword == "for")) || ((this.lastword == "while") || (this.lastword == "switch")))
                        {
                            if (addSpaceAfterCtrlWord)
                            {
                                this.write(" ", new string[0]);
                            }

                        }
                        break;
                    }
                    if ((str != "[") && (str != "("))
                    {
                        this.nl();
                    }
                    break;

                case TK.START_SWITCH:
                case TK.END_EXPR:
                    this.write(str, new string[0]);
                    this.in_pop();
                    if (cases.Count > 0)
                    {
                        case_pop();
                    }
                    goto GetLastInfo;

                case TK.START_BLOCK:
                    this.isInCtlBlock = false;
                    this.in_push(IN.BLOCK);
                    if (this.lasttok == TK.START_SWITCH)
                    {
                        case_push(CASE.BLOCK);
                    }
                    else if (_cases != CASE.None)
                    {
                        case_push(CASE.CASE_BLOCK);
                    }
                    //if (this.lasttok != TK.PUNCT)
                    //{
                    //    this.write(" ", new string[0]);
                    //}

                    //jrt,加入代码风格,如果是return {...}这种返回的语句，“{”不可以换到下一行
                    if (this.lastword == "return")
                    {
                        this.write(" ");
                    }
                    else if (this.lasttok != TK.EOF
                        && (this.lasttok == TK.PUNCT
                            || (this.lasttok != TK.COMMENT && this.style == CodeStyle.MS)
                        ))
                    {
                        this.nl();
                    }

                    this.write("{", new string[0]);
                    this.do_indent();
                    goto GetLastInfo;

                case TK.END_BLOCK:
                    //if (lasttok != TK.EOF)
                    //{
                    if (this.lasttok != TK.END_EXPR && this.lasttok != TK.START_SWITCH)
                    {
                        if (this._cases == CASE.BLOCK)
                        {
                            this.un_indent();
                            if (startSwitchBlockCount == this.ins.Count||this.lasttok != TK.END_BLOCK)
                            {
                                this.un_indent();
                            }
                            
                            this.nl();
                        }
                        else if (this.lasttok == TK.END_BLOCK)
                        {
                            this.un_indent();
                            this.nl();
                        }
                        else if (this.lasttok == TK.START_BLOCK)
                        {
                            removeLastNL();
                            removeLastNL(1);
                            this.write("{", new string[0]);
                            this.un_indent();
                        }
                        else
                        {
                            this.un_indent();
                            if (lasttok == TK.COMMENT)
                            {
                                removeLastNL();
                            }
                            if (lasttok == TK.EOF)
                            {
                                needRemoveFirstBlankLine = true;
                            }
                            
                            this.nl();
                        }
                    }
                    else
                    {
                        if (this._cases == CASE.BLOCK)
                        {
                            if (this.lasttok != TK.END_BLOCK && this.lasttok != TK.NEW_LINE && this.lasttok != TK.END_COMMAND)
                            {
                                this.un_indent();
                            }
                        }
                        //jrt
                        this.un_indent();
                        this.nl();
                        //this.un_indent();
                    }
                    

                    this.write(str, new string[0]);
                    this.in_pop();
                    if (_cases != CASE.None)
                    {
                        case_pop();
                    }
                    goto GetLastInfo;

                case TK.END_COMMAND:
                    inEqualOp = false;
                    this.write(";", new string[0]);
                    goto GetLastInfo;

                case TK.STRING:
                    if (this.lasttok != TK.START_BLOCK)
                    {
                        if (this.lasttok == TK.WORD)
                        {
                            this.write(" ", new string[0]);
                        }
                    }
                    else
                    {
                        this.nl();
                    }
                    this.write(str, new string[] { "color:red;" });
                    goto GetLastInfo;

                case TK.BLOCK_COMMENT:
                    if (this.lasttok != TK.EOF &&
                        this.lasttok != TK.COMMENT &&
                        (this.sb.Length > 0))
                    {
                        if (!(lastword == "," && this._in == IN.BLOCK))
                        {
                            if (this.isInCtlBlock && (InEnums(this.lasttok, TK.END_EXPR, TK.NEW_LINE) || this.lastword == "else"))
                            {
                                this.do_indent();
                                this.nl();
                                this.un_indent();
                            }
                            else
                            {
                                this.nl();
                            }

                        }
                    }
                    this.write(str, new string[] { "color:green;" });
                    this.nl();
                    goto GetLastInfo;

                case TK.COMMENT:

                    //if (str.StartsWith(regionPair.Key))
                    //{
                    //    this.nl();
                    //}
                    //bool needNewLine = true;
                    if (this.lasttok != TK.COMMENT && this.lasttok != TK.EOF && this.lasttok != TK.END_EXPR && this.lastword != "else")
                    {
                        if (lastword == ":" && _cases == CASE.CASE)
                        {
                            this.do_indent();
                            this.nl();
                        }
                        else if (this.isInCtlBlock && (InEnums(this.lasttok, TK.END_EXPR, TK.NEW_LINE) || this.lastword == "else"))
                        {
                            this.do_indent();
                            this.nl();
                            this.un_indent();
                        }
                        else if (!(lastword == "," && this._in == IN.BLOCK))
                        {
                            this.nl();
                        }

                    }

                    this.write(str, new string[] { "color:green;" });
                    this.nl();

                    //if (str.StartsWith(regionPair.Value))
                    //{
                    //    this.n();
                    //}
                    goto GetLastInfo;

                case TK.PUNCT:
                    {
                        //是否在左、右添加空格的标记
                        bool leftFlag = true;
                        bool rightFlag = true;
                        if (str != ",")
                        {
                            if (str == "=")
                            {
                                inEqualOp = true;
                            }
                            if (str == "?" && cases.Contains(CASE.CASE))
                            {
                                case_push(CASE.EXPR);
                            }

                            //case default:的情况
                            if (str == ":")
                            {
                                //inEqualOp = false;
                                if (this.lasttok == TK.START_CASE)
                                {
                                    leftFlag = false;
                                }
                            }

                            if (this.lasttok == TK.PUNCT)
                            {
                                leftFlag = false;
                                rightFlag = false;
                            }
                            else if (str == ".")
                            {
                                leftFlag = false;
                                rightFlag = false;
                            }
                            //else
                            //{
                            //    lasttok = this.lasttok;
                            //}

                            if (leftFlag)
                            {
                                this.write(" ", new string[0]);
                            }
                            this.write(str, new string[0]);
                            if (rightFlag)
                            {
                                this.write(" ", new string[0]);
                            }


                        }
                        //08-11-19 增加对json数据的处理
                        else if (this._in == IN.BLOCK && inEqualOp == false)
                        {
                            this.write(",", new string[0]);
                            this.nl();
                        }
                        else if (this._in != IN.EXPR)
                        {
                            this.write(", ", new string[0]);
                            inEqualOp = false;
                        }
                        else
                        {
                            this.write(", ", new string[0]);
                        }

                        goto GetLastInfo;
                    }
                default:
                    goto GetLastInfo;
            }
            this.write(str, new string[0]);
        GetLastInfo:
            if (this.lasttok == TK.END_EXPR && this.lasttok == TK.START_SWITCH)
                Inners.RemoveAt(Inners.Count - 1);

            if (lastword == ":")
            {
                if (_cases == CASE.EXPR)
                {
                    case_pop();
                }
            }
            this.lasttok = uNKNOWN;
            this.lastword = str.ToLower();
            goto Next_token;
        }

        #region 字符操作 内部方法
        private List<char> make_array(string s)
        {
            List<char> list = new List<char>();
            if (!string.IsNullOrEmpty(s))
            {
                foreach (char ch in s)
                {
                    list.Add(ch);
                }
            }
            return list;
        }

        //jrt
        private List<string> make_list(string s)
        {
            List<string> list = new List<string>();
            string[] strArry = s.Split(',');
            foreach (string str in strArry)
            {
                list.Add(str);
            }
            return list;
        }

        private bool in_array(char c, List<char> a)
        {
            return (((a != null) && (a.Count != 0)) && a.Contains(c));
        }

        private void in_pop()
        {
            if (this.ins.Count > 0)
            {
                this.ins.RemoveAt(this.ins.Count - 1);
            }
            if (this.ins.Count > 0)
            {
                this._in = this.ins[this.ins.Count - 1];
            }
        }

        private void in_push(IN where)
        {
            this.ins.Add(where);
            this._in = where;
        }

        private void case_pop()
        {
            if (this.cases.Count > 0)
            {
                this.cases.RemoveAt(this.cases.Count - 1);
            }
            if (this.cases.Count > 0)
            {
                this._cases = this.cases[this.cases.Count - 1];
            }
            else
            {
                this._cases = CASE.None;
            }
        }

        private void case_push(CASE where)
        {
            this.cases.Add(where);
            this._cases = where;
        }


        private void nl()
        {
            nl(true);
        }

        /// <summary>
        /// 输出回车和制表符
        /// </summary>
        /// <param name="needBR">是否需要回车换行</param>
        private void nl(bool needBR)
        {
            if (this.isHtmlOutput)
            {
                if (needBR)
                {
                    this.sb.Append("<br>");
                }
                this.sb.Append(this.str_repeat("&nbsp;&nbsp;&nbsp;&nbsp;", this.indent));
            }
            else
            {
                if (needBR)
                {
                    this.write(false, "\r\n", new string[0]);
                }
                this.write(false, this.str_repeat(identStr, this.indent), new string[0]);
            }
        }

        /// <summary>
        /// 去掉最后一行的换行和缩进
        /// </summary>
        /// <param name="penultimateIndex">倒数第几个字符串开始</param>
        private void removeLastNL(int penultimateIndex)
        {
            string code = this.output;
            int lastIndex = 0;
            for (int i = code.Length - (penultimateIndex + 1); i >= 0; i--)
            {
                if (whitespace.Contains(code[i]))
                {
                    lastIndex++;
                    if (code[i] == '\r')
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            if (code.Length > 0)
            {
                int length = lastIndex + penultimateIndex;
                sb.Remove(code.Length - length, length);
            }
        }

        /// <summary>
        /// 去掉最后一行的换行和缩进
        /// </summary>
        private void removeLastNL()
        {
            removeLastNL(0);
        }


        /// <summary>
        /// 去掉最后一行的换行和缩进
        /// </summary>
        /// <param name="penultimateIndex">倒数第几个字符串开始</param>
        public StringBuilder removeFristNL(StringBuilder code)
        {
            //string code = this.output;
            int lastIndex = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (whitespace.Contains(code[i]))
                {
                    lastIndex++;

                    char secondChar='\0';
                    if ((i+1) < code.Length)
                    {
                        secondChar = code[i + 1];
                    }
                    if (code[i] == '\n' || (code[i]=='\r'&&secondChar!='\n'))
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            if (code.Length > 0)
            {
                int length = lastIndex;
                code=code.Remove(0, length);
            }
            return code;
        }

        private void proto(string s)
        {
            if (this.isHtmlOutput)
            {
                this.sb.Append(string.Format("<span style=\"{0}\">{1}</span>", "color:#eeeeee;", HttpUtility.HtmlEncode(s)));
            }
            else
            {
                this.sb.Append(s);
            }
        }

        private string str_repeat(string s, int count)
        {
            StringBuilder builder = new StringBuilder(s.Length * count);
            for (int i = 0; i < count; i++)
            {
                builder.Append(s);
            }
            return builder.ToString();
        }

        private void do_indent()
        {
            this.indent++;
        }

        private void un_indent()
        {
            if (this.indent > 0)
            {
                this.indent--;
            }
        }

        private void write(string s, params string[] style)
        {
            write(true, s, style);
        }

        private void write(bool findPos, string s, params string[] style)
        {
            if (this.isHtmlOutput)
            {
                if (style.Length > 0)
                {
                    this.sb.Append(string.Format("<span style=\"{0}\">{1}</span>", style[0], HttpUtility.HtmlEncode(s)));
                }
                else
                {
                    this.sb.Append(HttpUtility.HtmlEncode(s));
                }
            }
            else
            {
                if (this.isFindPos && findPos)
                {
                    //sb.Replace("\r\n", "\n").ToString().Length + offset;
                    this.activeFormatedOffset = sb.ToString().Replace("\r\n", "\n").Length + offset;
                    //isFindPos = false;
                }
                this.sb.Append(s);
            }
        }

        private bool InEnums(Enum en, params Enum[] enums)
        {
            foreach (Enum e in enums)
            {
                if (e.Equals(en))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 公共属性
        public bool IsDebugEnabled
        {
            get
            {
                return this.isDebugEnabled;
            }
            set
            {
                this.isDebugEnabled = value;
            }
        }


        public CodeStyle Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }

        public bool IsHtmlOutput
        {
            get
            {
                return this.isHtmlOutput;
            }
            set
            {
                this.isHtmlOutput = value;
            }
        }

        public string output
        {
            get
            {
                if (this.sb != null)
                {
                    return this.sb.ToString();
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 缩进字符串
        /// </summary>
        public string IdentStr
        {
            get { return identStr; }
            set { identStr = value; }
        }

        public int Indent
        {
            get { return indent; }
            set { indent = value; }
        }

        private KeyValuePair<string, string> regionPair = new KeyValuePair<string, string>("//##", "//#end");
        //区域块对，//#
        public KeyValuePair<string, string> RegionPair
        {
            get
            {
                return regionPair;
            }
            set
            {
                regionPair = value;
            }
        }

        private bool addSpaceAfterCtrlWord;

        /// <summary>
        /// 是否在控制语句后面添加空格
        /// <remarks>
        /// 例如if () switch ()
        /// </remarks>
        /// </summary>
        public bool AddSpaceAfterCtrlWord
        {
            get { return addSpaceAfterCtrlWord; }
            set { addSpaceAfterCtrlWord = value; }
        }

        private BlankLineOption removeBlankLine;

        /// <summary>
        /// 是否移除多余的空行
        /// </summary>
        public BlankLineOption RemoveBlankLine
        {
            get { return removeBlankLine; }
            set { removeBlankLine = value; }
        }

        private int curreTokenLine = 1;
        public int CurreTokenLine
        {
            get { return curreTokenLine; }
        }
        int maxBlankLine = 2;
        /// <summary>
        /// 最大空行数
        /// </summary>
        public int MaxBlankLine
        {
            get { return maxBlankLine; }
            set
            {
                if (value < 2)
                {
                    //throw new Exception("最大空行数不能小于2");
                }
                else
                {
                    maxBlankLine = value;
                }
            }
        }

        int keepBlankLineCount = 1;
        /// <summary>
        /// 保留的空行数
        /// </summary>
        public int KeepBlankLineCount
        {
            get
            {
                return keepBlankLineCount;
            }
            set
            {
                if (value < 1)
                {
                    //throw new Exception("保留的空行数不能小于1");
                }
                else
                {
                    keepBlankLineCount = value;
                }
            }
        }

        public int activeOffset = 0;
        public int activeFormatedOffset = 0;
        public int offset = -1;
        public bool needRemoveFirstBlankLine;//是否需要在第一行添加制表符
        #endregion

        #region 私有字段
        /// <summary>
        /// 是否已经经过指定的位置，主要用于VS的格式化保持当前光标的位置
        /// </summary>
        private bool isFindPos = false;

        private IN _in;
        private int indent = 0;

        private List<IN> ins = new List<IN>();
        private bool isDebugEnabled;
        private bool isHtmlOutput;
        private CodeStyle style;
        private TK lasttok;
        private string lastword;
        private List<char> punct;
        private StringBuilder sb;
        private List<char> whitespace;
        private List<char> wordchar;
        private List<CASE> cases = new List<CASE>();
        private List<Inner> Inners = new List<Inner>();
        private List<string> keyword;
        private List<string> control;
        private CASE _cases = CASE.None;
        private string identStr = "\t";

        private bool isInCtlBlock;//是否在控制语句内
        List<string> nestedCtlList = new List<string>();//连续嵌套控制块的总数
        bool inEqualOp = false;
        #endregion

    }
}

