using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;

namespace WebSena.Repository.Mapping
{
    public class ConcursoMap : EntityTypeConfiguration<Concurso>
    {
        public ConcursoMap()
        {
            ToTable("Concurso");
            HasKey(x => x.Id);
            Property(x => x.AcumuladoDataEspecial).HasColumnName("ACUMULADO_DATA_ESPECIAL");
            Property(x => x.ArrecadacaoTotal).HasColumnName("ARRECADACAO_TOTAL");
            Property(x => x.Data).HasColumnName("DATA");
            Property(x => x.Descricao).HasColumnName("DESCRICAO");
            Property(x => x.EstimativaPremio).HasColumnName("ESTIMATIVA_PREMIO");
            Property(x => x.ProximaData).HasColumnName("PROXIMA_DATA");
            Property(x => x.ValorAcumulado).HasColumnName("VALOR_ACUMULADO");
        }


    }
}
