namespace Bussines
{
    using Data;
    using Entities;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Security.Claims;
    using System.Security.Principal;

    public class BTokenGenerator
    {
        public static string GenerateTokenJwt(DataUsuario usuario)
        {
            try
            {

                DJwt jwt = new DJwt();
                var Jwt = jwt.ConsultarPropiedadesJwt(1);
                var secretKey = Jwt.JWT_SECRET_KEY;
                var expireTime = Jwt.JWT_EXPIRE_MINUTES;
                var audienceToken = Jwt.JWT_AUDIENCE_TOKEN;
                var issuerToken = Jwt.JWT_ISSUER_TOKEN;
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(new Claim("id_usuario", usuario.id_usuario.ToString()));
                claimsIdentity.AddClaim(new Claim("usuario", usuario.usuario.ToString()));
                claimsIdentity.AddClaim(new Claim("sexo", usuario.Sexo.ToString()));
                claimsIdentity.AddClaim(new Claim("telefono", usuario.telefono.ToString()));
                claimsIdentity.AddClaim(new Claim("correo", usuario.correo.ToString()));
                claimsIdentity.AddClaim(new Claim("pais", usuario.pais.ToString()));
                claimsIdentity.AddClaim(new Claim("foto_usuario", usuario.foto_Perfil.ToString()));
                claimsIdentity.AddClaim(new Claim("foto_pais", usuario.foto_pais.ToString()));
                claimsIdentity.AddClaim(new Claim("pasaporte", usuario.pasaporte.ToUpper()));
                // Creamos el token con el usuario
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                    audience: audienceToken,
                    issuer: issuerToken,
                    subject: claimsIdentity,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                    signingCredentials: signingCredentials);

                var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
                return jwtTokenString;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
