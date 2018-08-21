using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSena.Application.Services.Concursos;
using WebSena.Service.Services.Sincronizacoes;

namespace WebSena.WebApi.Controllers
{
    [RoutePrefix("sincronizacao")]
    public class SincronizacaoController : ApiController
    {

        private ISincronizacaoService _sincronizacaoService;

        public SincronizacaoController(ISincronizacaoService sincronizacaoService)
        {
            _sincronizacaoService = sincronizacaoService;
        }

        [Route("sincronizar")]
        [HttpGet]
        public bool Sincronizar()
        {
            _sincronizacaoService.SincronizarConcursos();
            return true;

        }
    }
}