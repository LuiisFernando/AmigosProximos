using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AmigoProximo.WebAPI.Provider
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {

                //var _usuario = _serviceUsuario.Find(wh => wh.Login == context.UserName.Replace(".", "").Replace("-", ""), i => i.Perfil);

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, "luis"));
                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, _usuario.ID));
                //identity.AddClaim(new Claim(ClaimTypes.Role, _usuario.Perfil.Codigo.ToString()));

                context.Validated(identity);

            }
            catch (Exception ex)
            {
                context.SetError("error", ex.Message);
            }
        }
    }
}