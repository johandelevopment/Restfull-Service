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
    
    public partial class preferencias_usuario
    {
        public int id_preferencia_usuario { get; set; }
        public int id_Preferencias { get; set; }
        public int id_usuario { get; set; }
    
        public virtual preferencias preferencias { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
