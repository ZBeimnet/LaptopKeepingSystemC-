﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PC_Safe
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pc_safeEntities : DbContext
    {
        public pc_safeEntities()
            : base("name=pc_safeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<currentuser> currentusers { get; set; }
        public virtual DbSet<history> histories { get; set; }
        public virtual DbSet<librarian> librarians { get; set; }
        public virtual DbSet<student> students { get; set; }
    }
}
