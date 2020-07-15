using Mono.Web;
using OAuth2.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2.Services
{
    public class GoogleOAuthClient : IOAuthClient
    {
        private readonly string _clientId;
        public GoogleOAuthClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException(@"Invalid client id", nameof(clientId));

            _clientId = clientId;
        }
        public IOAuthToken GetAccessToken(string requestUrl, string scope, string authorizationEndPoint)
        {
            if (string.IsNullOrEmpty(requestUrl))
                throw new ArgumentException(@"Invalid URL", nameof(requestUrl));
            if (string.IsNullOrEmpty(scope))
                throw new ArgumentException(@"Invalid scope", nameof(scope));
            if (string.IsNullOrEmpty(authorizationEndPoint))
                throw new ArgumentException(@"Invalid authorizationEndPoint", nameof(authorizationEndPoint));

            string requestToken = requestUrl + BuildQuery(scope,authorizationEndPoint);




        }

        private string BuildQuery(string scope, string authorizationEndPoint)
        {
            var requestQuery = HttpUtility.ParseQueryString(string.Empty);
            requestQuery.Add("?redirect_uri", authorizationEndPoint);
            requestQuery.Add("scope", scope);
            requestQuery.Add("access_type", "online");
            requestQuery.Add("response_type", "token");
            requestQuery.Add("prompt", "consent");

            return requestQuery.ToString();
        }
    }
}
