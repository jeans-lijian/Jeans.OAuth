using Jeans.OAuth.Core.Domains;
using Jeans.OAuth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Server
{
    public class UserServer : IUserServer
    {
        private readonly IRepository<UserEntity> _userRepository;
        public UserServer(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserEntity GetUser(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            try
            {
                return _userRepository.Table.SingleOrDefault(w => w.UserName == userName && w.Password == password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
