using Bussines;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace wantgoService.Controllers
{
    [RoutePrefix("api")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult createUser(userEntity usuario)
        {
            try
            {
                Resultado resultado = new BUser().createUser(usuario);
                if (resultado.Respuesta == 1)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IHttpActionResult ChangePassword(RequestChangePassword request)
        {
            try
            {
                bool autorization = false;
                if (Request.Headers.Authorization != null)
                {
                    string Jwt = Request.Headers.Authorization.Parameter;
                    autorization = new BJwt().ConsultarJwt(Jwt);
                }             

                if (!autorization)
                {
                    Resultado res = new Resultado() { Mensaje = "Token Invalido", Respuesta = 0 };
                    return Ok(res);
                }
                Resultado resultado = new BUser().ChangePassword(request);
                if (resultado.Respuesta == 1)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
