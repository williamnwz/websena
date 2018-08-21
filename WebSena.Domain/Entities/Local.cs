using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSena.Domain.Entities
{
    public class Local : BaseEntity
    {

        public Local()
        {

        }

        public Local(string nome)
        {
            this.Nome = nome;
        }


        public Cidade Cidade { get; set; }

        public string Nome { get; set; }
    }
}
