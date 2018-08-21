using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;
using WebSena.Domain.Repositories;

namespace WebSena.Repository.Repositories
{
    public class ConcursoRepostory : BaseRepository<Concurso>, IConcursoRepository
    {
        public ConcursoRepostory(AppContext context) 
            : base(context)
        {
        }
    }
}
