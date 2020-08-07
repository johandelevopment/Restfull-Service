using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class userEntity
    {
        public string usuario { get; set; }
        public string sexo { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string foto_Perfil { get; set; }
        public int id_Pais { get; set; }
        public List<int> preferences { get; set; }
    }
}
