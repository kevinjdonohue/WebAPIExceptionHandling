using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Exceptions;
using WebApp.Filters;

namespace WebApp.Controllers
{
    public class TestController : ApiController
    {
        [Route("test/{id}")]
        [HttpGet]
        [ItemNotFoundExceptionFilter]
        public IHttpActionResult Test(int id)
        {
            if (id > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (id > 75)
            {
                throw new ItemNotFoundException("This is a custom exception");
            }
            else if (id > 50)
            {
                HttpResponseMessage badRequestMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("You can not use ids between 51 and 100")
                };

                throw new HttpResponseException(badRequestMessage);
            }

            return Ok(id);
        }
    }
}
