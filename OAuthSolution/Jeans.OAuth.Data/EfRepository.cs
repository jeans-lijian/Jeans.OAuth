using Jeans.OAuth.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        private DbSet<TEntity> _entities;
        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        public IQueryable<TEntity> Table
        {
            get
            {
                return Entities;
            }
        }

    }
}
