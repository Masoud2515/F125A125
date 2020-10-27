﻿//------------------------------------------------------------------------------
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

    public partial class tbl_Injured
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Injured()
        {
            this.tbl_AccidentInjured = new HashSet<tbl_AccidentInjured>();
        }
        [Display(Name = "شناسه مصدوم")]
        public int InjuredID { get; set; }
        [Display(Name = "نام")]
        public string InjuredName { get; set; }
        [Display(Name = " نام خانوادگی")]
        public string InjuredLastName { get; set; }
        [Display(Name = "جنسیت")]
        public bool InjuredSex { get; set; }
        [Display(Name = "مامور/غیرمامور")]
        public bool InjuredType { get; set; }
        [Display(Name = "نوع مصدومیت")]
        public bool InjuredTypeinjury { get; set; }
        [Display(Name = "توضیحات")]
        public string InjuredDescription { get; set; }
        [Display(Name = "محل اعزام")]
        public string InjuredLocation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentInjured> tbl_AccidentInjured { get; set; }
    }
}