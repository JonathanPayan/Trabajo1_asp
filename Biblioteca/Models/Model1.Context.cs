﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteca.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BIBLIOTECADBEntities : DbContext
    {
        public BIBLIOTECADBEntities()
            : base("name=BIBLIOTECADBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ESTUDIANTES> ESTUDIANTES { get; set; }
        public virtual DbSet<LIBROS> LIBROS { get; set; }
        public virtual DbSet<PRESTAMO> PRESTAMO { get; set; }
    }
}