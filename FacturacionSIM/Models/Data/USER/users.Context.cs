﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FACTURAUSEREntities : DbContext
    {
        public FACTURAUSEREntities()
            : base("name=FACTURAUSEREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Permiso> Permisoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuaruoIPRestringido> UsuaruoIPRestringidoes { get; set; }
    }
}
