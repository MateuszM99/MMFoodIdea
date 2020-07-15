using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2.IServices
{
    public interface IOAuthClient
    {
        IOAuthToken GetAccessToken(string requestUrl, string scope, string authorizationEndPoint);


    }
}
