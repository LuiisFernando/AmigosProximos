using AmigoProximo.Application.AppService.Interfaces;
using AmigoProximo.Application.ViewModel;
using AmigoProximo.Domain.Entities;
using AmigoProximo.Domain.Interfaces.Services;
using AmigoProximo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.AppService
{
    public class CalculoHistoricoAppService : AppServiceBase<CalculoHistorico>, ICalculoHistoricoAppService
    {
        private ICalculoHistoricoService _service;

        public CalculoHistoricoAppService(ICalculoHistoricoService AppService)
            : base(AppService)
        {
            this._service = AppService;
        }

        public double CalcularDistanciaEntreAmigos(AmigoVM amVM1, AmigoVM amVM2)
        {
            double resultado = Math.Sqrt((Math.Pow(amVM1.PosicaoX - amVM2.PosicaoX, 2) + Math.Pow(amVM1.PosicaoY - amVM2.PosicaoY, 2)));
            CalculoHistorico calHistorico = new CalculoHistorico();

            calHistorico.Acao = "Calculo de disntância";
            calHistorico.Descricao = string.Format("Calculo de distancia entre o amigo {0} e amigo {1}, resultado: {2}", amVM1.Nome, amVM2.Nome, resultado);
            calHistorico.AmigoID = amVM1.ID.Value;
            calHistorico.AmigoCalculadoID = amVM2.ID.Value;
            calHistorico.Data = DateTime.Now;

            _service.Insert(calHistorico);

            return resultado;
        }
    }
}
