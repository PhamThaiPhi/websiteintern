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
    
    public partial class leave_requests
    {
        public int leave_id { get; set; }
        public Nullable<int> ma_nhanvien { get; set; }
        public System.DateTime ngay_batdau { get; set; }
        public System.DateTime ngay_ketthuc { get; set; }
        public string lydo { get; set; }
        public string status { get; set; }
        public System.DateTime request_date { get; set; }
    
        public virtual nhanvien nhanvien { get; set; }
    }
}
