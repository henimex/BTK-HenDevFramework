using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.Entities;

namespace HenDevFramework.Core.DataAccess.EntityFramework
{
    public class EfQuaryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;

        public EfQuaryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities;

        protected virtual IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
