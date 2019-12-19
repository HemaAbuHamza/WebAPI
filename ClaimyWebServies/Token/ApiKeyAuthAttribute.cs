using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;


namespace ClaimyWebServies.Token
{
    public class ApiKeyAuthAttribute : DelegatingHandler

    {

        private const string ApiKeyToCheck = "123456";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            
            bool validKey = false;
            IEnumerable<string> requestHeaders;

            var checkApiKeyExists = httpRequestMessage.Headers.TryGetValues("APIKey", out requestHeaders);

            if (checkApiKeyExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(ApiKeyToCheck))
                {
                    validKey = true;
                }
            }

            if (!validKey)
            {
                return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, " Invalid API KEY ");
            }

            var response = await base.SendAsync(httpRequestMessage, cancellationToken);
            return response;
        }

        
    }
}