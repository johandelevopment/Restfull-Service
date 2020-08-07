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
    [RoutePrefix("api/Preference")]

    public class PreferenciaController : ApiController
    {
        [HttpGet]
        [Route("GetPreferences")]
        public IHttpActionResult GetPreferences()
        {
            try
            {
                Resultado resultado = new Resultado();
                resultado = BPreferencia.GetPreferences();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
