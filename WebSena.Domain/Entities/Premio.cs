using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSena.Domain.Entities
{
    public class Premio : BaseEntity
    {
        public int Ganhadores { get; set; }

        public string Faixa { get; set; }

        public string Descricao { get; set; }

        public Concurso Concurso { get; set; }
    }
}
