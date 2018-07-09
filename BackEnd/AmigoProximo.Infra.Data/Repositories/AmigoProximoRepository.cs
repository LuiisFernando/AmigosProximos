using AmigoProximo.Domain.Interfaces.Repositories;
using AmigoProximo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AmigoProximo.Infra.Data.Repositories
{
    public class AmigoProximoRepository : RepositoryBase<AmigoProximo.Domain.Entities.AmigoProximo>, IAmigoProximoRepository
    {
        public AmigoProximoRepository(AmigoProximoContext context) : base(context)
        {

        }

        public void DeleteAll()
        {
            var todos = Context.AmigoProximos.ToList();

            foreach (var item in todos)
            {
                Context.AmigoProximos.Remove(item);
            }
            Context.SaveChanges();
        }
    }
}