using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DCategoria
    {
        public List<categoria> GetCategories()
        {
            try
            {
                List<categoria> CategoriesList = null;
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from c in ctx.categoria select c);
                    if (query != null)
                    {
                        CategoriesList = query.ToList();
                    }
                    return CategoriesList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
