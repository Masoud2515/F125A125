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
    
    public partial class tbl_ShiftEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ShiftEmployee()
        {
            this.tbl_Leave = new HashSet<tbl_Leave>();
        }
    
        public int ShiftEmployeeId { get; set; }
        public int EmployeeId { get; set; }
        public int Shiftid { get; set; }
    
        public virtual tbl_Employee tbl_Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Leave> tbl_Leave { get; set; }
        public virtual tbl_shift tbl_shift { get; set; }
    }
}
