using AmigoProximo.Application.AppService.Interfaces;
using AmigoProximo.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmigoProximo.WebAPI.Controllers
{
    [RoutePrefix("api/amigo")]
    public class AmigoController : ApiController
    {
        private readonly IAmigoAppService _amigoService;

        public AmigoController(IAmigoAppService AmigoService)
        {
            this._amigoService = AmigoService;
        }

        [Authorize, Route("obterAmigos"), HttpGet]
        public IHttpActionResult ObterAmigos()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var amigos = _amigoService.ObterAmigos();

            return Ok(amigos);
        }

        [Route("obterAmigosProximos/{ID:int}"), HttpGet]
        public IHttpActionResult ObterAmigosProximos(int ID)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var amigosProximos = _amigoService.ObterAmigosProximos(ID);

                return Ok(amigosProximos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize, Route("cadastrar"), HttpPost]
        public IHttpActionResult CadastrarAmigo(AmigoVM model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _amigoService.CadastrarAmigo(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize, Route("excluir"), HttpPost]
        public IHttpActionResult ExcluirAmigo(AmigoVM model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _amigoService.ExcluirAmigo(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
