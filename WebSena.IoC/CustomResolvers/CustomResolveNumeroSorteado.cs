using APILoteria.Service.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;

namespace WebSena.IoC.CustomResolvers
{
    public class CustomResolveNumeroSorteado : IValueResolver<ConcursoDTO, Concurso, List<NumeroSorteado>>
    {
        public List<NumeroSorteado> Resolve(ConcursoDTO source, Concurso destination, List<NumeroSorteado> destMember, ResolutionContext context)
        {
            List<NumeroSorteado> numerosSorteados = new List<NumeroSorteado>();
            source.Dezenas.Split('|').ToList().ForEach(d =>
            {
                int result = 0;
                if (int.TryParse(d, out result))
                {
                    numerosSorteados.Add(new NumeroSorteado()
                    {
                        Id = Convert.ToInt32(d)
                    });
                }
            });
            return numerosSorteados;
        }
    }
}
