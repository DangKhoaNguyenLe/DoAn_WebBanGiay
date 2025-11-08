using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebBanGiay.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string HoTen {  get; set; }
        public string Gioitinh {  get; set; }
        public string DiaChi { get; set; }
        public string ThanhPho { get; set; }
        public string QuanHuyen {  get; set; }
        public string PhuongXa {  get; set; }
        public DateTime? NgaySinh { get; set; }

        public virtual GioHang gioHang { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }

    }
}