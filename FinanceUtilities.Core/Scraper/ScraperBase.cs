using FinanceUtilities.Data;
using HtmlAgilityPack;
using System.Net.Http;
using System.Text;
using System.Web;

namespace FinanceUtilities.Core
{
    public class ScraperBase : ServiceBase
    {
        private HtmlWeb hw;

        public ScraperBase(IFinanceContext context) : base(context)
        {
            hw = new HtmlWeb();
        }

        public string GetMarkup(string url, string xPathQuery)
        {
            string rawMarkup = string.Empty;
            
            HtmlDocument page = hw.Load(FormatLink(url));
            var root = page.DocumentNode;

            var node = root.SelectSingleNode(xPathQuery);
            if (node != null && !string.IsNullOrEmpty(node.OuterHtml))
            {
                rawMarkup = node.OuterHtml;
            }
            //if selector does not resolve properly get the body
            else
            {
                node = root.SelectSingleNode("//body");
                if(node != null && !string.IsNullOrEmpty(node.OuterHtml))
                {
                    rawMarkup = node.OuterHtml;
                }
                //if body does not resolve get the whole page
                else
                {
                    rawMarkup = root.InnerHtml;
                }
            }

            return rawMarkup;
        }

        private string FormatLink(string url)
        {
            var urlDecoded = HttpUtility.UrlDecode(url);
            if(urlDecoded.Contains('#'))
            {
                var pageAnchor = urlDecoded.Substring(urlDecoded.IndexOf('#')+1);
                urlDecoded = urlDecoded.Substring(0, urlDecoded.IndexOf('#'));
            }
            return urlDecoded;
        }
    }
}
