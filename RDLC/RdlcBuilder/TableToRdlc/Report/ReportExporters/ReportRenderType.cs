using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Report.Exporting
{
	/// <summary>
	/// List of supported export rendering types (in LocalMode)
	/// </summary>
	public class ReportRenderType
	{
		public const string Excel = "Excel";
		public const string PDF = "PDF";
		public const string IMAGE = "IMAGE";
        public const string WORD = "WORD";
	}
}
