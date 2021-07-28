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
using OracleDataMoverEF.UnitOfWork;
using OracleDataMoverEF.EF;

namespace OracleDataMoverEF.Repositories
{
    
    public partial class TemplateRepository : AbstractRepository<Template, IODMEntities>
    {
        private static ILog log = LogManager.GetLogger(typeof(TemplateRepository));
    	
    	// Empty Constructor for mocking purposes
    	public TemplateRepository()
    	{
    	}
    
    	public TemplateRepository(ODMDataContext context)
                : base(context)
    	{
    	}
    
    	public ODMDataContext ODMDataContext 
    	{
    	    get 
    		{ 
    		    return (ODMDataContext)this.DataContext; 
    		}
    	}
    
    }
}
