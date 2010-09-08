#region Disclaimer/Info
/*
 * PrettyJs  - http://jintan.cnblogs.com
 * Copyright (c) ½ùÈçÌ¹.  All rights reserved.
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

    internal enum State
    {
        None,
        Start,
        End
    }

    internal enum IN
    {
        EXPR,
        BLOCK,
        Error
    }

    public enum Inner
    {
        Flow,
        Exp,
    }

    public enum CASE
    {
        SWITCH,
        EXPR,
        BLOCK,
        CASE_BLOCK,
        CASE,
        None,

    }

    public enum CodeStyle
    {
        MS,
        C
    }


}

