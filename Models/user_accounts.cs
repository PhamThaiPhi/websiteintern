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
    
    public partial class user_accounts
    {
        public int ma_taikhoan { get; set; }
        public Nullable<int> ma_nhanvien { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }
        public Nullable<int> role { get; set; }
    
        public virtual nhanvien nhanvien { get; set; }
    }
}
