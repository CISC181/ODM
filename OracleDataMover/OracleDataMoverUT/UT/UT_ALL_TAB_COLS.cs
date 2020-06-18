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
    public class UT_ALL_TAB_COLS
    {
        protected OraDataContext ContextOra { get; set; }


        [TestMethod]
        public void GetTableColumn()
        {
            OraDataContext ContextOra = new OraDataContext(new OraEntities("ECA"), "Gibbonsbr");

            List<ALL_TAB_COLS> lstTabCols = ContextOra.ALL_TAB_COLSRepository
                .FindBy(x => x.OWNER == "STU").Where(x => x.TABLE_NAME == "COURSE").ToList();
            Assert.IsTrue(lstTabCols.Count() > 0);
        }
    }
}
