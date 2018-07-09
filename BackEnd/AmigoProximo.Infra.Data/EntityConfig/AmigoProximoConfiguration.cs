using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Infra.Data.EntityConfig
{
    public class AmigoProximoConfiguration : EntityTypeConfiguration<AmigoProximo.Domain.Entities.AmigoProximo>
    {
        public AmigoProximoConfiguration()
        {
            //HasKey(k => new { k.AmigoID, k.AmigoQueEstaoProximoID });
        }
    }
}
