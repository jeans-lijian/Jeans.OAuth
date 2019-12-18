using Jeans.OAuth.Core.Domains;
using Jeans.OAuth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Server
{
    public class CredentialServer : ICredentialServer
    {
        private readonly IRepository<Credentials> _credentialRepository;
        public CredentialServer(IRepository<Credentials> credentialRepository)
        {
            _credentialRepository = credentialRepository;
        }

        public List<Credentials> GetCredentials()
        {
            return _credentialRepository.Table.OrderBy(by => by.GrantTypeMode).ToList();
        }

        public Credentials GetCredentialByClientId(string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                return null;
            }

            return _credentialRepository.Table.FirstOrDefault(a => a.ClientId == clientId);
        }

        public bool HasClientIdAndClientSecret(string clientId, string clientSecret)
        {
            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
            {
                return false;
            }

            return _credentialRepository.Table.Any(a => a.ClientId == clientId && a.ClientSecret == clientSecret);
        }
    }
}
