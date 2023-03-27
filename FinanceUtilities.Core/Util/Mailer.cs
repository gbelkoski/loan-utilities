using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace FinanceUtilities.Core.Util
{
    public static class Mailer
    {
        public static bool SendMail(string to, string subject, string body, string[] cc = null)
        {
            try
            {
                var mail = new MailMessage();
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;

                mail.From = new MailAddress(AppSettings.PrimaryEmail);
                mail.To.Add(to);
                if (cc != null && cc.Length >  0)
                {
                    foreach (string ccMail in cc)
                    {
                        if (!string.IsNullOrEmpty(ccMail))
                        {
                            mail.CC.Add(ccMail);
                        }
                    }
                }

                mail.Subject = subject;
                mail.Body = body;

                BuildSmtpClient().Send(mail);
            }
            catch (Exception e)
            {
                Log4Net.Log.Error(e.Message);
                return false;
            }
            return true;
        }

        public static string PrepareTemplate(string templateBody, Dictionary<string, string> context)
        {
            foreach (var kvp in context)
            {
                var value = kvp.Value ?? "";
                templateBody = Regex.Replace(templateBody, kvp.Key, value, RegexOptions.IgnoreCase);
            }
            return templateBody;
        }

        private static SmtpClient BuildSmtpClient()
        {
            var smtpClient = new SmtpClient(AppSettings.SmtpServer);
            smtpClient.Port = AppSettings.SmtpPort;
            smtpClient.Credentials = new NetworkCredential(AppSettings.PrimaryEmail, AppSettings.PrimaryEmailPassword);
            smtpClient.EnableSsl = true;

            return smtpClient;
        }
    }
}
