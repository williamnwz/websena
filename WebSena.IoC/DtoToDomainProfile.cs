using APILoteria.Service.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;
using WebSena.IoC.CustomResolvers;

namespace WebSena.IoC
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<ConcursoDTO, Concurso>()
                .ForMember(dest => dest.NumerosSorteados, opt => opt.ResolveUsing<CustomResolveNumeroSorteado>())
                .ForMember(dest => dest.Estado, opt => opt.ResolveUsing<CustomResolveEstado>());
        }
    }

 


}
