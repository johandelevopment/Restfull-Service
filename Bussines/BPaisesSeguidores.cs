using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Bussines
{
    public class BPaisesSeguidores
    {
        public static Resultado return_follower_countries()
        {
            List<ListPaisSeguidos> CategoriesList = new DPaisesSeguidores().return_follower_countries();
            if (CategoriesList.Count > 0)
            {
                return new Resultado() { Respuesta = 1, Mensaje = "Paises encontrados.", Valores = CategoriesList };
            }
            return new Resultado() { Respuesta = 0, Mensaje = "No se encontraron Paises.", Valores = null };
        }
    }
}
