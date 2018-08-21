using APILoteria.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILoteria.Service.Service
{
    public interface IAPILoteriaService
    {
        string TokenAuth { get; }

        List<ConcursoDTO> ObterTodosOsConcursos();

        ConcursoDTO ObterUltimoConcurso();

        List<ConcursoDTO> ObterConcursosPorData(DateTime dataInicio, DateTime dataFim);
    }
}
