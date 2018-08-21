using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSena.Domain.Entities
{
    public class Concurso : BaseEntity
    {
        public string NumeroConcurso { get; protected set; }

        public DateTime Data { get; protected set; }

        public double ArrecadacaoTotal { get; protected set; }

        public double AcumuladoDataEspecial { get; protected set; }

        public DateTime ProximaData { get; protected set; }

        public double ValorAcumulado { get; protected set; }

        public double EstimativaPremio { get; protected set; }

        public string Descricao { get; protected set; }

        public List<NumeroSorteado> NumerosSorteados { get; protected set; }

        public Estado Estado { get; protected set; }

        public Cidade Cidade { get; protected set; }

        public Local Local { get; protected set; }

        //public List<Premio> Premios { get; protected set; }

    }
}
