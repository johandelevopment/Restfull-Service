namespace ApiPruebas.Controllers
{
    using Bussines;
    using Entities;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    internal class TokenValidationHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                return base.SendAsync(request, cancellationToken);
            }
            try
            {
                long id = 1;
                BJwt jwt = new BJwt();
                var Jwt = jwt.ConsultarPropiedadesJwt(id);

                if (Jwt == null)
                {
                    Resultado resultado = new Resultado()
                    {
                        Mensaje = "No fue posible Consultar Propiedades Jwt: " + id.ToString(),
                        Respuesta = 0
                    };

                    HttpResponseMessage responseMessage = request.CreateResponse(resultado);
                    return Task<HttpResponseMessage>.Factory.StartNew(() => responseMessage);

                }
                var secretKey = Jwt.JWT_SECRET_KEY;
                var audienceToken = Jwt.JWT_AUDIENCE_TOKEN;
                var issuerToken = Jwt.JWT_ISSUER_TOKEN;

                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));

                SecurityToken securityToken;
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };

                // Extract and assign Current Principal and user
                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException ex)
            {
                statusCode = HttpStatusCode.Unauthorized;

                Resultado resultado = new Resultado()
                {
                    Mensaje = statusCode.ToString() + " 401.   Ex:" + ex.Message,
                    Respuesta = 0
                };
                HttpResponseMessage responseMessage = request.CreateResponse(resultado);
                return Task<HttpResponseMessage>.Factory.StartNew(() => responseMessage);

            }
            catch (Exception ex)
            {
                // throw ex;
                statusCode = HttpStatusCode.InternalServerError;
                Resultado resultado = new Resultado()
                {
                    Mensaje = statusCode.ToString() + " . :" + ex.Message,
                    Respuesta = 0
                };
                HttpResponseMessage responseMessage = request.CreateResponse(resultado);
                return Task<HttpResponseMessage>.Factory.StartNew(() => responseMessage);
            }

            //return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}