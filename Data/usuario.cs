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
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.contacto_emergencia = new HashSet<contacto_emergencia>();
            this.perfil = new HashSet<perfil>();
            this.preferencias_usuario = new HashSet<preferencias_usuario>();
            this.publicacion_anfitrion = new HashSet<publicacion_anfitrion>();
            this.seguimiento_usuario_pais = new HashSet<seguimiento_usuario_pais>();
            this.usuario_experiencia = new HashSet<usuario_experiencia>();
            this.conexiones = new HashSet<conexiones>();
        }
    
        public int id_usuario { get; set; }
        public string usuario1 { get; set; }
        public string Sexo { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string foto_Perfil { get; set; }
        public int id_Pais { get; set; }
        public string pasaporte { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contacto_emergencia> contacto_emergencia { get; set; }
        public virtual pais pais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<perfil> perfil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<preferencias_usuario> preferencias_usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<publicacion_anfitrion> publicacion_anfitrion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<seguimiento_usuario_pais> seguimiento_usuario_pais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_experiencia> usuario_experiencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conexiones> conexiones { get; set; }
    }
}
