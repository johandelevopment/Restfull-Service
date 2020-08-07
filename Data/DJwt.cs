using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DJwt
    {
        public JwtParametros ConsultarPropiedadesJwt(long Id)
        {
            try
            {
                JwtParametros result = null;

                using (WantgoProdEntities context = new WantgoProdEntities())
                {
                    var request = from item in context.JwtParametros
                                  where item.ID == Id && item.STATUS == true
                                  select item;

                    result = request.FirstOrDefault<JwtParametros>();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public bool ConsultarJwt(string Jwt)
        {
            bool jwt = false;
            try
            {
                table_jwt jwtResult = null;
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var request = from item in ctx.table_jwt
                                  where item.jwt == Jwt
                                  select item;

                    jwtResult = request.FirstOrDefault<table_jwt>();

                    if (jwtResult != null)
                    {
                        return jwt = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return jwt;
        }

        public long CreateJwt(table_jwt jwt)
        {
            int result = -1;

            try
            {
                var ctx = new WantgoProdEntities();
                table_jwt token = new table_jwt()
                {
                    jwt = jwt.jwt
                };
                ctx.table_jwt.Add(token);
                result = ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return result;
        }

        public long EliminarJwt(string Jwt)
        {
            long id = -1;
            try
            {
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var acceso = ctx.table_jwt.Where(c => c.jwt == Jwt).FirstOrDefault();
                    ctx.table_jwt.Remove(acceso);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return id;
        }
    }
}
