using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;

namespace WebSena.Domain.Repositories
{
    public interface IBaseRepository<Entity>
    {

        void Delete(Entity entity);

        Entity GetById(int id);

        IEnumerable<Entity> Find(Expression<Func<Entity, bool>> predicate);
    }
}
