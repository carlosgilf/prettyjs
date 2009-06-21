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

namespace JrtCoder
{
    public class Utility
    {

    }

    public class ExceptionExtensions
    {
        public static String ToFullStackTrace(Exception ex, Int32 count)
        {
            if (ex == null)
                throw new ArgumentException();
            StringBuilder sb = new StringBuilder();
            sb.Append(ex.StackTrace);

            int innerReferences = 0;
            Exception inner = ex.InnerException;
            while (inner != null && innerReferences < count)
            {
                sb.Insert(0, inner.StackTrace);
                inner = inner.InnerException;
                innerReferences++;
            }
            return sb.ToString();
        }

        public static String ToFullStackTrace(Exception ex)
        {
            return ToFullStackTrace(ex, 50);
        }
    }
}
