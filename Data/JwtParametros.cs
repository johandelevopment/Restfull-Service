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
    
    public partial class JwtParametros
    {
        public int ID { get; set; }
        public string JWT_SECRET_KEY { get; set; }
        public string JWT_AUDIENCE_TOKEN { get; set; }
        public string JWT_ISSUER_TOKEN { get; set; }
        public string JWT_EXPIRE_MINUTES { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public string AUTHORIZED_SERVER { get; set; }
    }
}
