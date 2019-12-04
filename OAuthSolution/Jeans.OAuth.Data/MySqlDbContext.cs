using Jeans.OAuth.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Data
{
    public class MySqlDbContext : DbContext, IDbContext
    {
        public MySqlDbContext() : base("")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CredentialMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
