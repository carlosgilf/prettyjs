// Guids.cs
// MUST match guids.h
using System;

namespace Jrt.PrettyJs
{
    static class GuidList
    {
        public const string guidPrettyJsPkgString = "60f39d2e-2efa-4d31-8d3d-e4e9c471cff5";
        public const string guidPrettyJsCmdSetString = "9c0dac38-df57-4b87-a49a-74abbbd82b35";


        public static readonly Guid guidPrettyJsCmdSet = new Guid(guidPrettyJsCmdSetString);
    };
}