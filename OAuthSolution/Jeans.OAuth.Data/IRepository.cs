using Jeans.OAuth.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(object id);

        void Delete(TEntity entity);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        IQueryable<TEntity> Table { get; }
    }
}
