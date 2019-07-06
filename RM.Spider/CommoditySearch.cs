using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.Spider
{
    public class CommoditySearch 
    {


        public void Get()
        {
            var url = string.Empty;
            string html = HttpHelper.DownloadUrl(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            string pageNumberPath = @"";

            HtmlNode pageNumberNode = doc.DocumentNode.SelectSingleNode(pageNumberPath);










        }
    }

    public static class HttpHelper
    {
        public static string DownloadUrl(string url)
        {
            return string.Empty;
        }

    }
}
