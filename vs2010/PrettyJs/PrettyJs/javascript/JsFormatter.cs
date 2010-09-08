using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using v8sharp;


namespace Jrt.PrettyJs
{
    public class JsFormatter
    {
        V8Engine engine = V8Engine.Create();

        FormatParms param = new FormatParms();
        string reuslt = "";
        public JsFormatter()
        {
            engine.RegisterFunction("printmsg", new Action<string>(message => { reuslt = message; }));
        }

        public string Format(string text)
        {
            param.code = text;
            engine.Register<FormatParms>("parms", param);
            string js = Resources.beautify;
            var script = engine.Compile(js + @";var result=js_beautify(parms.code,parms);printmsg(result);");
            engine.Execute(script);
            return reuslt;
        }
    }


    public class FormatParms
    {
        int indentSize = 4;
        string indentChar = " ";


        public string code
        {
            get;
            set;
        }

        public int indent_size
        {
            get
            {
                return indentSize;
            }
            set
            {
                indentSize = value;
            }
        }

        public string indent_char
        {
            get
            {
                if (indent_size==1)
                {
                    indentChar = "\t";
                }
                return indentChar;
            }
            set
            {
                indentChar = value;
            }
        }

        public bool preserve_newlines
        {
            get;
            set;
        }

        public bool braces_on_own_line
        {
            get;
            set;
        }

        public bool keep_array_indentation
        {
            get;
            set;
        }

        public bool space_after_anon_function
        {
            get;
            set;
        }
    }
}
