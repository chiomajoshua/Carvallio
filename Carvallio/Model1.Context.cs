﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Carvallio
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarvallioDBEntities : DbContext
    {
        public CarvallioDBEntities()
            : base("name=CarvallioDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomerTB> CustomerTBs { get; set; }
        public virtual DbSet<InsuranceTB> InsuranceTBs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User_RoleTB> User_RoleTB { get; set; }
        public virtual DbSet<UserTB> UserTBs { get; set; }
    }
}
