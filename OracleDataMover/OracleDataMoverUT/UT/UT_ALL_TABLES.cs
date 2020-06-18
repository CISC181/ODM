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
    public class UT_ALL_TABLES
    {
        protected OraDataContext ContextOra { get; set; }


        [TestMethod]
        public void GetTableData()
        {

            OraDataContext ContextOra = new OraDataContext(new OraEntities("ECA"), "Gibbonsbr");
            List<ALL_TABLES> lstAllTables = ContextOra.ALL_TABLESRepository.FindBy(x => x.OWNER == "ODM").ToList();
            Assert.IsTrue(lstAllTables.Count() > 0);
        }
    }
}
