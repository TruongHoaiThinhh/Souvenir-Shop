using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewCustomer_BanHangLuuNiem.Models
{
    public class CartItem
    {   
        public SanPham SanPham { get; set; }
        public int Quantity { get; set; }
        public float LineTotal { get; set; }
    }
    //gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public void Add(SanPham sp, int quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.SanPham.MaSP == sp.MaSP);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    SanPham = sp,
                    Quantity = quantity

                });
            }
            else{
                item.Quantity += quantity;
            }
        }
        public void UpdateQuantity(int MaSP, int quantity)
        {
            var item = items.Find(s => s.SanPham.MaSP == MaSP);
            if(item != null)
            {
                item.Quantity = quantity;
            }
        }
        //tong tien
        public double Total()
        {
            var total = items.Sum(s => s.SanPham.GiaBan * s.Quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {          
            items.RemoveAll(s => s.SanPham.MaSP == id);
        }
        public double Total_Quantity()
        {         
            return items.Sum(s => s.Quantity);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }

}
