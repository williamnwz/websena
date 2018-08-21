using APILoteria.Service.Contracts;
using APILoteria.Service.Service;
using AutoMapper;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Application.Services.Concursos;
using WebSena.Domain.Entities;
using WebSena.Domain.Repositories;
using WebSena.Repository;
using WebSena.Repository.Repositories;
using WebSena.Service.Services.Sincronizacoes;

namespace WebSena.IoC
{
    public class Container : NinjectModule
    {

        

        public override void Load()
        {
            Bind<IConcursoService>().To<ConcursoService>();
            Bind<IConcursoRepository>().To<ConcursoRepostory>();
            Bind<IUnityOfWork>().To<UnityOfWork>();

            Bind<ISincronizacaoService>().To<SincronizacaoService>();
            Bind<IAPILoteriaService>().To<APILoteriaService>();
            



            Bind<AppContext>().To<AppContext>();

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));

        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToDomainProfile());
                //cfg.AddProfile(new DomainToDtoProfile());
            });

            return config;
        }




    }
}
