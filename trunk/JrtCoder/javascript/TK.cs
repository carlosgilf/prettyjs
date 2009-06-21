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
namespace JrtCoder
{
    using System;

    public enum TK
    {
        UNKNOWN,
        WHITESPACE,
        WORD,
        START_EXPR,
        END_EXPR,
        START_BLOCK,
        END_BLOCK,
        END_COMMAND,
        EOF,
        STRING,
        BLOCK_COMMENT,
        COMMENT,
        START_SWITCH,
        END_SWITCH,
        START_CASE,
        END_CASE,
        /// <summary>
        /// 标点符号的操作
        /// </summary>
        PUNCT,
        NEW_LINE,
    }

    public class TokenInfo
    {
        public string text;
        public int pos;
        public TK token;
        public TokenInfo()
        {

        }

        public TokenInfo(string _text, TK _token, int _pos, TokenInfo _lastToken, int _line)
        {
            this.text = _text;
            this.token = _token;
            this.pos = _pos;
            this.lastToken = _lastToken;
            this.line = _line;
        }
        public int line = 0;
        public TokenInfo lastToken;
    }

    public class VSBlockInfo
    {
        public string text = "";
        public int column = 0;
        public int line = 0;
        public int indent = 0;
        public string befor = "";
        public string prevStatementLastWord = "";
        /// <summary>
        /// 左大括号{的token信息
        /// </summary>
        public TokenInfo startBlock;
    }
}
