using System;
using System.Linq;
using System.Windows.Forms;
using OracleDataMover.ora;

namespace OracleDataMover
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SpreadsheetForm());

            Application.Run(new MainForm());
        }
    }
}