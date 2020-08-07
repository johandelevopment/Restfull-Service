using System;
using Data;
using Entities;

namespace Bussines
{
    public class BJwt
    {
        public JwtEntity ConsultarPropiedadesJwt(long Id)
        {
            try
            {
                JwtParametros j = new DJwt().ConsultarPropiedadesJwt(Id);
                JwtEntity jwt = new JwtEntity()
                {
                    JWT_AUDIENCE_TOKEN = j.JWT_AUDIENCE_TOKEN,
                    JWT_EXPIRE_MINUTES = j.JWT_EXPIRE_MINUTES,
                    JWT_ISSUER_TOKEN = j.JWT_ISSUER_TOKEN,
                    JWT_SECRET_KEY = j.JWT_SECRET_KEY
                };

                if (jwt == null)
                {
                }
                return jwt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Consultamos Jwt
        /// </summary>
        /// <param name="Jwt"></param>
        /// <returns></returns>
        public bool ConsultarJwt(string Jwt)
        {
            try
            {
                return new DJwt().ConsultarJwt(Jwt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método para eliminar token
        /// </summary>
        /// <param name="Jwt"></param>
        /// <returns></returns>
        public Resultado EliminarToken(string Jwt)
        {
            try
            {
                var resultado = new DJwt().EliminarJwt(Jwt);
                //int resultado = new DJwt().Delete(new OC_JWT
                //{ JWT = Jwt });

                if (resultado == -1)
                {
                    return new Resultado() { Respuesta = 1, Mensaje = "Token Eliminado" };
                }
                else
                {
                    return new Resultado() { Respuesta = 0, Mensaje = "Error al eliminar el token" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
