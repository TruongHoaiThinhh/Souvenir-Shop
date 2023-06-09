//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViewCustomer_BanHangLuuNiem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            this.ChiTietSanPhams = new HashSet<ChiTietSanPham>();
            this.DanhGias = new HashSet<DanhGia>();
        }
    
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public Nullable<decimal> GiaBan { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public int MaDM { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string HinhAnhChinh { get; set; }
        public Nullable<decimal> GiamGia { get; set; }
        public string TrangThai { get; set; }
        public string HinhAnh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
    }
}
