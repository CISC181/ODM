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
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Core.Objects.DataClasses;
    using System.Linq;
    using Eca.Common;
    
    
    public interface IOraEntities : IDbContext
    {
        string LoggedInUserId { get; set; }
        DbChangeTracker ChangeTracker { get; }
        int SaveChanges();
        IDbSet<TEntity> GetSet<TEntity>() where TEntity : class;
        IDbSet<ALL_CONS_COLUMNS> ALL_CONS_COLUMNS { get; set; }
        IDbSet<ALL_CONSTRAINTS> ALL_CONSTRAINTS { get; set; }
        IDbSet<ALL_TAB_COLS> ALL_TAB_COLS { get; set; }
        IDbSet<ALL_TABLES> ALL_TABLES { get; set; }
        IDbSet<ALL_USERS> ALL_USERS { get; set; }
    }
}
