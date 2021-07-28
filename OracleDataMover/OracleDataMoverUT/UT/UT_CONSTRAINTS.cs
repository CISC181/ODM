using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using System.Linq;
using System.Collections.Generic;
using OracleDataMoverOraEF.UnitOfWork;
using OracleDataMoverOraEF.EF;

namespace OracleDataMoverUT.UT
{
    [TestClass]
    public class UT_CONSTRAINTS
    {
        protected OraDataContext ContextOra { get; set; }

        [TestMethod]
        public void CheckConstraints()
        {
            OraDataContext ContextOra = new OraDataContext(new OraEntities("ECA"), "Gibbonsbr");
            List<ALL_CONSTRAINTS> lstConstraints = ContextOra.ALL_CONSTRAINTSRepository
                .FindBy(x => x.OWNER == "ABRENNER").ToList();

            List<ALL_CONS_COLUMNS> lstAllConsCols = ContextOra.ALL_CONS_COLUMNSRepository
                .FindBy(x => x.OWNER == "ABRENNER").ToList();

            var query = from c in lstConstraints
                        join o in lstAllConsCols on c.CONSTRAINT_NAME equals o.CONSTRAINT_NAME                        
                        select new { c.CONSTRAINT_NAME, c.CONSTRAINT_TYPE, c.TABLE_NAME, o.COLUMN_NAME };

            foreach (var group in query)
            {
                Console.WriteLine("{0} bought {1}", group.CONSTRAINT_NAME, group.COLUMN_NAME);
            }


        }
    }
}
