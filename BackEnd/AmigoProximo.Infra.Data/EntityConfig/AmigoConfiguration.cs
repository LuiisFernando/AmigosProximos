using AmigoProximo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Infra.Data.EntityConfig
{
    public class AmigoConfiguration : EntityTypeConfiguration<Amigo>
    {
        public AmigoConfiguration()
        {
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.PosicaoX)
                .IsRequired();

            Property(p => p.PosicaoY)
                .IsRequired();

            HasMany(x => x.AmigosQueEstaoProximos).WithRequired(x => x.AmigoQueEstaoProximo);

            HasMany(x => x.CalculoHistorico).WithRequired(x => x.Amigo);

        }
    }
}
