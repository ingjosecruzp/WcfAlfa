﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfAlfa
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class alfadbEntities : DbContext
    {
        public alfadbEntities()
            : base("name=alfadbEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
    		this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<codigos> codigos { get; set; }
        public virtual DbSet<especialidades> especialidades { get; set; }
        public virtual DbSet<libros> libros { get; set; }
        public virtual DbSet<libroscategorias> libroscategorias { get; set; }
        public virtual DbSet<libroscodigos> libroscodigos { get; set; }
        public virtual DbSet<versiones> versiones { get; set; }
    }
}
