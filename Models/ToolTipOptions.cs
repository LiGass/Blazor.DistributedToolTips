using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedToolTips.Models
{
	public class ToolTipOptions
	{
		public string ResourcePath { get; set; } = string.Empty;
		public bool UsesMultipleFiles { get; private set; } = false;
		public bool UsesResources { get => ResourcePath != string.Empty; } 
		public ToolTipOptions(){}
		public void AddResourceLocation(string resourcePath){
			
			string res = (resourcePath[0]=='/') ?resourcePath: $"/{resourcePath}";
			res = $"{Environment.CurrentDirectory}{res}";
			if (System.IO.File.Exists(ResourcePath))
			{
				UsesMultipleFiles = false;
				ResourcePath = res;
				return;
			}
			if(System.IO.Directory.Exists(ResourcePath))
			{
				UsesMultipleFiles = true;
				ResourcePath = res;
				return;
			}
		}
	}
}
