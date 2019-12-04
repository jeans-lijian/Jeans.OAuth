using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Server
{
    public interface IUserServer
    {
        bool HasLogin(string userName,string password);
    }
}
