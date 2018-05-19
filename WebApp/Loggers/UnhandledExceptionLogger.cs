using System;
using System.IO;
using System.Web.Http.ExceptionHandling;

namespace WebApp.Loggers
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            string exceptionMessage = context.Exception.ToString();
            using (StreamWriter sw = File.AppendText("c:\\Temp\\error-log.txt"))
            {
                sw.WriteLine("===========This message is being logged to disk when an unhandled excpetion occurs.===========");
                sw.WriteLine(
                    "----------------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine($"Error Message:  {context.Exception.Message}");
                sw.WriteLine($"Error Source:  {context.Exception.Source}");
                sw.WriteLine($"Stack Trace:  \n\n\n{context.Exception.StackTrace}");
            }
        }
    }
}