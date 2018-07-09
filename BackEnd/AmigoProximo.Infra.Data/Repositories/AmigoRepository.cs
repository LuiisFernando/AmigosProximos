using AmigoProximo.Domain.Entities;
using AmigoProximo.Domain.Interfaces.Repositories;
using AmigoProximo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Infra.Data.Repositories
{
    public class AmigoRepository : RepositoryBase<Amigo>, IAmigoRepository
    {
        public AmigoRepository(AmigoProximoContext context) : base(context)
        {

        }
    }
}
