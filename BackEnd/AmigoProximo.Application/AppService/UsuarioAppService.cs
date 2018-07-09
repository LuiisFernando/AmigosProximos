using AmigoProximo.Application.AppService.Interfaces;
using AmigoProximo.Domain.Entities;
using AmigoProximo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.AppService
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private IUsuarioService _service;

        public UsuarioAppService(IUsuarioService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
