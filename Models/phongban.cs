//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webintern.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class phongban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phongban()
        {
            this.nhanviens = new HashSet<nhanvien>();
        }
    
        public int ma_phongban { get; set; }
        public string ten_phongban { get; set; }
        public Nullable<int> ma_quanli { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhanvien> nhanviens { get; set; }
        public virtual nhanvien nhanvien { get; set; }
    }
}
