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
    
    public partial class DanhGia
    {
        public int MaDG { get; set; }
        public Nullable<int> DanhGia1 { get; set; }
        public int MaSP { get; set; }
        public string Review { get; set; }
    
        public virtual SanPham SanPham { get; set; }
    }
}
