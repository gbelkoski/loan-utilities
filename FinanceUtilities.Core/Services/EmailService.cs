using FinanceUtilities.Core.Util;
using FinanceUtilities.Data;
using FinanceUtilities.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinanceUtilities.Core
{
    public class EmailService : ServiceBase, IEmailService
    {
        readonly string KreditInfoContactEmail = "contact@kreditinfo.mk";
        private IHostingEnvironment _hostingEnvironment;

        public EmailService(IFinanceContext context, IHostingEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public bool SendLoanQuoteRequest(string name, string customerEmail, string phoneNumber, string city, string mailContent, int loanId, decimal loanAmount, int duration)
        {
            try
            {
                var loanProduct = _context.LoanProducts
                    .Include(l => l.Bank)
                    .Include(l => l.LoanType)
                    .FirstOrDefault(l => l.Id == loanId);
                if (loanProduct == null) return false;

                var bankLoanMail = loanProduct.Bank.LoanContactEmail;
                if (string.IsNullOrEmpty(bankLoanMail)) return false;

                string body = PrepareMailBody(name, customerEmail, phoneNumber, city, mailContent, loanAmount.ToString("N2"), duration.ToString(), loanProduct);

                Mailer.SendMail(bankLoanMail, "Барање за понуда", body, new string[] { customerEmail, KreditInfoContactEmail });
            }
            catch (Exception e)
            {
                Log4Net.Log.Error(e.Message);
                return false;
            }
            return true;
        }
        public bool SendContactMail(string name, string email, string phoneNumber, string mailContent)
        {
            try
            {
                string body = PrepareMailBody(name, email, phoneNumber, mailContent);

                Mailer.SendMail(KreditInfoContactEmail, "Кредитинфо.мк контакт", body);
            }
            catch (Exception e)
            {
                Log4Net.Log.Error(e.Message);
                return false;
            }
            return true;
        }

        private string PrepareMailBody(string name, string email, string phoneNumber, string mailContent)
        {
            string templatePath = Path.Combine(_hostingEnvironment.ContentRootPath, "MailTemplates", "ContactUs.html");
            string template = File.ReadAllText(templatePath);

            var context = new Dictionary<string, string>
            {
                {"{ClientName}", name},
                {"{ClientEmail}", email},
                {"{ClientPhone}", phoneNumber},
                {"{ClientMessage}", mailContent},
            };

            return Mailer.PrepareTemplate(template, context);
        }
        private string PrepareMailBody(string name, string email, string phoneNumber, string city, string mailContent, string amount, string duration, LoanProduct loan)
        {
            string templatePath = Path.Combine(_hostingEnvironment.ContentRootPath, "MailTemplates", "Quote.html");
            string template = File.ReadAllText(templatePath);

            var context = new Dictionary<string, string>
            {
                {"{ClientName}", name},
                {"{ClientEmail}", email},
                {"{ClientPhone}", phoneNumber},
                {"{ClientCity}", city},
                {"{LoanType}", loan.LoanType.Name},
                {"{LoanAmount}", amount},
                {"{LoanDuration}", duration},
                {"{ClientMessage}", mailContent},
            };

            return Mailer.PrepareTemplate(template, context);
        }
    }
}
