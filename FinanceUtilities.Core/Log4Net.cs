using log4net;
using System;
using System.IO;

namespace FinanceUtilities.Core
{
    public class Log4Net
    {
        public static string LineBreak
        {
            get
            {
                return System.Environment.NewLine + "#######################################################################" + System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine;
            }
        }

        static string LogFileName
        {
            get
            {
                return "Logs\\" + DateTime.Now.ToString("yyyy.MM.dd") + "_Log.txt";
            }
        }

        protected static ILog log;
        public static ILog Log
        {
            get
            {
                if (log == null)
                {
                    FileInfo configFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
                    var rootRep = log4net.LogManager.CreateRepository("repo");
                    log4net.Config.XmlConfigurator.Configure(rootRep, configFile);

                    foreach (log4net.Appender.IAppender iApp in rootRep.GetAppenders())
                    {
                        if (iApp is log4net.Appender.FileAppender)
                        {
                            var fApp = (iApp as log4net.Appender.FileAppender);
                            fApp.File = LogFileName;
                            fApp.ActivateOptions();
                        }
                    }
                    log = LogManager.GetLogger("repo", "File");
                }
                return log;
            }
        }
    }
}