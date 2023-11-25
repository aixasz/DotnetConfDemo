
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace IdentityDemo.BlazorWasmAuth.Identity
{
    public class CookieAuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // set the request include cookies!
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
