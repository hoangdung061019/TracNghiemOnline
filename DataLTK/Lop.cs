﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLTK
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Lop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lop()
        {
            this.ThiSinhs = new HashSet<ThiSinh>();
        }
    
        public int MaLop { get; set; }
		[Display(Name = "Tên lớp")]
		public string TenLop { get; set; }
		[Display(Name = "Khối")]
		public string Khoi { get; set; }
		[Display(Name = "Sĩ số")]
		public Nullable<int> SiSo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThiSinh> ThiSinhs { get; set; }
    }
}
