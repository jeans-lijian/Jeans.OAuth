using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Core.Domains
{
    public enum GrantTypeMode
    {
        AuthorizationCode=1,

        Implicit=2,

        Password=3,

        ClientCredentials=4
    }
}
