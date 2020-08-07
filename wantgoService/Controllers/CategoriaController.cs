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
    [RoutePrefix("api/Category")]
    public class CategoriaController : ApiController
    {
        [HttpGet]
        [Route("GetCategories")]
        public IHttpActionResult GetPreferences()
        {
            try
            {
                Resultado resultado = new Resultado();
                resultado = BCategoria.GetCategories();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
