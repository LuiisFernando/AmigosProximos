using AmigoProximo.Domain.Entities;
using AmigoProximo.Domain.Interfaces.Repositories;
using AmigoProximo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Domain.Services
{
    public class CalculoHistoricoService : ServiceBase<CalculoHistorico>, ICalculoHistoricoService
    {
        private ICalculoHistoricoRepository _repository;

        public CalculoHistoricoService(ICalculoHistoricoRepository repository)
            : base(repository)
        {
            this._repository = repository;
        }
    }
}
