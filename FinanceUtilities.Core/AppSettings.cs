namespace FinanceUtilities.Core
{
    // TO DO: This class should not be static. Inject IConfiguration here and use it.
    public class AppSettings
    {
        public static string SmtpServer
        {
            get { return "smtp.mail.ru"; }//"void.mk-host.mk"; }//"smtp.gmail.com"
        }

        public static int SmtpPort { get { return 25; } }//587 google, mkhost

        public static string PrimaryEmail
        {
            get { return "contact@kreditinfo.mk"; }
            //get { return "seznajkokrediti@gmail.com"; }//ConfigurationManager.AppSettings["PrimaryEmail"]; }
        }

        public static string PrimaryEmailPassword
        {
            get { return "S3znajk0123"; }
            //get { return "046268000"; }//ConfigurationManager.AppSettings["PrimaryEmailPassword"]; }
        }

        public static string ImageBaseUri
        {
            get { return "https://kreditinfo.mk/assets/img/"; }
        }
    }
}