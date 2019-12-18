using Jeans.OAuth.Core.Domains;
using Jeans.OAuth.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Credentials GetCredentialsById(Guid id)
        {
            return _credentialRepository.GetById(id);
        }

        public void DeleteCredentials(Credentials entity)
        {
            _credentialRepository.Delete(entity);
        }

        public void AddCredentials(Credentials entity)
        {
            _credentialRepository.Insert(entity);
        }

        public void UpdateCredentials(Credentials entity)
        {
            _credentialRepository.Update(entity);
        }

    }
}
