using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSena.Application.Services.Concursos;

namespace WebSena.WebApi.Controllers
{
    [RoutePrefix("concurso")]
    public class ConcursoController : ApiController
    {
        private IConcursoService _concursoService;

        public ConcursoController(IConcursoService concursoService)
        {
            this._concursoService = concursoService;
        }

        [Route("test")]
        [HttpGet]
        public string Concurso()
        {
            return "test";
        }
    }
}