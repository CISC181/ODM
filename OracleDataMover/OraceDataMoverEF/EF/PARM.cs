//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OracleDataMoverEF.EF
{
    using System;
    using System.Collections.Generic;
    using Eca.Common;
    using System.Text.RegularExpressions;
    
    public partial class PARM : Entity
    {
        public PARM()
        {
            this.TEMPLATE_PARM = new HashSet<TemplateParm>();
        }
    
        public string ParmName { get; set; }
    
        public virtual ICollection<TemplateParm> TEMPLATE_PARM { get; set; }
    }
}
