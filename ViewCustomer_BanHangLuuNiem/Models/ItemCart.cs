using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewCustomer_BanHangLuuNiem.Models
{
    public class ItemCart 
    {
        public SanPham SanPham { get; set; }
        public int Quantity { get; set; }
        public float LineTotal { get; set; }
    }
}