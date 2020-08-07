using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProfile
    {
        public DataProfile GetProfile(RequestProfile request)
        {
            try
            {
                DataProfile dataProfile = new DataProfile();
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario
                                 join pa in ctx.pais on u.id_Pais equals pa.id_Pais
                                 join per in ctx.perfil on u.id_usuario equals per.id_usuario
                                 into Perfil
                                 from pe in Perfil.DefaultIfEmpty()
                                 where u.id_usuario == request.UserId
                                 select new DataProfile
                                 {
                                     UserId = u.id_usuario,
                                     Names = pe.nombre_usuario,
                                     UserName = u.usuario1,
                                     Sex = u.Sexo,
                                     PhoneNumber = u.telefono,
                                     Email = u.correo,
                                     Description = pe.descripcion,
                                     UserPhoto = u.foto_Perfil,
                                     CountryPhoto = pa.ruta_logo,
                                     CountryDeal = pa.deal_Pais.ToString()
                                 }).FirstOrDefault();
                    if (query != null)
                    {
                        dataProfile = query;
                        dataProfile.ListPreferences = new List<string>();
                        var preferences = (from p in ctx.preferencias_usuario
                                           join pre in ctx.preferencias on p.id_Preferencias equals pre.id_Preferencias
                                           where p.id_usuario == query.UserId
                                           select pre).ToList();
                        foreach (var item in preferences)
                        {
                            dataProfile.ListPreferences.Add(item.descripcion);
                        }
                    }
                }
                return dataProfile;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool UpdateProfile(UpdateProfile request)
        {
            try
            {
                bool result = false;
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario where u.id_usuario == request.UserId select u).FirstOrDefault();
                    if (query != null)
                    {
                        var profile = (from p in ctx.perfil where p.id_usuario == query.id_usuario select p).FirstOrDefault();
                        var emergency = (from e in ctx.contacto_emergencia where e.id_usuario == query.id_usuario select e).FirstOrDefault();

                        query.Sexo = request.Sex;
                        query.telefono = request.PhoneNumber;
                        query.usuario1 = request.UserName;
                        query.correo = request.Email;
                        if (profile != null)
                        {
                            profile.nombre_usuario = request.Names;
                            profile.apellido_usuario = request.LastNames;
                            profile.descripcion = request.Description;
                            profile.cedula = request.Document;
                            profile.rh = request.Rh;
                            profile.ciudad_nacimiento = request.BornCity;
                            profile.ocupacion = request.Ocupation;
                            profile.idiomas = request.Languages;
                            profile.fecha_nacimiento = request.DateBorn;
                            profile.numero_pasaporte = request.PassporNumber;
                        }
                        else
                        {
                            perfil nuevoPerfil = new perfil
                            {
                                nombre_usuario =request.Names,
                                apellido_usuario = request.LastNames,
                                descripcion = request.Description,
                                cedula = request.Document,
                                rh = request.Rh,
                                ciudad_nacimiento = request.BornCity,
                                ocupacion = request.Ocupation,
                                idiomas = request.Languages,
                                fecha_nacimiento = request.DateBorn,
                                numero_pasaporte = request.PassporNumber
                            };
                            ctx.perfil.Add(nuevoPerfil);
                        }

                        if (emergency != null)
                        {
                            emergency.nombre = request.EmergencyName;
                            emergency.telefono = request.EmergencyPhone;
                            emergency.correo = request.EmergencyEmail;
                        }
                        else
                        {
                            contacto_emergencia emergencia = new contacto_emergencia
                            {
                                nombre = request.EmergencyName,
                                correo = request.EmergencyEmail,
                                telefono = request.EmergencyPhone,
                                id_usuario = request.UserId
                            };
                            ctx.contacto_emergencia.Add(emergencia);
                        }

                        ctx.SaveChanges();
                        result = true;
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
