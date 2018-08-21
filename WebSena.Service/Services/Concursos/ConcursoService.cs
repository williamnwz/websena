using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;
using WebSena.Domain.Repositories;

namespace WebSena.Application.Services.Concursos
{
    public class ConcursoService : IConcursoService
    {
        private IConcursoRepository _concursoRepository;

        public ConcursoService(IConcursoRepository concursoRepository)
        {
            this._concursoRepository = concursoRepository;
        }

        public Concurso ObterConcursoPorNumero(int numeroConcurso)
        {
            return this._concursoRepository.Find(x => x.Id == numeroConcurso).FirstOrDefault();
        }
    }
}
