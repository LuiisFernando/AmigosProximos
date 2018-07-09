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
    public class AmigoService : ServiceBase<Amigo>, IAmigoService
    {
        private IAmigoRepository _repository;

        public AmigoService(IAmigoRepository repository)
            : base(repository)
        {
            this._repository = repository;
        }

    }
}
