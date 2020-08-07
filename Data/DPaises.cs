using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DPaises
    {
        public List<pais> Getcountries()
        {
            try
            {
                List<pais> listQuery = new List<pais>();

                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from t in ctx.pais select t);

                    if (query != null)
                    {
                        listQuery = query.ToList();
                    }  
                }
                return listQuery;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}