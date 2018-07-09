using AmigoProximo.Application.AppService.Interfaces;
using AmigoProximo.Application.ViewModel;
using AmigoProximo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.AppService
{
    public class AmigoProximoAppService : AppServiceBase<AmigoProximo.Domain.Entities.AmigoProximo>, IAmigoProximoAppService
    {
        private IAmigoProximoService _service;

        public AmigoProximoAppService(IAmigoProximoService AppService)
            : base(AppService)
        {
            this._service = AppService;
        }

        public List<AmigoProximoVM> ObterAmigosProximos(int AmigoID)
        {
            var listaRetorno = new List<AmigoProximoVM>();

            FindAll(x => x.AmigoID == AmigoID).ToList().ForEach(x =>
            {
                listaRetorno.Add(new AmigoProximoVM(x));
            });

            return listaRetorno;
        }
    }
}
