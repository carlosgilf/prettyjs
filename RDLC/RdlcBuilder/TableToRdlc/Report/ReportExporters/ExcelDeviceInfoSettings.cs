using System;
using System.Collections.Generic;
using System.Text;
using Common.Report.Model;

namespace Common.Report.Exporting
{
	/// <summary>
	/// Device information settings for rendering in Microsoft Excel format.
	/// <see cref="http://msdn.microsoft.com/en-us/library/ms155069.aspx"/>
	/// </summary>
	public class ExcelDeviceInfoSettings : BaseDeviceInfoSettings
	{
		public const string FORMAT_XLS = "XLS";

		public ExcelDeviceInfoSettings()
			: base(FORMAT_XLS)
		{
		}

		#region Properties

		private bool? omitDocumentMap;
		public bool? OmitDocumentMap
		{
			get { return omitDocumentMap; }
			set { omitDocumentMap = value; }
		}

		private bool? omitFormulas;
		public bool? OmitFormulas
		{
			get { return omitFormulas; }
			set { omitFormulas = value; }
		}

		private Size? removeSpace;
		public Size? RemoveSpace
		{
			get { return removeSpace; }
			set { removeSpace = value; }
		}

		private bool? simplePageHeaders;
		public bool? SimplePageHeaders
		{
			get { return simplePageHeaders; }
			set { simplePageHeaders = value; }
		}

		#endregion

		public override string ToString()
		{
			string deviceInfoXml = "<DeviceInfo>" +
				"<OutputFormat>" + OutputFormat + "</OutputFormat>" +
				((OmitDocumentMap.HasValue) ? "<OmitDocumentMap>" + OmitDocumentMap.Value.ToString() + "</OmitDocumentMap>" : String.Empty) +
				((OmitFormulas.HasValue) ? "<OmitFormulas>" + OmitFormulas.Value.ToString() + "</OmitFormulas>" : String.Empty) +
				((RemoveSpace.HasValue) ? "<RemoveSpace>" + RemoveSpace.Value.ToString() + "</RemoveSpace>" : String.Empty) +
				((SimplePageHeaders.HasValue) ? "<SimplePageHeaders>" + SimplePageHeaders.Value.ToString() + "</SimplePageHeaders>" : String.Empty) +
			 "</DeviceInfo>";

			return deviceInfoXml;
		}
	}


    /// <summary>
    /// Device information settings for rendering in Microsoft Excel format.
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms155069.aspx"/>
    /// </summary>
    public class WordDeviceInfoSettings : BaseDeviceInfoSettings
    {
        public const string FORMAT_WORD = "DOC";

        public WordDeviceInfoSettings()
            : base(FORMAT_WORD)
        {
        }

        #region Properties

        public enum AutoFitOptions
        {
            True,
            False,
            Never,
            Default
        }

        private AutoFitOptions autoFit = AutoFitOptions.Default;
        public AutoFitOptions AutoFit
        {
            get { return autoFit; }
            set { autoFit = value; }
        }

        private bool? expandToggles;
        public bool? ExpandToggles
        {
            get { return expandToggles; }
            set { expandToggles = value; }
        }

        private bool? fixedPageWidth;
        public bool? FixedPageWidth
        {
            get { return fixedPageWidth; }
            set { fixedPageWidth = value; }
        }


        private bool? omitHyperlinks;
        public bool? OmitHyperlinks
        {
            get { return omitHyperlinks; }
            set { omitHyperlinks = value; }
        }

        private bool? omitDrillthroughs;
        public bool? OmitDrillthroughs
        {
            get { return omitDrillthroughs; }
            set { omitDrillthroughs = value; }
        }

        #endregion

        public override string ToString()
        {
            string deviceInfoXml = "<DeviceInfo>" +
                "<OutputFormat>" + OutputFormat + "</OutputFormat>" +

                "<AutoFit>" + AutoFit.ToString() + "</AutoFit>" +
                ((ExpandToggles.HasValue) ? "<OmitDocumentMap>" + ExpandToggles.Value.ToString() + "</OmitDocumentMap>" : String.Empty) +
                ((FixedPageWidth.HasValue) ? "<OmitFormulas>" + FixedPageWidth.Value.ToString() + "</OmitFormulas>" : String.Empty) +
                ((OmitHyperlinks.HasValue) ? "<OmitFormulas>" + OmitHyperlinks.Value.ToString() + "</OmitFormulas>" : String.Empty) +
                ((OmitDrillthroughs.HasValue) ? "<OmitFormulas>" + OmitDrillthroughs.Value.ToString() + "</OmitFormulas>" : String.Empty) +

             "</DeviceInfo>";

            return deviceInfoXml;
        }
    }
}
