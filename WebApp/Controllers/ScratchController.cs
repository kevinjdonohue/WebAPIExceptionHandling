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
    public class ScratchController : ApiController
    {
        [Route("scratch/{id}")]
        [HttpGet]
        [ItemNotFoundExceptionFilter]
        public IHttpActionResult Scratch(int id)
        {
            if (id == 7)
            {
                throw new ArgumentNullException();
            }

            throw new ItemNotFoundException("This is an exception thrown from the scratch controller");
        }
    }
}
