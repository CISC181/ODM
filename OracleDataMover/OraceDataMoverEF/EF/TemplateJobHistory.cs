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
    
    public partial class TemplateJobHistory : Entity
    {
        public string TemplateId { get; set; }
        public string UserName { get; set; }
        public string MachineName { get; set; }
        public string IPAddress { get; set; }
    
        public virtual Template TEMPLATE { get; set; }
    }
}