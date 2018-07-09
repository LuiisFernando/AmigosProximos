using AmiProximo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Domain.Interfaces.Services
{
    public interface IAmigoProximoService : IServiceBase<Entities.AmigoProximo>
    {
        void DeleteAll();
    }
}
