using Data;
using Entities;
using System;
using System.Net;
using System.Net.Mail;

namespace Bussines
{
    public class BLogin
    {
        public static Resultado ValidarAcceso(LoginRequest login)
        {
            Resultado resultado = new Resultado();
            LoginResult loginResult = new LoginResult();
            try
            {
                var usuario = new DUsuario().ConsultarUsuario(login);
                if (usuario.correo != null)
                {
                    var tokenJwt = BTokenGenerator.GenerateTokenJwt(usuario);

                    table_jwt jwt = new table_jwt()
                    {
                        jwt = tokenJwt
                    };
                    long InsertJwt = new DJwt().CreateJwt(jwt);

                    if (InsertJwt == -1)
                    {
                        resultado.Respuesta = 0;
                        resultado.Mensaje = "No fue posible almacenar el Jwt en BD";
                        resultado.Valores = null;
                    }
                    loginResult.jwt = tokenJwt;

                    resultado.Respuesta = 1;
                    resultado.Mensaje = "Exito";
                    resultado.Valores = loginResult;

                }
                else
                {
                    string Msg = "Usuario o contraseña incorrectos.";
                    resultado.Mensaje = Msg;
                    resultado.Respuesta = 0;

                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        public static Resultado RecordarPassword(LoginRequest login)
        {
            try
            {
                var usuario = new DUsuario().ConsultarUsuarioEmail(login);
                if (usuario != null)
                {
                    var result = sendMail(usuario);
                    if (result != -1)
                    {
                        return new Resultado { Respuesta = 1, Mensaje = "Correo electrónico enviado." };
                    }
                    return new Resultado { Respuesta = 0, Mensaje = "No fue posible enviar el correo electrónico." };
                }
                return new Resultado { Respuesta = 0, Mensaje = "No fue posible enviar el correo electrónico." };
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static long sendMail(usuario _user)
        {
            long result = -1;

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("noreply@wantgo.com");
            message.To.Add(new MailAddress(_user.correo));
            message.Subject = "Wantgo - Recordar Contraseña";
            message.IsBodyHtml = true;
            message.Body = getHtml(_user);
            smtp.Port = 25;
            smtp.Host = "198.12.253.112";
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("noreply@wantgo.com", "Wantgodesa20$");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
                result = 1;
            }
            catch (SmtpException ex)
            {
                return result;
            }
            return result;
        }
        private static string getHtml(usuario user)
        {
            string html = @"<div bgcolor='#f3f3f3' style='margin:5px 0 0 0;padding:0;background-color:#f3f3f3'><p></p>"
        + "<table bgcolor = '#f3f3f3' border='0' cellpadding='0' cellspacing ='0' style = 'color:#4a4a4a;font-family:'Museo Sans Rounded',Museo Sans Rounded,'Museo Sans',Museo Sans,'Helvetica Neue',Helvetica,Arial,sans-serif;font-size:14px;line-height:20px;border-collapse:callapse;border-spacing:0;margin:0 auto' width='100%'>"
        + "<tbody><tr><td style ='padding-left:20px;padding-right:20px'><table align ='center' border ='0' cellpadding = '0 cellspacing = '0' style = 'width:100%;margin:0 auto;max-width:600px' width = '100%'>"
        + "<tbody><tr style = 'background: white;font-weight: bold;'><td style = 'text-align:center;padding-top:3%'>RECORDAR CONTRASEÑA</td></tr><tr><td bgcolor = '#ffffff' style = 'background-color:#ffffff;padding:9%'>"
        + "<table border = '0' cellpadding = '0' cellspacing = '0' id = 'm_-740823046140379716intro' style = 'width:100%;margin:0 auto'><tbody><tr><td style = 'max-width:600px' width = '100%'>"
        + "¿Olvidaste tu contraseña? No hay problema, a continuacion te enviamos tus datos de acceso.<br><br>Usuario: [usuario]<br>Password: [password]<br></td></tr></tbody></table></td></tr>"
        + "<tr><td border = '0' cellpadding='0' cellspacing='0' style='padding:20px 0' width='100%'><table border = '0' cellpadding='0' cellspacing='0' style='border-collapse:collapse' width='100%'>"
        + "<tbody><tr>"
        + "<td style = 'padding:20px' width='100%'><div style = 'margin:0;text-align:center;font-size:12px;color:#bbbbbb'> NO RESPONDER - Mensaje Generado Automáticamente</div><div style = 'margin:0;font-size:11px;text-align:center;color:#bbbbbb' >© 2020 Wantgo | Bogotá, Colombia</div>"
        + "</td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></div>";
            html = html.Replace("[usuario]", user.correo);
            html = html.Replace("[password]", user.password);

            return html;
        }
    }
}

