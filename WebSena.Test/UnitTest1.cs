using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSena.Application.Services.Concursos;
using WebSena.WebApi.App_Start;
using WebSena.WebApi.Controllers;

namespace WebSena.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IConcursoService _concursoService;

        [TestInitialize]
        public void Init()
        {
            var kernel = NinjectWebCommon.CreateKernel();
            _concursoService = (IConcursoService)kernel.GetService(typeof(ConcursoService));
        }

        [TestMethod]
        public void TestMethod1()
        {
            _concursoService.ObterConcursoPorNumero(1);
        }
    }
}
