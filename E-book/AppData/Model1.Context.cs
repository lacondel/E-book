﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_book.AppData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<authorAwards> authorAwards { get; set; }
        public virtual DbSet<authors> authors { get; set; }
        public virtual DbSet<awards> awards { get; set; }
        public virtual DbSet<books> books { get; set; }
        public virtual DbSet<genres> genres { get; set; }
        public virtual DbSet<publishers> publishers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}