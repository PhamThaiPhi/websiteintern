using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webintern.Models
{
    public class ViewModel
    {
        public nhanvien Nhanvien { get; set; }  // Changed from List<nhanvien> to a single nhanvien object
    }
}