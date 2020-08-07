using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DUsuario
    {
        public DataUsuario ConsultarUsuario(LoginRequest login)
        {
            DataUsuario usuario = new DataUsuario();
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var result = (from item in ctx.usuario
                                  join p in ctx.pais on item.id_Pais equals p.id_Pais
                                  where item.correo == login.email
                                  && item.password == login.password
                                  select new
                                  {
                                      item.id_usuario,
                                      item.usuario1,
                                      item.correo,
                                      item.Sexo,
                                      item.telefono,
                                      item.foto_Perfil,
                                      item.pasaporte,
                                      p.nombre,
                                      p.ruta_logo
                                  });

                    if (result != null)
                    {
                        foreach (var u in result)
                        {

                            DataUsuario dataUsuario = new DataUsuario()
                            {
                                id_usuario = u.id_usuario,
                                usuario = u.usuario1,
                                correo = u.correo,
                                foto_Perfil = u.foto_Perfil,//cambio solicitado
                                pais = u.nombre,
                                Sexo = u.Sexo,
                                telefono = u.telefono,
                                foto_pais = u.ruta_logo,
                                pasaporte = u.pasaporte
                            };
                            usuario = dataUsuario;
                        }
                        return usuario;
                    }
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            return usuario;
        }
        public usuario ConsultarUsuarioEmail(LoginRequest login)
        {
            try
            {
                usuario _usuario = new usuario();
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario where u.correo == login.email select u).FirstOrDefault();
                    _usuario = query;
                }
                return _usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int ConsultarUsuarioId(int Id)
        {
            int result = 0;
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario where u.id_usuario == Id select u).FirstOrDefault();
                    if (query != null)
                    {
                        result = query.id_usuario;
                    }
                }
                return result;
            }
            catch (Exception)
            {

                return result;
            }
        }
        public bool ChangePassword(RequestChangePassword request)
        {
            try
            {
                bool result = false;
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario
                                 where request.UserId == u.id_usuario && request.OldPassword == u.password
                                 select u).FirstOrDefault();
                    if (query != null)
                    {
                        query.password = request.NewPassword;
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
        public bool ValidarUsuario(string email)
        {
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario where u.correo == email select u).FirstOrDefault();
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
        public usuario CreateUsuario(usuario user, List<int> preferences)
        {
            usuario result = new usuario();
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    usuario newUser = new usuario
                    {
                        usuario1 = user.usuario1,
                        password = user.password,
                        Sexo = user.Sexo,
                        correo = user.correo,
                        telefono = user.telefono,
                        id_Pais = user.id_Pais,
                        pasaporte = user.pasaporte
                    };
                    ctx.usuario.Add(newUser);
                    ctx.SaveChanges();
                    result = newUser;
                    if (result != null)
                    {
                        if (preferences != null)
                        {
                            foreach (var item in preferences)
                            {
                                preferencias_usuario newPreferencia = new preferencias_usuario
                                {
                                    id_Preferencias = item,
                                    id_usuario = newUser.id_usuario
                                };
                                ctx.preferencias_usuario.Add(newPreferencia);
                                ctx.SaveChanges();
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ActualizarRutaFotoUsuario(string ruta, string email)
        {
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario where u.correo == email select u).FirstOrDefault();
                    if (query != null)
                    {
                        query.foto_Perfil = ruta;
                        ctx.SaveChanges();
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
        public int GetLastId()
        {
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var user = ctx.usuario.Max(u => u.id_usuario);
                    return user;
                }
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public bool validPassportNumber(string passport)
        {
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from u in ctx.usuario where u.pasaporte == passport select u).FirstOrDefault();
                    if (query != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
