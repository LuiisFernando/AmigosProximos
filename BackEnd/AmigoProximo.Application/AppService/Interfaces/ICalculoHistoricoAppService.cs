using AmigoProximo.Application.ViewModel;
using AmigoProximo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.AppService.Interfaces
{
    public interface ICalculoHistoricoAppService : IAppServiceBase<CalculoHistorico>
    {
        double CalcularDistanciaEntreAmigos(AmigoVM amVM1, AmigoVM amVM2);
    }
}
