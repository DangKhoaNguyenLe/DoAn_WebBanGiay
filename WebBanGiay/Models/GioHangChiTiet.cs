using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiay.Models
{
    public class GioHangChiTiet
    {
        public int IdGioHang { get; set; }
        public int IdSP { get; set; }

        public virtual GioHang GioHang { get; set; }
        public virtual sanPhamBienThe sanPhamBienThe { get; set; }

        public int SlMua {  get; set; }
        public double tongTien {  get; set; }
    }
}