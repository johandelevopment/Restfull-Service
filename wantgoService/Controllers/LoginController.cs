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
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(LoginRequest login)
        {
            try
            {
                Resultado resultado = new Resultado();
                resultado = BLogin.ValidarAcceso(login);
                if (resultado.Respuesta == 1)
                {
                    return Ok(resultado);
                }             
                 return BadRequest(resultado.Mensaje);
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
        [HttpPost]
        [Route("Remember")]
        public IHttpActionResult Remember(LoginRequest login)
        {
            try
            {
                Resultado resultado = new Resultado();
                resultado = BLogin.RecordarPassword(login);
                if (resultado.Respuesta == 1)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest(resultado.Mensaje);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        
        }
    }
}
