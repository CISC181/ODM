using OracleDataMoverEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleDataMoverEF.UnitOfWork;

namespace OracleDataMoverEF.UnitOfWork
{
    public partial class ODMDataContext
    {
         public List<DBA_DataPump_Jobs> GetDBADataPumpJobs()
        {
 
            List<DBA_DataPump_Jobs> lstDBAPumpJobs =
                this.context.Database.SqlQuery<DBA_DataPump_Jobs>("Select * from dba_datapump_jobs").ToList();

            return lstDBAPumpJobs;
        }

    }
}
