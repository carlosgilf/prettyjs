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
using System.Collections.Generic;
using System.Text;
using AMS.Profile;
using System.IO;

namespace Jrt.PrettyJs
{
    [Serializable]
    public class CodeOption
    {
        private CodeStyle style = CodeStyle.MS;

        /// <summary>
        /// 代码风格
        /// </summary>
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

        /// <summary>
        /// 缩进字符串
        /// </summary>
        public string IdentStr
        {
            get
            {
                if (this.identUseTab)
                {
                    return "\t";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(' ', identNumber);
                    return sb.ToString();
                }
            }
        }

        private bool identUseTab = true;
        public bool IdentUseTab
        {
            get { return identUseTab; }
            set { identUseTab = value; }
        }

        private int identNumber = 4;
        public int IdentNumber
        {
            get { return identNumber; }
            set { identNumber = value; }
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

        private BlankLineOption removeBlankLine= BlankLineOption.None;

        /// <summary>
        /// 是否移除多余的空行
        /// </summary>
        public BlankLineOption RemoveBlankLine
        {
            get { return removeBlankLine; }
            set { removeBlankLine = value; }
        }

        bool autoCompleteBracket;
        /// <summary>
        /// 自动完成{块的内容
        /// </summary>
        public bool AutoCompleteBracket
        {
            get { return autoCompleteBracket; }
            set { autoCompleteBracket = value; }
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

        public override string ToString()
        {
            return "IdentStr:" + IdentStr + "\r\nStyle:" + style.ToString();
        }

        public static string GetSettingsPath()
        {
            string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            tempPath = tempPath + "\\JrtCoder\\";
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
            return tempPath + "config.xml";
        }

        public void Save()
        {
            Xml profile = new Xml(GetSettingsPath());
            profile.SetValue(SECTION, "Style", style.ToString());
            profile.SetValue(SECTION, "IdentUseTab", identUseTab);
            profile.SetValue(SECTION, "IdentNumber", identNumber);
            profile.SetValue(SECTION, "AddSpaceAfterCtrlWord", addSpaceAfterCtrlWord);
            profile.SetValue(SECTION, "AutoCompleteBracket", autoCompleteBracket);

            profile.SetValue(BLACKLINE, "RemoveBlankLine", (int)removeBlankLine);
            profile.SetValue(BLACKLINE, "KeepBlankLineCount", (int)KeepBlankLineCount);
            profile.SetValue(BLACKLINE, "MaxBlankLine", (int)MaxBlankLine);
        }

        public void Load()
        {
            Xml profile = new Xml(GetSettingsPath());

            string style_xml = profile.GetValue(SECTION, "Style", "MS");

            CodeStyle styleGet = (CodeStyle)Enum.Parse(typeof(CodeStyle), style_xml);
            style = styleGet;
            identUseTab = profile.GetValue(SECTION, "IdentUseTab", true);
            identNumber = profile.GetValue(SECTION, "IdentNumber", 4);
            addSpaceAfterCtrlWord = profile.GetValue(SECTION, "AddSpaceAfterCtrlWord", false);
            autoCompleteBracket = profile.GetValue(SECTION, "AutoCompleteBracket", false);
            try
            {
                removeBlankLine = (BlankLineOption)profile.GetValue(BLACKLINE, "RemoveBlankLine", 1);
            }
            catch (System.Exception e)
            {
            	
            }
            keepBlankLineCount = profile.GetValue(BLACKLINE, "KeepBlankLineCount", 2);
            MaxBlankLine = profile.GetValue(BLACKLINE, "MaxBlankLine", 2);
            
        }

        const string SECTION = "Javascript";
        const string BLACKLINE = "BlankLine";

    }

    public enum BlankLineOption
    {
        
        RemoveOtiose=1,
        RemoveAll=2,
        None=3,
    }
}
