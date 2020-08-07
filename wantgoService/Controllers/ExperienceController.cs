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
    [RoutePrefix("api/Experience")]
    public class ExperienceController : ApiController
    {

        [HttpPost]
        [Route("ExperienceCreate")]
        public IHttpActionResult ExperienceCreate(ExperienceEntity experience)
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
                Resultado resultado = new BExperience().ExperienceCreate(experience);
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
