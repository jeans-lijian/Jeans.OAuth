using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Server
{
    public class CredentialServer : ICredentialServer
    {
        public bool HasClientIdAndClientSecret(string clientId, string clientSecret)
        {
            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
            {
                return false;
            }

            return clientId == "jeans" && clientSecret == "123456";
        }
    }
}
