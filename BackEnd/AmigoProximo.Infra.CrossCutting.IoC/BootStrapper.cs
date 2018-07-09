using AmigoProximo.Application.AppService;
using AmigoProximo.Application.AppService.Interfaces;
using AmigoProximo.Domain.Interfaces.Repositories;
using AmigoProximo.Domain.Interfaces.Services;
using AmigoProximo.Domain.Services;
using AmigoProximo.Infra.Data.Context;
using AmigoProximo.Infra.Data.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<AmigoProximoContext>(Lifestyle.Scoped);

            #region AppService

            container.Register<IAmigoAppService, AmigoAppService>();
            container.Register<IAmigoProximoAppService, AmigoProximoAppService>();
            container.Register<ICalculoHistoricoAppService, CalculoHistoricoAppService>();
            container.Register<IUsuarioAppService, UsuarioAppService>();

            #endregion

            #region Services

            container.Register<IAmigoService, AmigoService>();
            container.Register<IAmigoProximoService, AmigoProximoService>();
            container.Register<ICalculoHistoricoService, CalculoHistoricoService>();
            container.Register<IUsuarioService, UsuarioService>();

            #endregion

            #region Repository

            container.Register<IAmigoRepository, AmigoRepository>();
            container.Register<IAmigoProximoRepository, AmigoProximoRepository>();
            container.Register<ICalculoHistoricoRepository, CalculoHistoricoRepository>();
            container.Register<IUsuarioRepository, UsuarioRepository>();

            #endregion

        }
    }
}
