//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace appweb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonHangRieng
    {
        public int maKH { get; set; }
        public string tenKH { get; set; }
        public string diaChi { get; set; }
        public string SDT { get; set; }
        public int maSP { get; set; }
        public int soLuong { get; set; }
        public decimal thanhTien { get; set; }
        public decimal tongTien { get; set; }
    
        public virtual sanPham sanPham { get; set; }
    }
}