using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using System.Linq;
using System.Collections.Generic;

namespace OracleDataMoverUT.UT
{
    [TestClass]
    public class UT_PARM
    {
        protected ODMDataContext Context { get; set; }

        [TestMethod]
        public void AddParm()
        {
            Context = new ODMDataContext(new ODMEntities(), "Gibbonsbr");
            PARM p = new PARM();
            //p.Id = new Guid().ToString();
            p.ParmName = "TestParam";
            Context.PARMRepository.Save(p);

            Context.Commit();

            PARM getParm = Context.PARMRepository.FindBy(x => x.Id == p.Id).FirstOrDefault();

            Assert.IsNotNull(getParm);



        }

        [TestMethod]
        public void GetParmData()
        {
            Context = new ODMDataContext(new ODMEntities(), "Gibbonsbr");

            //var MyParm = Context.PARMRepository.FindBy(x => x.PARM_NAME == "DIRECTORY").FirstOrDefault();
            List<PARM> MyParm = Context.PARMRepository.FindBy(x => true).ToList();

            //var MyParm = Context.PARMRepository.FindBy(x => x.PARM_NAME == "DIRECTORY")

            var p = new PARM();
            
        }
    }
}
