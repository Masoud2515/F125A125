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
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_AccidentM
    {
        public int AccidentMid { get; set; }
        public int AccidentId { get; set; }
        public int MaterialId { get; set; }
        [Display(Name = "�����")]
        public int tedad { get; set; }
    
        public virtual tbl_Accident tbl_Accident { get; set; }
        public virtual tbl_Material tbl_Material { get; set; }
    }
}
