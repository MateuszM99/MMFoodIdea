using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2.IServices
{
    public interface IOAuthToken
    {
        string Token { get; }
        int ExpirationTime { get; }
    }
}
