using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Bussines
{
    public class BseguirPaises
    {
        public Resultado follow_countries(seguirPaises seguir)
        {
            seguimiento_usuario_pais newfollow_countries = new seguimiento_usuario_pais
            {
                id_usuario = seguir.id_Usuario,
                id_pais = seguir.id_Pais
            };

            try
            {
                var varPaiSeguido = new DseguirPais().PaisSeguido(seguir);
                if (varPaiSeguido)
                {
                    return new Resultado() { Respuesta = 0, Mensaje = "Ya se encuentra siguiendo este pais", Valores = null };
                }
                var seguirPaises = new DseguirPais().follow_countries(newfollow_countries);

                if (seguirPaises != null)
                {
                    return new Resultado() { Respuesta = 1, Mensaje = "Pais seguido exitosamente", Valores = null };
                }
                return new Resultado() { Respuesta = 0, Mensaje = "Usuario no existe en la aplicacion", Valores = null };
            }
            catch (Exception ex)
            {
                return new Resultado() { Respuesta = 0, Mensaje = ex.Message, Valores = null };
            }
        }
    }
}
