using AmigoProximo.Application.ViewModel;
using AmigoProximo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.AppService.Interfaces
{
    public interface IAmigoAppService : IAppServiceBase<Amigo>
    {
        List<AmigoVM> ObterAmigos();

        void CadastrarAmigo(AmigoVM model);

        void ExcluirAmigo(AmigoVM model);

        List<AmigoVM> ObterAmigosProximos(int AmigoID);

    }
}
