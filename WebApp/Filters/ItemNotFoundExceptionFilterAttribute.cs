using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using WebApp.Exceptions;

namespace WebApp.Filters
{
    public class ItemNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ItemNotFoundException)
            {
                HttpResponseMessage notFoundMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ItemNotFound"
                };

                throw new HttpResponseException(notFoundMessage);
            }
        }
    }
}