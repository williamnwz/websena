using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSena.Domain.Entities
{
    public class Estado : BaseEntity
    {
        public Estado() { }

        public Estado(string nome)
        {
            this.Nome = nome;
        }

        public string Nome { get; protected set; }

        public List<Cidade> Cidades { get; protected set; }

        public void IncluirCidade(Cidade cidade)
        {
            if (Cidades == null) { Cidades = new List<Cidade>(); }

            bool jaExiste = Cidades.Any(x => x.Nome.Trim().ToUpper().Equals(cidade.Nome));

            if (jaExiste == false)
            {
                Cidades.Add(cidade);
            }
            else
            {
                Cidade cidadeEncontrada = Cidades.FirstOrDefault(x => x.Nome.Trim().ToUpper().Equals(cidade.Nome));

                cidade.Locais.ForEach(x =>
                {
                    cidadeEncontrada.IncluirLocal(x);
                });
            }
        }
    }
}
