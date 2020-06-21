using System;
using System.Collections.Generic;
using Eca.Common;
using System.Text.RegularExpressions;

namespace OracleDataMoverEF.EF
{
    public class DBA_DataPump_Jobs
    {
        public string OWNER_NAME { get; set; }
        public string JOB_NAME { get; set; }
        public string OPERATION { get; set; }
        public string JOB_MODE { get; set; }
        public string STATE { get; set; }

        public double DEGREE { get; set; }
        public double ATTACHED_SESSIONS { get; set; }
        public double DATAPUMP_SESSIONS { get; set; }



    }
}

