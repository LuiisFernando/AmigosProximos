using AmigoProximo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Infra.Data.EntityConfig
{
    public class CalculoHistoricoConfiguration : EntityTypeConfiguration<CalculoHistorico>
    {
        public CalculoHistoricoConfiguration()
        {
            Property(p => p.Acao)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
