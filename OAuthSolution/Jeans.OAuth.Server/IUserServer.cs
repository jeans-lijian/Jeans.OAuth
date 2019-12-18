using Jeans.OAuth.Core.Domains;
using System.Collections.Generic;

namespace Jeans.OAuth.Server
{
    public interface IUserServer
    {
        List<UserEntity> GetUsers();

        UserEntity GetUser(string userName, string password);
    }
}
