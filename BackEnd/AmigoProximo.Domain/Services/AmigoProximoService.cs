using AmigoProximo.Domain.Interfaces.Repositories;
using AmigoProximo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Domain.Services
{
    public class AmigoProximoService : ServiceBase<Entities.AmigoProximo>, IAmigoProximoService
    {
        private IAmigoProximoRepository _repository;

        public AmigoProximoService(IAmigoProximoRepository repository)
            : base(repository)
        {
            this._repository = repository;
        }
        public void DeleteAll()
        {
            this._repository.DeleteAll();
        }
    }
}
