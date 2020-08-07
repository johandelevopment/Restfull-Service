using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;

namespace Bussines
{
    public class BProfile
    {
        public static Resultado GetProfile(RequestProfile request)
        {

            try
            {
                if (Convert.ToInt32(request.UserId) > 0)
                {
                    DataProfile profile = new DProfile().GetProfile(request);
                    if (profile.UserId >0 && profile.Email != null)
                    {
                        return new Resultado() { Respuesta = 1, Mensaje = "Exito", Valores = profile };
                    }
                    else
                    {
                        return new Resultado() { Respuesta = 0, Mensaje = "No se encontró información del perfil ", Valores = null };
                    }
                }
                return new Resultado() { Respuesta = 0, Mensaje = "No se encontró información del perfil ", Valores = null };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Resultado UpdateProfile(UpdateProfile request)
        {
            try
            {
                if (request.UserId <= 0)
                {
                    return new Resultado() { Respuesta = 0, Mensaje = "No se encontró usuario.", Valores = null };
                }
                if (request.Email == "")
                {
                    return new Resultado() { Respuesta = 0, Mensaje = "Debe ingregar correo.", Valores = null };
                }
                if (request.PhotoChange)
                {
                    var foto = Base64ToImage(request.PhotoUser);
                    if(foto != null)
                    {
                        return new Resultado() { Respuesta = 0, Mensaje = "La foto de perfil debe estar en base 64", Valores = null };
                    }
                    string rutaFoto = @"C:\Inetpub\vhosts\resources.com\httpdocs\Resources\Profiles\" + request.UserId + @"/foto_perfil.jpg";
                    //string rutaFoto = @"C:\Resources\Profiles\" + request.UserId + @"/foto_perfil.jpg";
                    var fotoEliminado = EliminarArchivo(rutaFoto);
                    if (fotoEliminado)
                    {
                        bool fotoGuardada = GuardarDocumentoImagen(rutaFoto, request.PhotoUser);
                        if (fotoGuardada)
                        {
                            var rutaCapetaDocumento = CrearCarpeta(request.UserId);
                            if (rutaCapetaDocumento != "")
                            {
                                bool guardarDocumento = GuardarDocumentoImagen(rutaCapetaDocumento, request.PdfDocument);
                                if (guardarDocumento)
                                {
                                    var actualizar = new DProfile().UpdateProfile(request);
                                    if (actualizar)
                                    {
                                        return new Resultado() { Respuesta = 1, Mensaje = "Datos actualzados", Valores = null };
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    var rutaCapetaDocumento = CrearCarpeta(request.UserId);
                    if (rutaCapetaDocumento != "")
                    {
                        string ruta = rutaCapetaDocumento +@"\"+request.UserId+@"documento_cedula.pdf";
                        bool guardarDocumento = GuardarDocumentoImagen(ruta, request.PdfDocument);
                        if (guardarDocumento)
                        {
                            var actualizar = new DProfile().UpdateProfile(request);
                            if (actualizar)
                            {
                                return new Resultado() { Respuesta = 1, Mensaje = "Datos actualzados", Valores = null };
                            }
                        }
                    }
                }
                return new Resultado() { Respuesta = 0, Mensaje = "Error actualizando ", Valores = null };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EliminarArchivo(string ruta)
        {

            BImpersonalizacion impersonalizacion = new BImpersonalizacion();
            Boolean impersonalizado = false;
            try
            {
                impersonalizado = impersonalizacion.impersonateValidUser("wantgoadmin", "NH", "Wantgodesa20$*");
               //impersonalizado = impersonalizacion.impersonateValidUser("jsmartinga", "NH", "C0r0n42020*");
                Directory.Delete(ruta);
                return true;
            }
            catch (Exception)
            {
                return false;
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
        private static bool GuardarDocumentoImagen(string ruta, string multimedia)
        {
            bool save;
            BImpersonalizacion impersonalizacion = new BImpersonalizacion();
            Boolean impersonalizado = false;
            try
            {
                impersonalizado= impersonalizacion.impersonateValidUser("wantgoadmin", "NH", "Wantgodesa20$");
                //impersonalizado = impersonalizacion.impersonateValidUser("jsmartinga", "NH", "C0r0n42020*");
                byte[] fileBytes = Convert.FromBase64String(multimedia);
                File.WriteAllBytes(ruta, fileBytes);
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
            finally
            {
                // Deshacemos la personalización al finalizar
                if (impersonalizado)
                {
                    impersonalizacion.undoImpersonation();
                };
            }
        }       
        public static string CrearCarpeta(int userId)
        {
           string Ruta = @"C:\Inetpub\vhosts\resources.com\httpdocs\Resources\Documents\" + userId;
            //string Ruta = @"C:\Resources\Documents\" + userId;
            BImpersonalizacion impersonalizacion = new BImpersonalizacion();
            Boolean impersonalizado = false;

            try
            {
               impersonalizado = impersonalizacion.impersonateValidUser("wantgoadmin", "NH", "Wantgodesa20$");
              // impersonalizado = impersonalizacion.impersonateValidUser("jsmartinga", "NH", "C0r0n42020*");
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
        public static Image Base64ToImage(string base64String)
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
