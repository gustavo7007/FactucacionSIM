//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FacturacionSIM.Models.Data.USER
{
    using System;
    using System.Collections.Generic;
    
    public partial class Perfil
    {
        public Perfil()
        {
            this.Usuarios = new HashSet<Usuario>();
            this.Permisoes = new HashSet<Permiso>();
        }
    
        public string PerfilNombre { get; set; }
        public string PerfilDescripcion { get; set; }
        public Nullable<bool> PerfilHabilitado { get; set; }
        public int PerfilID { get; set; }
    
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Permiso> Permisoes { get; set; }
    }
}
