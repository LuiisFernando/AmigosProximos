using AmigoProximo.Application.AppService.Interfaces;
using AmigoProximo.Application.ViewModel;
using AmigoProximo.Domain.Entities;
using AmigoProximo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.AppService
{
    public class AmigoAppService : AppServiceBase<Amigo>, IAmigoAppService
    {
        private IAmigoService _service;
        private IAmigoProximoService _serviceAmigoProximo;
        private ICalculoHistoricoService calculoAppService;

        public AmigoAppService(IAmigoService AppService, IAmigoProximoService appAmigoService, ICalculoHistoricoService _calculpAppService)
            : base(AppService)
        {
            this._service = AppService;
            this._serviceAmigoProximo = appAmigoService;
            this.calculoAppService = _calculpAppService;
        }

        public List<AmigoVM> ObterAmigos()
        {
            var listRetorno = new List<AmigoVM>();

            _service.FindAll(x => x.Ativo, i => i.AmigosQueEstaoProximos).ToList().ForEach(a =>
            {
                var amigo = new AmigoVM(a);
                var amigosproximos =_serviceAmigoProximo.FindAll(x => x.AmigoID == amigo.ID);

                amigosproximos.ToList().ForEach(d => amigo.AmigosProximos.Add(new AmigoProximoVM(d)));

                listRetorno.Add(amigo);
            });

            return listRetorno;
        }

        public List<AmigoVM> ObterAmigosProximos(int AmigoID)
        {
            List<AmigoVM> listaRetorno = new List<AmigoVM>();

            var amigoproximos = _serviceAmigoProximo.FindAll(x => x.AmigoID == AmigoID, i => i.AmigoQueEstaoProximo);

            amigoproximos.ToList().ForEach(d => {
                listaRetorno.Add(new AmigoVM(d.AmigoQueEstaoProximo));
            });

            return listaRetorno;
        }

        public void CadastrarAmigo(AmigoVM model)
        {
            try
            {

                model.Ativo = true;

                var amigo = AmigoVM.ConvertModel(model);

                var amigoMesmaPosicao = Find(x => x.PosicaoX == model.PosicaoX && x.PosicaoY == model.PosicaoY);

                if (amigoMesmaPosicao != null)
                    throw new Exception("Já existe um amigo nessa posição, escolha outra");

                _service.Insert(amigo);

                CalcularAmigosProximos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CalcularAmigosProximos()
        {
            _serviceAmigoProximo.DeleteAll();

            var todosAmigos = FindAll(x => x.Ativo, i => i.AmigosQueEstaoProximos).ToList();

            foreach (var x in todosAmigos)
            {
                var amigoAtual = new AmigoVM(x);

                PosicaoVM posicaoAmigoAtual = new PosicaoVM();
                posicaoAmigoAtual.PosicaoX = amigoAtual.PosicaoX;
                posicaoAmigoAtual.PosicaoY = amigoAtual.PosicaoY;

                List<AmigoVM> ListaAmigosDistanciasACalcular = new List<AmigoVM>();

                var amigosSemOAtual = FindAll(n => n.Ativo && n.ID != amigoAtual.ID);

                foreach (var h in amigosSemOAtual)
                {

                    var amigoTerceiro = new AmigoVM(h);

                    PosicaoVM posicaoAmigosTerceiros = new PosicaoVM();
                    posicaoAmigosTerceiros.PosicaoX = amigoTerceiro.PosicaoX;
                    posicaoAmigosTerceiros.PosicaoY = amigoTerceiro.PosicaoY;
                    amigoTerceiro.Distance = Math.Sqrt((Math.Pow(amigoAtual.PosicaoX - amigoTerceiro.PosicaoX, 2) + Math.Pow(amigoAtual.PosicaoY - amigoTerceiro.PosicaoY, 2)));


                    CalculoHistorico calHistorico = new CalculoHistorico();

                    calHistorico.Acao = "Calculo de disntância";
                    calHistorico.Descricao = string.Format("Calculo de distancia entre o amigo {0} e amigo {1}, resultado: {2}", amigoAtual.Nome, amigoTerceiro.Nome, amigoTerceiro.Distance);
                    calHistorico.AmigoID = amigoAtual.ID.Value;
                    calHistorico.AmigoCalculadoID = amigoTerceiro.ID.Value;
                    calHistorico.Data = DateTime.Now;

                    x.CalculoHistorico.Add(calHistorico);

                    ListaAmigosDistanciasACalcular.Add(amigoTerceiro);
                }

                Update(x);

                ListaAmigosDistanciasACalcular = ListaAmigosDistanciasACalcular.OrderBy(o => o.Distance).ToList();

                if (ListaAmigosDistanciasACalcular.Count > 0)
                {
                    int tamanho = ListaAmigosDistanciasACalcular.Count < 3 ? ListaAmigosDistanciasACalcular.Count : 3;

                    ListaAmigosDistanciasACalcular = ListaAmigosDistanciasACalcular.GetRange(0, tamanho);

                    var listAmigosProximos = new List<AmigoProximo.Domain.Entities.AmigoProximo>();

                    ListaAmigosDistanciasACalcular.ForEach(f =>
                    {
                        AmigoProximo.Domain.Entities.AmigoProximo apx = new Domain.Entities.AmigoProximo();

                        apx.AmigoID = amigoAtual.ID.Value;
                        apx.AmigoQueEstaoProximoID = f.ID.Value;

                        listAmigosProximos.Add(apx);
                    });

                    foreach (var item in listAmigosProximos)
                    {
                        var amigoProximo = new AmigoProximo.Domain.Entities.AmigoProximo();
                        amigoProximo.AmigoID = item.AmigoID;
                        amigoProximo.AmigoQueEstaoProximoID = item.AmigoQueEstaoProximoID;

                        _serviceAmigoProximo.Insert(amigoProximo);
                    }
                }

            }
        }

        public void ExcluirAmigo(AmigoVM model)
        {
            try
            {
                var amigoBD = _service.Find(x => x.ID == model.ID);

                amigoBD.Ativo = false;

                Update(amigoBD);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
