﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OracleDataMoverOraEF.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OraEntities : DbContext, IOraEntities
    {
    public OraEntities(string ConnStringName)
            : base(ConnStringName)
                        //: base("name=" + ConnStringName)
        {
        }

        public OraEntities()
            : base("name=OraEntities")
        {
        }
    
        public IDbSet<TEntity> GetSet<TEntity>() where TEntity : class 
        {
            return this.Set<TEntity>();
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public IDbSet<ALL_CONS_COLUMNS> ALL_CONS_COLUMNS { get; set; }
        public IDbSet<ALL_CONSTRAINTS> ALL_CONSTRAINTS { get; set; }
        public IDbSet<ALL_TAB_COLS> ALL_TAB_COLS { get; set; }
        public IDbSet<ALL_TABLES> ALL_TABLES { get; set; }
        public IDbSet<ALL_USERS> ALL_USERS { get; set; }
    }
}