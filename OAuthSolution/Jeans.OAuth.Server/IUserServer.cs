using Jeans.OAuth.Core.Domains;
using System;
using System.Collections.Generic;

namespace Jeans.OAuth.Server
{
    public interface IUserServer
    {
        List<UserEntity> GetUsers();

        UserEntity GetUser(string userName, string password);

        bool DeleteUser(Guid id);

        void AddUser(UserEntity entity);

        void UpdateUser(UserEntity entity);
    }
}
