using FinanceUtilities.Data;
using FinanceUtilities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinanceUtilities.Core
{
    public class LoanScraperService : ScraperBase, ILoanScraperService
    {
        private Dictionary<string, string> websiteXpathQueries = new Dictionary<string, string>()
        {
            { "halkbank", "//div[@class='ns-inner']" },
            { "kb" , "//div[@id='printableContent']" },
            { "nlb", "//div[@class=\"contents\"]" },
            { "ohridskabanka", "//div[@id='ns-content']" },
            { "silkroadbank", "//div[@style='padding: 0px; background: linear-gradient( to bottom, white 85%, #d1cfdc);']" },
            { "eurostandard", "//div[@id='карактеристики-на-кредитот']" },
            { "capitalbank", "//div[@class='section-left']" },
            { "stb", "//div[@class='tab-content']" },
            { "sparkasse", "//main[@id='content']" },
            { "stbbt", "//div[@id='ns-content']" },//"//div[@rel='карактеристики']" },
            { "ttk", "//body" },
            { "unibank", "//div[@class='main']" },
            { "procreditbank", "//body" },
            { "pcb", "//body" },
            { "ccbank", "//div[@class='inside_left']" }
        };

        public LoanScraperService(IFinanceContext context) : base(context)
        {
        }

        public void LoanUpdateDone(int loanId)
        {
            var loan = _context.LoanProducts.FirstOrDefault(c => c.Id == loanId);

            loan.Markup = loan.NewMarkup;
            loan.HasMarkupChanges = false;

            _context.SaveChanges();
        }

        public void ScrapeAllLoanProducts()
        {
            foreach (var loan in _context.LoanProducts.ToList())
            {
                try
                {
                    UpdateLoanMarkup(loan);
                    Console.WriteLine(string.Format("Kredit: {0} e uspesno prevzemen", loan.Id));
                }
                catch
                {
                    Console.WriteLine(string.Format("Kredit: {0} nastana greska!!!!!!!!!", loan.Id));
                }
            }
            _context.SaveChanges();
        }

        public bool UpdateLoanMarkup(int loanId)
        {
            //TO DO: use the loan service
            var loan = _context.LoanProducts.FirstOrDefault(c => c.Id == loanId);
            var result = UpdateLoanMarkup(loan);
            _context.SaveChanges();
            return result;
        }

        private bool UpdateLoanMarkup(LoanProduct loan)
        {
            if (loan != null && !string.IsNullOrEmpty(loan.Link))
            {
                loan.NewMarkup = GetMarkup(loan.Link, XPathQuery(loan.Link));
                loan.NewMarkupDate = DateTime.Now;
                if (loan.Markup != loan.NewMarkup)
                {
                    loan.HasMarkupChanges = true;
                }
            }
            return loan.HasMarkupChanges;
        }

        //selector is per website
        private string XPathQuery(string link)
        {
            string primaryDomain = ExtractPrimaryDomain(link);

            string query = websiteXpathQueries.FirstOrDefault(k => primaryDomain.Contains(k.Key)).Value;

            if(string.IsNullOrEmpty(query))
            {
                throw new NotSupportedException("Банката не е поддржана");
            }

            return query;
        }

        private string ExtractPrimaryDomain(string link)
        {
            string result = string.Empty;
            Regex regex = new Regex("^(?:https?:\\/\\/)?(?:[^@\\/\n]+@)?(?:www\\.)?([^:\\/\n]+)");
            Match match = regex.Match(link);

            if (match.Success)
            {
                result = match.Groups[1].Value;
                result = result.Remove(result.IndexOf('.'));
            }

            return result;
        }
    }
}
