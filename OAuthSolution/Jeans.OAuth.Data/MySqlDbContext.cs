using Jeans.OAuth.Core;
using Jeans.OAuth.Core.Domains;
using Jeans.OAuth.Data.Mapping;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlDbContext : DbContext, IDbContext
    {
        public MySqlDbContext() : base("name=MySqlDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CredentialMap());
            modelBuilder.Configurations.Add(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
    }
}
