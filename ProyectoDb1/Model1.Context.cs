﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoDb1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bfzkzkyq0abmhdbsc2ruEntities : DbContext
    {
        public bfzkzkyq0abmhdbsc2ruEntities()
            : base("name=bfzkzkyq0abmhdbsc2ruEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actividadproyectos> actividadproyectos { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<empleados> empleados { get; set; }
        public virtual DbSet<equipotrabajo> equipotrabajo { get; set; }
        public virtual DbSet<habilidades> habilidades { get; set; }
        public virtual DbSet<habilidadesxpuestos> habilidadesxpuestos { get; set; }
        public virtual DbSet<historiales> historiales { get; set; }
        public virtual DbSet<historiasusuario> historiasusuario { get; set; }
        public virtual DbSet<modulos> modulos { get; set; }
        public virtual DbSet<p_e_d> p_e_d { get; set; }
        public virtual DbSet<pantalla> pantalla { get; set; }
        public virtual DbSet<privilegios> privilegios { get; set; }
        public virtual DbSet<privilegiosxrol> privilegiosxrol { get; set; }
        public virtual DbSet<puestotrabajo> puestotrabajo { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<solicitudesproyecto> solicitudesproyecto { get; set; }
        public virtual DbSet<telefonos> telefonos { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
    }
}
