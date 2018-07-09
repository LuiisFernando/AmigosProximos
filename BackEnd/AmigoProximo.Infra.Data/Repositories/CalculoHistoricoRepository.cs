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
    public class CalculoHistoricoRepository : RepositoryBase<CalculoHistorico>, ICalculoHistoricoRepository
    {
        public CalculoHistoricoRepository(AmigoProximoContext context) : base(context)
        {

        }
    }
}
