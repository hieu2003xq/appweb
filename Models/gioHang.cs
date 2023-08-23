using appweb.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

public partial class gioHang
{
    qlBhEntities db = new qlBhEntities();
    public int maGioHang { get; set; } 
    public string gmail { get; set; }
    public int maSP { get; set; }
    public string tenSP { get; set; }
    public int soLuong { get; set; }
    public decimal giaBan { get; set; }
    public string hinhAnh { get; set; }
    public decimal thanhTien
    {
        get
        {
            return soLuong * giaBan;
        }
    }
    public gioHang(int id)
    {
        maSP = id;
        sanPham a = db.sanPham.Single(m => m.maSP == maSP);
        maSP = a.maSP;
        tenSP = a.tenSP;
        giaBan = a.giaBan;
        hinhAnh = a.hinhAnh;
        soLuong = 1;
    }  
}



 



