using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bussines
{
    public class BPaises
    {
        public static Resultado Getcountries()
        {

            try
            {
                var query = new DPaises().Getcountries();
                List<PaisesEntities> PaisesList = new List<PaisesEntities>();
                foreach (var item in query)
                {
                    PaisesEntities pais = new PaisesEntities
                    {
                        id_Pais = item.id_Pais,
                        descripcion = item.descripcion,
                        nombre = item.nombre,
                        ruta_logo = item.ruta_logo,
                        deal = item.deal_Pais.ToString()
                    };
                    PaisesList.Add(pais);
                }
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
