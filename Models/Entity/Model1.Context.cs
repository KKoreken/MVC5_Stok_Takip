﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stok_Uygulama.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbMvcStokUygulamaEntities : DbContext
    {
        public DbMvcStokUygulamaEntities()
            : base("name=DbMvcStokUygulamaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBLKategori> TBLKategori { get; set; }
        public virtual DbSet<TBLMusteri> TBLMusteri { get; set; }
        public virtual DbSet<TBLPersonel> TBLPersonel { get; set; }
        public virtual DbSet<TBLSatis> TBLSatis { get; set; }
        public virtual DbSet<TBLUrunler> TBLUrunler { get; set; }
    }
}