using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApp.Handlers
{
    public class ArgumentNullResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private readonly HttpResponseMessage _response;

        public ArgumentNullResult(HttpRequestMessage request, HttpResponseMessage response)
        {
            _request = request;
            _response = response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }
    }
}