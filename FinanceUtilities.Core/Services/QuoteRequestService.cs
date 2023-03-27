using FinanceUtilities.Data;
using FinanceUtilities.Domain;
using System;
using System.Linq;

namespace FinanceUtilities.Core.Services
{
    public class QuoteRequestService : ServiceBase, IQuoteRequestService
    {
        private readonly IEmailService _emailService;

        public QuoteRequestService(IEmailService emailService, IFinanceContext context) : base(context)
        {
            _emailService = emailService;
        }

        public bool SendLoanQuoteRequest(string name, string customerEmail, string phoneNumber, string city, string mailContent, int loanId, decimal loanAmount, int duration)
        {
            var mailSent = _emailService.SendLoanQuoteRequest(name, customerEmail, phoneNumber, city, mailContent, loanId, loanAmount, duration);

            CreateQuoteLog(name, customerEmail, phoneNumber, city, mailContent, loanId, loanAmount, duration, mailSent);

            try
            {
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                Log4Net.Log.Error(e.Message);
            }

            return mailSent;
        }

        private void CreateQuoteLog(string name, string customerEmail, string phoneNumber, string city, string mailContent, int loanId, decimal loanAmount, int duration, bool mailSent)
        {
            QuoteLog quoteLog = new QuoteLog
            {
                Name = name,
                Email = customerEmail ?? string.Empty,
                PhoneNumber = phoneNumber,
                City = city,
                Message = mailContent,
                LoanProductId= loanId,
                LoanAmount = loanAmount,
                Duration = duration,
                DateCreated = DateTime.Now,
                MailSentSuccessfully = mailSent,
                TermsOfApplication = @"&emsp;Внесените лични податоци се точни и проверени и согласен сум истите да можат да се регистрираат, обработуваат и зачувуваат во согласност со законите и интерните акти на Банката.<br /><br />
                                        &emsp;Согласен сум по испраќањето на податоците да бидам телефонски контактиран од страна на Банката за комплетирање на апликацијата во телефонски разговор, како и да бидам контактиран и информиран за карактеристиките на производите/услугите на Банката.<br /><br />
                                        &emsp;Оваа согласност ја давам во согласност со Законот за заштита на личните податоци („Службен весник на РМ“ бр. 07/05, 103/08 и 124/10).<br /><br />
                                        &emsp;Согласен сум и информиран дека Банката ги разгледува само апликациите кои се комплетирани и за кои не треба да се приложи дополнителна документација.<br /><br />
                                        &emsp;Согласен сум и информиран за можноста Банката да го одбие моето барањето во согласност со законите во РМ и актите на Банката и/или да побара дополнителна документација и/или проверка и/или да ме повика аплицирањето да го извршам со лична посета на некоја од филијалите на Банката. <br /><br />
                                        &emsp;Се согласувам Банката да ги користи моите лични податоци со цел да врши проверка или верификација во Кредитниот Регистар и други бази на податоци за целите на воспоставување на деловниот однос, а во согласност со законите и интерните акти на Банката. Запознаен/а сум дека барањето е наменето за физички лица, државјани на Република Македонија Потврдувам дека со притискањето на „Испрати“ давам моја писмена согласност за горенаведените услови согласно кои Банката може да ја започне процедурата за аплицирање и информиран сум дека истата можам да ја повлечам преку филијалите на Банката или со јавување во Контакт Центарот на Банката.<br /><br />"
            };
            _context.QuoteLogs.Add(quoteLog);
        }

        public bool IsSpam(string customerEmail, string phoneNumber, int loanId)
        {
            var quoteLog = _context.QuoteLogs.FirstOrDefault(q => q.LoanProductId == loanId && (q.Email==customerEmail || q.PhoneNumber == phoneNumber));

            if(quoteLog != null)
            {
                var timeSpan = quoteLog.DateCreated.Subtract(DateTime.Now);
                if(timeSpan.TotalDays < 30){
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
