using Data;
using Entities;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace Bussines
{
    public class BUser
    {
        public Resultado createUser(userEntity usuario)
        {
            var fotoPerfil = Base64ToImage(usuario.foto_Perfil);
            var passport = passportNumer();

            while (new DUsuario().validPassportNumber(passport))
            {
                passport = passportNumer();
            }
            
            usuario newUsuario = new usuario
            {
                usuario1 = usuario.usuario,
                Sexo = usuario.sexo,
                correo = usuario.correo,
                telefono = usuario.telefono,
                password = usuario.password,
                foto_Perfil = usuario.foto_Perfil,
                id_Pais = usuario.id_Pais,
                pasaporte = passport
            };

            try
            {
                var Usuario = new DUsuario().ValidarUsuario(usuario.correo);
                if (Usuario)
                {
                    return new Resultado() { Respuesta = 0, Mensaje = "El correo que intenta registrar ya se encuentra activo", Valores = null };
                }

                if (fotoPerfil != null)
                {
                    try
                    {
                        int Id = new DUsuario().GetLastId();
                        string ruta = CrearCarpeta(Id + 1);
                        if (ruta != "")
                        {
                            bool fotoGuardada = GuardarFoto(ruta, newUsuario.foto_Perfil);
                            if (fotoGuardada)
                            {
                                var usuarioCreado = new DUsuario().CreateUsuario(newUsuario, usuario.preferences);
                                LoginResult loginResult = new LoginResult();
                                string updateruta = @"Resources/Profiles/" + usuarioCreado.id_usuario + @"/foto_perfil.jpg";
                                var actualizarRuta = new DUsuario().ActualizarRutaFotoUsuario(updateruta, usuarioCreado.correo);
                                LoginRequest login = new LoginRequest { email = usuarioCreado.correo, password = usuarioCreado.password };
                                var usuarioToken = new DUsuario().ConsultarUsuario(login);

                                var tokenJwt = BTokenGenerator.GenerateTokenJwt(usuarioToken);
                                table_jwt jwt = new table_jwt()
                                {
                                    jwt = tokenJwt
                                };
                                long InsertJwt = new DJwt().CreateJwt(jwt);

                                if (InsertJwt == -1)
                                {
                                    return new Resultado() { Respuesta = 1, Mensaje = "Error generardo token", Valores = null };
                                }
                                loginResult.jwt = tokenJwt;
                                return new Resultado() { Respuesta = 1, Mensaje = "Usuario creado exitosamente", Valores = loginResult };
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        return new Resultado() { Respuesta = 0, Mensaje = "No fue posible guardar la foto, revise que este en el formato correcto Base 64", Valores = null };
                    }
                }
                return new Resultado() { Respuesta = 0, Mensaje = "La foto de perfil debe estar en base 64", Valores = null };

            }
            catch (Exception ex)
            {
                return new Resultado() { Respuesta = 0, Mensaje = "Error " + ex, Valores = null };
            }
        }
        public Resultado ChangePassword(RequestChangePassword request)
        {
            try
            {
                var changed = new DUsuario().ChangePassword(request);
                if (changed)
                {
                    return new Resultado() { Respuesta = 1, Mensaje = "Contraseña cambiada", Valores = null };
                }
                return new Resultado() { Respuesta = 0, Mensaje = "Datos ingresados invalidos", Valores = null };
            }
            catch (Exception ex)
            {

                return new Resultado() { Respuesta = 0, Mensaje = "Error", Valores = ex };
            }
        }
        public string CrearCarpeta(int userId)
        {
            string Ruta = @"C:\Inetpub\vhosts\resources.com\httpdocs\Resources\Profiles\" + userId;
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
        private static bool GuardarFoto(string ruta, string image)
        {
            bool save;
            try
            {
                BImpersonalizacion OImpersonalizacion = new BImpersonalizacion();
                OImpersonalizacion.impersonateValidUser("wantgoadmin", "NH", "Wantgodesa20$");

                ruta += @"\foto_perfil.jpg";
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
        private static string passportNumer()
        {
            string passportNumer = "";
            try
            {
                int _min = 1000;
                int _max = 9999;
                int contChar;
                string randomChar = string.Empty;
                Random _rdm = new Random();
                var randomNumber = _rdm.Next(_min, _max);
                for (contChar = 1; contChar <= 4; contChar++)
                {
                    randomChar += (char)_rdm.Next('a', 'z');
                }
                passportNumer += randomChar;
                passportNumer += randomNumber;

                return passportNumer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
