using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DataPais
    {
        public int id_Pais { get; set; }
        public string nombre { get; set; }
        public Nullable<int> deal_Pais { get; set; }
        public string descripcion { get; set; }
        public string base64 { get; set; }
    }
}
