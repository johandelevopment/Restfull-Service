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
    
    public partial class experiencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public experiencia()
        {
            this.usuario_experiencia = new HashSet<usuario_experiencia>();
        }
    
        public int id_Experiencia { get; set; }
        public string ruta_multimedia { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public int id_Pais { get; set; }
        public int id_Categoria { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_experiencia> usuario_experiencia { get; set; }
    }
}
