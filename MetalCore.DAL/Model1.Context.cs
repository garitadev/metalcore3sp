﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MetalCore.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DD_METALCOREEntities : DbContext
    {
        public DD_METALCOREEntities()
            : base("name=DD_METALCOREEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoTrabajo> EstadoTrabajo { get; set; }
        public virtual DbSet<MaterialesTrabajo> MaterialesTrabajo { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<Operaciones> Operaciones { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rol_Operacion> Rol_Operacion { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Trabajo> Trabajo { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }
    }
}
