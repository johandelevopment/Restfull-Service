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
    [Authorize]
    [RoutePrefix("api/Profile")]
    public class ProfileController : ApiController
    {
        [HttpGet]
        [Route("GetProfile")]
        public IHttpActionResult Getcountries(RequestProfile request)
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
                Resultado resultado = new Resultado();
                resultado = BProfile.GetProfile(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        
        [HttpPost]
        [Route("UpdateProfile")]
        public  IHttpActionResult UpdateProfile(UpdateProfile request)
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
                Resultado resultado = new Resultado();
                resultado = BProfile.UpdateProfile(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
