//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OracleDataMoverOraEF.EF
{
    using System;
    using System.Collections.Generic;
    using Eca.Common;
    
    public partial class ALL_CONS_COLUMNS : Entity
    {
        public string OWNER { get; set; }
        public string CONSTRAINT_NAME { get; set; }
        public string TABLE_NAME { get; set; }
        public string COLUMN_NAME { get; set; }
        public Nullable<decimal> POSITION { get; set; }
    }
}
