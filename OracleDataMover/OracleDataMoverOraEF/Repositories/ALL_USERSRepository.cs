//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Eca.Common.Repositories;
using Eca.Common;
using log4net;
using OracleDataMoverOraEF.UnitOfWork;
using OracleDataMoverOraEF.EF;

namespace OracleDataMoverOraEF.Repositories
{
    
    public partial class ALL_USERSRepository : AbstractRepository<ALL_USERS, IOraEntities>
    {
        private static ILog log = LogManager.GetLogger(typeof(ALL_USERSRepository));
    	
    	// Empty Constructor for mocking purposes
    	public ALL_USERSRepository()
    	{
    	}
    
    	public ALL_USERSRepository(OraDataContext context)
                : base(context)
    	{
    	}
    
    	public OraDataContext OraDataContext 
    	{
    	    get 
    		{ 
    		    return (OraDataContext)this.DataContext; 
    		}
    	}
    
    }
}
