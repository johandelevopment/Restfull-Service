using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Data
{
    public class DExperience
    {
        public experiencia ExperienceCreate(ExperienceEntity experience)
        {
            experiencia result = new experiencia();

            using (var txscope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    int IdExperience = 0;
                    using (WantgoProdEntities ctx = new WantgoProdEntities())
                    {
                        experiencia newExperience = new experiencia
                        {
                            id_Categoria = experience.CategoryId,
                            id_Pais = experience.CountryId,
                            direccion = experience.Address,
                            descripcion = experience.Description
                        };
                        ctx.experiencia.Add(newExperience);
                        ctx.SaveChanges();
                        IdExperience = newExperience.id_Experiencia;
                        if (IdExperience > 0)
                        {
                            usuario_experiencia newUserExperiece = new usuario_experiencia
                            {
                                id_Experiencia = IdExperience,
                                id_usuario = experience.UserId
                            };
                            ctx.usuario_experiencia.Add(newUserExperiece);
                            ctx.SaveChanges();
                        }
                        result = newExperience;
                    }
                    txscope.Complete();
                }
                catch (Exception ex)
                {
                    txscope.Dispose();
                    throw ex;
                }
            }
            return result;
        }
        
        public bool ExperienceUpdatePath(string ruta, int ExperienceId)
        {
            bool result = false;
            try
            {
                using(WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var entidad = (from e in ctx.experiencia where e.id_Experiencia == ExperienceId select e).FirstOrDefault();
                    if(entidad != null)
                    {
                        entidad.ruta_multimedia = ruta;
                        ctx.SaveChanges();
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }      
    }
}
