using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILoteria.Service.Contracts
{
    public class ConcursoDTO
    {
        public int? Concurso { get; set; }
        public string Data { get; set; }
        public string Dezenas { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Local { get; set; }
        public double? ArrecadacaoTotal { get; set; }
        public double? AcumuladoDataEspecial { get; set; }
        public ProximoDTO Proximo { get; set; }
    }

    public class ProximoDTO
    {
        public string Data { get; set; }
        public double? ValorAcumulado { get; set; }
        public double? EstimativaPremio { get; set; }
    }


}
