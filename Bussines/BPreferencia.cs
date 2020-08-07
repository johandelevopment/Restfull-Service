using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class BPreferencia
    {
        public static Resultado GetPreferences()
        {
           var query = new DPreferencia().GetPreferences();
            List<EPreference> PreferencesList = new List<EPreference>();
            foreach(var item in query)
            {
                EPreference preference = new EPreference
                {
                    Name = item.descripcion,
                    Id = item.id_Preferencias,
                    Status =Convert.ToBoolean(item.estado)
                };
                PreferencesList.Add(preference);
            }

            if (PreferencesList.Count > 0)
            {
                return new Resultado() { Respuesta = 1, Mensaje = "Preferencias encontradas.", Valores = PreferencesList };
            }
            return new Resultado() { Respuesta = 0, Mensaje = "No se encontraron preferecias.", Valores = null };
        }
    }
}
