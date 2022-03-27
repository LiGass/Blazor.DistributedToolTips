using System.Collections.Generic;
using System.Linq;

namespace DistributedToolTips.Models
{
	public static class Extensions
	{
		//public static Task<IEnumerable<ToolTipHelper>> GetHelpers(this ToolTipOptions options, string currentPage)
		//{
		//	string filePath = options.GetHelpersFilePath(currentPage);
		//	if(options.UsesMultipleFiles)
		//	{
		//		try{
		//			var result = JsonConvert.DeserializeObject<IEnumerable<ToolTipHelper>>(filePath);
		//			return result;
		//		}
		//		catch
		//		{
		//			throw new Exception("Could not Deserialize the helpers");
		//		}
		//	}
		//	return null;
		//}
		public static string GetHelpersFilePath(this ToolTipOptions options, string currentPage)
		{
			if (!options.UsesMultipleFiles)
			{
				return options.ResourcePath;
			}
			return $"{options.ResourcePath}/{NormalizePageName(currentPage)}.json";
		}
		private static string NormalizePageName(string pageName)
		{
			return pageName.Replace("/", ".");
		}
	}
	public static class NavigationManagerExtension
	{
		public static string[] ParseUri(this string pageurl)
		{
			string pageurlwithoutquery = pageurl.Split("/[?#]/")[0];
			return pageurlwithoutquery.Split('/');
		}
		
		// TODO : /!\ Not valid for wasm not hosted
		public static IEnumerable<string> ListAvailableFiles(this string baseFolder)
		{
			IEnumerable<string> paths;
			IEnumerable<string> subfolder = System.IO.Directory.GetDirectories(baseFolder).ToList();
			IEnumerable<string> files = System.IO.Directory.GetFiles(baseFolder);
			paths = files.Concat(subfolder);
			return paths;
		}
	}
}
