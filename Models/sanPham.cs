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
    
    public partial class sanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sanPham()
        {
            this.DonHangRieng = new HashSet<DonHangRieng>();
        }
    
        public int maSP { get; set; }
        public string tenSP { get; set; }
        public decimal giaBan { get; set; }
        public string hinhAnh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangRieng> DonHangRieng { get; set; }
        public virtual donHang donHang { get; set; }
    }
}