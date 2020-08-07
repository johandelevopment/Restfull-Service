using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DataUsuario
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string Sexo { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string foto_Perfil { get; set; }
        public string pais { get; set; }
        public string foto_pais { get; set; }
        public string pasaporte { get; set; }
    }
}
