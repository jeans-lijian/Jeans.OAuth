using Jeans.OAuth.Core.Domains;
using System;
using System.Collections.Generic;

namespace Jeans.OAuth.Server
{
    public interface ICredentialServer
    {
        List<Credentials> GetCredentials();

        bool HasClientIdAndClientSecret(string clientId, string clientSecret);

        Credentials GetCredentialByClientId(string clientId);

        Credentials GetCredentialsById(Guid id);

        void DeleteCredentials(Credentials entity);

        void AddCredentials(Credentials entity);

        void UpdateCredentials(Credentials entity);
    }
}
