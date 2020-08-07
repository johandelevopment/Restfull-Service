using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class BPaises
    {
        public static Resultado Getcountries()
        {

            try
            {
                List<pais> PaisesList = new DPaises().Getcountries();
                if (PaisesList.Count > 0)
                {
                    return new Resultado() { Respuesta = 1, Mensaje = "Paises Encontrados", Valores = PaisesList };
                }
                else
                {
                    return new Resultado() { Respuesta = 0, Mensaje = "No se encontraron Paises ", Valores = null };
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
