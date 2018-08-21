using APILoteria.Service.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;
using WebSena.Domain.Repositories;

namespace WebSena.IoC.CustomResolvers
{
    public class CustomResolveEstado : IValueResolver<ConcursoDTO, Concurso, Estado>
    {
        public Estado Resolve(ConcursoDTO source, Concurso destination, Estado destMember, ResolutionContext context)
        {
            Estado estado = new Estado(source.UF);
            Cidade cidade = new Cidade(source.Cidade);
            Local local = new Local(source.Local);

            cidade.IncluirLocal(local);
            estado.IncluirCidade(cidade);

            return estado;
        }
    }
}
