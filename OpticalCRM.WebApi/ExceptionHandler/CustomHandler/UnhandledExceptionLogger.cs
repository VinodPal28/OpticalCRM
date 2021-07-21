using OpticalCRM.Data.DomainContext;
using OpticalCRM.EntityFramework.Entity;
using OpticalCRM.Resources.Resources;
using OpticalCRM.WebApi.ExceptionHandler.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace OpticalCRM.WebApi.ExceptionHandler.CustomHandler
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        ErrorLogging _ErrorLogging = new ErrorLogging();
       
        public override void Log(ExceptionLoggerContext context)
        {
            var ex = context.Exception;

            string strLogText = "";
            strLogText += Environment.NewLine + string.Format("Source ---{0}\n", ex.Source);
            strLogText += Environment.NewLine + string.Format("StackTrace ---{0}\n", ex.StackTrace);
            strLogText += Environment.NewLine + string.Format("TargetSite ---{0}\n", ex.TargetSite);

            if (ex.InnerException != null)
            {
                strLogText += Environment.NewLine + string.Format("Inner Exception is {0}\n", ex.InnerException);//error prone
            }
            if (ex.HelpLink != null)
            {
                strLogText += Environment.NewLine + string.Format("HelpLink ---{0}\n", ex.HelpLink);//error prone
            }

            var requestedURi = (string)context.Request.RequestUri.AbsoluteUri;
            var requestMethod = context.Request.Method.ToString();
            var timeUtc = DateTime.Now;
            
            logResource apiError = new logResource()
            {
                Message = strLogText,
                RequestUri = requestedURi,
                RequestMethod = requestMethod,
                CreatedDate = DateTime.Now
            };
            _ErrorLogging.InsertErrorLog(apiError);
        }
    }
}
