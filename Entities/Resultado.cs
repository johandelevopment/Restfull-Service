using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public class Resultado
    {
        [DataMember(Order = 1)]
        public int Respuesta { get; set; }

        [DataMember(Order = 2)]
        public string Mensaje { get; set; }

        [DataMember(Order = 3)]
        public object Valores { get; set; }
    }
}
