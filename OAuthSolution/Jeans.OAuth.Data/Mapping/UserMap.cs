using Jeans.OAuth.Core.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            ToTable("T_User");
            HasKey(k => k.Id);
            Property(p => p.UserName).HasMaxLength(64).IsRequired();
            Property(p => p.Password).HasMaxLength(128).IsRequired();
        }
    }
}
