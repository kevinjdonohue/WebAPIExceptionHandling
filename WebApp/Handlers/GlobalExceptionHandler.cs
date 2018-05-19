using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;

namespace WebApp.Handlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is ArgumentNullException)
            {
                HttpResponseMessage badRequestMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ArgumentNullException"
                };

                context.Result = new ArgumentNullResult(context.Request, badRequestMessage);
            }            
        }
    }
}