using OracleDataMoverOraEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleDataMoverOraEF.UnitOfWork;

namespace OracleDataMoverOraEF.UnitOfWork
{
    public partial class OraDataContext
    {

        public Boolean ProofOfLife()
        {
            try
            {
                DateTime currDateTime = this.context.Database.SqlQuery<DateTime>("Select sysdate from dual").FirstOrDefault();
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
         public List<DBA_DataPump_Jobs> GetDBADataPumpJobs()
        {
            List<DBA_DataPump_Jobs> lstDBAPumpJobs = this.context.Database.SqlQuery<DBA_DataPump_Jobs>("Select * from dba_datapump_jobs").ToList();

            return lstDBAPumpJobs;
        }



    }
}
