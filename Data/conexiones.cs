//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class conexiones
    {
        public int id_Conexiones { get; set; }
        public int id_usuario { get; set; }
        public int id_usuario_conexion { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public System.DateTime ultima_modificacion { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}