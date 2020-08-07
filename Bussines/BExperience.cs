using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class BExperience
    {
        public Resultado ExperienceCreate(ExperienceEntity experience)
        {
            try
            {
                var foto = Base64ToImage(experience.ExperiencePhoto);
                if (foto != null)
                {
                    string datosObligatorios = ValidateJson(experience);
                    if (datosObligatorios == "")
                    {
                        var usuarioValido = new DUsuario().ConsultarUsuarioId(experience.UserId);
                        if(usuarioValido == 0)
                        {
                            return new Resultado() { Respuesta = 0, Mensaje = "Id de usuario no existe" , Valores = null };
                        }
                        experiencia experienciaCreada = new DExperience().ExperienceCreate(experience);
                        if (experienciaCreada != null)
                        {
                            try
                            {
                                string ruta = CrearCarpeta(experienciaCreada.id_Experiencia, experience.UserId);
                                if (ruta != "")
                                {
                                    var imageName = "experienceImage"+experienciaCreada.id_Experiencia + experience.UserId + ".jpg";
                                    bool fotoGuardada = GuardarFoto(ruta,imageName, experience.ExperiencePhoto);
                                    if (fotoGuardada)
                                    {
                                        string updateruta = @"Resources/Experiences/" + experienciaCreada.id_Experiencia+"-"+ experience.UserId + @"/"+imageName;
                                        var actualizarRuta = new DExperience().ExperienceUpdatePath(updateruta, experienciaCreada.id_Experiencia);
                                        return new Resultado() { Respuesta = 1, Mensaje = "Experiencia guardada", Valores = null };
                                    }                                    
                                }
                            }
                            catch (Exception ex)
                            {

                                return new Resultado() { Respuesta = 0, Mensaje = "Error " + ex, Valores = null };
                            }

                        }
                        else
                        {
                            return new Resultado() { Respuesta = 0, Mensaje = "Error al guardar experiencia", Valores = null };
                        }
                    }
                    else
                    {
                        return new Resultado() { Respuesta = 0, Mensaje = datosObligatorios, Valores = null };
                    }
                }
                return new Resultado() { Respuesta = 0, Mensaje = "Formato de la foto que intenta cargar no es válido, debe estar en base 64", Valores = null };
            }
            catch (Exception ex)
            {

                return new Resultado() { Respuesta = 0, Mensaje = "Error al guardar experiencia", Valores = ex };
            }

        }
        public string CrearCarpeta(int experienceId, int userId)
        {
            string Ruta = @"C:\Inetpub\vhosts\resources.com\httpdocs\Resources\Experiences\" + userId + "-" + experienceId;
            BImpersonalizacion impersonalizacion = new BImpersonalizacion();
            Boolean impersonalizado = false;

            try
            {
                impersonalizado = impersonalizacion.impersonateValidUser("wantgoadmin", "NH", "Wantgodesa20$");

                if (!Directory.Exists(Ruta))
                {
                    DirectoryInfo directorio = Directory.CreateDirectory(Ruta);
                    Ruta = directorio.FullName.ToString();
                }
                return Ruta;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                // Deshacemos la personalización al finalizar
                if (impersonalizado)
                {
                    impersonalizacion.undoImpersonation();
                };
            }
        }
        private static bool GuardarFoto(string ruta,string imageName, string image)
        {
            bool save;
            try
            {
                BImpersonalizacion OImpersonalizacion = new BImpersonalizacion();
                OImpersonalizacion.impersonateValidUser("wantgoadmin", "NH", "Wantgodesa20$");

                ruta += @"\"+imageName;
                byte[] imageBytes = Convert.FromBase64String(image);
                File.WriteAllBytes(ruta, imageBytes);
                if (File.Exists(ruta))
                {
                    return save = File.Exists(ruta);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
        private static string ValidateJson(ExperienceEntity experience)
        {
            string result = "";
            if (experience.CategoryId <= 0 || experience.CountryId <= 0 || experience.Address == "" || experience.UserId <= 0)
            {
                result = "Valide que los datos obligatorios esten diligenciados.";
            }
            return result;
        }
        public Image Base64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    return image;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
