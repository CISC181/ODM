using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDataMover.Common
{
    public class Utility
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), "Gibbonsbr");

        public static void CopyTemplate(string strTemplateID, string strNewTemplateName)
        {
            Template T = Context.TemplateRepository.FindBy(x => x.Id == strTemplateID).FirstOrDefault();
            Template newT = new Template();
            newT = T.Clone();


        }

    }
}
