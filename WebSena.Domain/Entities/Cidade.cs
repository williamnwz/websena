using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSena.Domain.Entities
{
    public class Cidade : BaseEntity
    {

        public Cidade()
        {
        }

        public Cidade(string nome)
        {
            this.Nome = nome;
        }


        public string Nome { get; protected set; }

        public Estado Estado { get; protected set; }

        public List<Local> Locais { get; protected set; }

        public void IncluirLocal(Local local)
        {
            if (Locais == null) { Locais = new List<Local>(); }

            bool jaExiste = Locais.Any(x => x.Nome.Trim().ToUpper().Equals(local.Nome));

            if (jaExiste == false)
            {
                Locais.Add(local);
            }
        }
    }
}
