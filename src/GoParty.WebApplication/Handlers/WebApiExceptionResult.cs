using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace GoParty.WebApplication.Handlers
{
    public class WebApiExceptionResult : IHttpActionResult
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            => Task.FromResult(HttpResponseMessage);
    }
}