using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTips.Models
{
	public class ToolTipHelper
	{
		public string HtmlId { get; set; } = string.Empty;
		//public HelperType helperType { get; set; } = HelperType.Anchored;
		public string HoveredContent { get; set; } = string.Empty;
		public string DetailedContent { get; set; } = string.Empty;
		public override string ToString()
		{
			return $"ok Id:{HtmlId}, ContentWhenHovered:{HoveredContent}";
		}
	}
	public enum HelperType{
		Anchored,
		Introduction
	}
	public class PageHelpers
	{
		public string PageName { get; set; }= string.Empty;
		public ToolTipHelper[] helpers;
	}
}
