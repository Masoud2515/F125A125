//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_AccidentO
    {
        public int AccidentOid { get; set; }
        public int AccidentId { get; set; }
        public int OrganizationsId { get; set; }
    
        public virtual tbl_Accident tbl_Accident { get; set; }
        public virtual tbl_Organizations tbl_Organizations { get; set; }
    }
}
