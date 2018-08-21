using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;

namespace WebSena.Application.Services.Concursos
{
    public interface IConcursoService
    {

        Concurso ObterConcursoPorNumero(int numeroConcurso);
    }
}
