using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class DseguirPais
    {
        public bool PaisSeguido(seguirPaises seguir)
        {
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.seguimiento_usuario_pais 
                                 where u.id_pais == seguir.id_Pais && u.id_usuario == seguir.id_Usuario  select u).FirstOrDefault();
                    if (query != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public seguimiento_usuario_pais follow_countries(seguimiento_usuario_pais seguir)
        {
            seguimiento_usuario_pais result = new seguimiento_usuario_pais();
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario where u.id_usuario == seguir.id_usuario select u).FirstOrDefault();
                    if (query != null)
                    {
                        seguimiento_usuario_pais newSeguirPaises = new seguimiento_usuario_pais
                        {
                            id_usuario = seguir.id_usuario,
                            id_pais = seguir.id_pais
                        };
                        ctx.seguimiento_usuario_pais.Add(newSeguirPaises);
                        ctx.SaveChanges();
                        result = newSeguirPaises;
                    }
                    else
                    {
                        result = null;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
