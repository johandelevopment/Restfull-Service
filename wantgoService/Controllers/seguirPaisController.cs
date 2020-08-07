using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Bussines;

namespace wantgoService.Controllers
{
    [Authorize]
    [RoutePrefix("api")]
    public class seguirPaisController : ApiController
    {
        [HttpPost]
        [Route("follow_countries")]
        public IHttpActionResult createUser(seguirPaises seguir)
        {
            try
            {
                Resultado resultado = new BseguirPaises().follow_countries(seguir);
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
