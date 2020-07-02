using Newtonsoft.Json;
using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OracleDataMoverBLL.Common
{
    public class Utility
    {
        private static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static string UserName { get => userName; set => userName = value; }

        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);

        public static void ExportTemplate(String strTemplateID)
        {
            Context.DisableLazyLoadingAndDetectChanges();

            Template T = Context.TemplateRepository
                .FindBy(x => x.Id == strTemplateID)
                
                .FirstOrDefault();
            string output = JsonConvert.SerializeObject(T);

        }

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

            string  machine = System.Environment.MachineName;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            TemplateJobHistory TJH = new TemplateJobHistory();
            TJH.TemplateId = T.Id;
            TJH.IPAddress = IP;
            TJH.MachineName = machine;
            TJH.UserName = userName;
            Context.TemplateJobHistoryRepository.Save(TJH);
            Context.Commit();
        }

        public static void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
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
