using Bussines;
using Entities;
using System;
using System.Web.Http;

namespace wantgoService.Controllers
{
    [RoutePrefix("api/Countries")]
    public class PaisesController : ApiController
    {
        [HttpGet]
        [Route("Getcountries")]
        public IHttpActionResult Getcountries()
        {
            try
            {
                Resultado resultado = new Resultado();
                resultado = BPaises.Getcountries();
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }


    }
}
