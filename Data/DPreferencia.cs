using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DPreferencia
    {
        public List<preferencias> GetPreferences()
        {
            try
            {
                List<preferencias> PreferencesList = null;
                using (WantgoProdEntities ctx = new WantgoProdEntities())
                {
                    var query = (from p in ctx.preferencias where p.estado == true select p);
                    if (query != null)
                    {
                        PreferencesList = query.ToList();
                    }
                    return PreferencesList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
