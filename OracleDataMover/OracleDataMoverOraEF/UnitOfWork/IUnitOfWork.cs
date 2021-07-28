﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using OracleDataMoverOraEF.Repositories;
using OracleDataMoverOraEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDataMoverOraEF.UnitOfWork
{
    
    public interface IUnitOfWork : IDisposable
    {
    
    	bool UserHasPermission { get; }
    
    
    	ALL_CONS_COLUMNSRepository ALL_CONS_COLUMNSRepository { get; }
    	ALL_CONSTRAINTSRepository ALL_CONSTRAINTSRepository { get; }
    	ALL_TAB_COLSRepository ALL_TAB_COLSRepository { get; }
    	ALL_TABLESRepository ALL_TABLESRepository { get; }
    	ALL_USERSRepository ALL_USERSRepository { get; }
    	
    	
    
        void Save();
        OraEntities ReturnContext();
        bool RunFgacPermission(string networkUserName, int fgacId);
        int RunRolePermission(string role);
    	void InitializeTransaction();
    }
    
}









