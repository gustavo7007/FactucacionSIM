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
    
    public partial class UsuaruoIPRestringido
    {
        public string DireccionIP { get; set; }
        public Nullable<bool> Habilitado { get; set; }
        public int usuaruoIPRestringidoID { get; set; }
        public Nullable<int> usuarioID { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
