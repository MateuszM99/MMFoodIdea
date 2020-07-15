using OAuth2.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2.Services
{
    public class OAuthFactory : IOAuthFactory
    {
        public IOAuthClient CreateNewClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException(@"Invalid client id", nameof(clientId));

            return new GoogleOAuthClient(clientId);
        }
    }
}
