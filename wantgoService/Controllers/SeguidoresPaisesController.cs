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
    public class SeguidoresPaisesController : ApiController
    {

        [HttpGet]
        [Route("return_follower_countries")]
        public IHttpActionResult return_follower_countries()
        {
            try
            {
                Resultado resultado = new Resultado();
                resultado = BPaisesSeguidores.return_follower_countries();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
