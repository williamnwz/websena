using APILoteria.Service.Contracts;
using APILoteria.Service.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;
using WebSena.Domain.Repositories;
using WebSena.Repository;

namespace WebSena.Service.Services.Sincronizacoes
{
    public class SincronizacaoService : ISincronizacaoService
    {
        private IConcursoRepository _concursoRepository;
        private IUnityOfWork _unityOfWork;
        private IAPILoteriaService _apiLoteriaService;
        private IMapper _mapper;

        public SincronizacaoService(
            IAPILoteriaService apiLoteriaService,
            IConcursoRepository concursoRepository,
            IUnityOfWork unityOfWork,
            IMapper mapper)
        {
            _concursoRepository = concursoRepository;
            _unityOfWork = unityOfWork;
            _apiLoteriaService = apiLoteriaService;
            _mapper = mapper;
        }

        public void SincronizarConcursos()
        {
            ConcursoDTO concurso = _apiLoteriaService.ObterUltimoConcurso();

            Concurso c = _mapper.Map<Concurso>(concurso);

        }
    }
}
