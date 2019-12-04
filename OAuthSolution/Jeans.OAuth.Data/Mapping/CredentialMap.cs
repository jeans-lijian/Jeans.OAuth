using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Jeans.OAuth.Core.Domains;

namespace Jeans.OAuth.Data.Mapping
{
    public class CredentialMap : EntityTypeConfiguration<Credentials>
    {
        public CredentialMap()
        {
            ToTable("Credentials");
            HasKey(k => k.Id);
            Property(p => p.ClientId).HasMaxLength(128).IsRequired();
            Property(p => p.ClientSecret).HasMaxLength(128).IsRequired();
        }
    }
}
