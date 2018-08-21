using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;
using WebSena.Domain.Repositories;

namespace WebSena.Repository.Repositories
{
    public class BaseRepository<Entity> : IDisposable, IBaseRepository<Entity> where Entity : BaseEntity
    {
        private AppContext _context;
        public BaseRepository(AppContext context)
        {
            this._context = context;
        }

        public void Delete(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
        }

        public IEnumerable<Entity> Find(Expression<Func<Entity, bool>> predicate)
        {
            return _context.Set<Entity>().Where(predicate).ToList();
        }

        public Entity GetById(int id)
        {
            return _context.Set<Entity>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
