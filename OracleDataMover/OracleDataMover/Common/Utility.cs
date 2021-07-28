using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using OracleDataMoverOraEF.EF;
using OracleDataMoverOraEF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OracleDataMover.Common
{
    public class Utility
    {
        private static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static string UserName { get => userName; set => userName = value; }
        public OraDataContext ContextOra { get; private set; }

        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);


        public static void WriteHistoryRecord(string strTemplateID)
        {
            Template T = Context.TemplateRepository.FindBy(x => x.Id == strTemplateID).FirstOrDefault();

            string IP = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = ip.ToString();
                    break;
                }
            }

            string machine = System.Environment.MachineName;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            TemplateJobHistory TJH = new TemplateJobHistory();
            TJH.TemplateId = T.Id;
            TJH.IPAddress = IP;
            TJH.MachineName = machine;
            TJH.UserName = userName;
            Context.TemplateJobHistoryRepository.Save(TJH);
            Context.Commit();
        }

        public static Boolean validateDatabaseConnection(string strTNSName)
        {
            OraDataContext ContextOra = null;
            String connBuilder = ConfigurationManager.AppSettings["OracleConnectionStringTemplate"];
            connBuilder = connBuilder.Replace("ODM_Database", strTNSName);

            try
            {
                ContextOra = new OraDataContext(new OraEntities(connBuilder), Utility.UserName);
                ContextOra.ProofOfLife();
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                var strMessage = e.InnerException.Message;
              //  MessageBox.Show("Error with Database: " + strTNSName + Environment.NewLine + strMessage);
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }


        public static void CopyTemplate(string strTemplateID, string strNewTemplateName)
        {
            Template T = Context.TemplateRepository.FindBy(x => x.Id == strTemplateID).FirstOrDefault();
            //Template newT = T.Clone();

            // newT.Name = strNewTemplateName;
            // Context.TemplateRepository.Save(newT);
            Context.Commit();
            /*
            foreach (TemplateParm TP in Context.TemplateParmRepository.FindBy(x=>x.TemplateId == newT.Id).ToList())
            {
            
            }
            */


        }

    }
}
