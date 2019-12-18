using Jeans.OAuth.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Server
{
    public interface ICredentialServer
    {
        List<Credentials> GetCredentials();

        bool HasClientIdAndClientSecret(string clientId, string clientSecret);

        Credentials GetCredentialByClientId(string clientId);
    }
}
