using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using System.Linq;
using System.Collections.Generic;

namespace OracleDataMoverUT.UT
{
    [TestClass]
    public class UT_TEMPLATE
    {
        protected ODMDataContext Context { get; set; }

        [TestMethod]
        public void TestClone()
        {
            Context = new ODMDataContext(new ODMEntities(), "Gibbonsbr");
            Template t = Context.TemplateRepository.FindBy(x => x.Id == "BF2F6931ED37458AAF897FC8EBAB37E7").FirstOrDefault();
            Template newT = t.Clone();


            //Assert.IsTrue(Templates.Count() > 0);


        }

        [TestMethod]
        public void GetTemplateData()
        {
            Context = new ODMDataContext(new ODMEntities(), "Gibbonsbr");
            List<Template> MyParm = Context.TemplateRepository.FindBy(x => true).ToList();
           
            Assert.IsTrue(MyParm.Count() > 0);


        }
    }
}
