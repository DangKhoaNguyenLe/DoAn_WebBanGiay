using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_WebBanGiay.Models
{
    public class sanPhamBienThe
    {
        public int IdSP { get; set; }
        public int IdMau { get; set; }
        public int IdSize { get; set; }
        public int SoLuong { get; set; }

        public virtual Mau Mau { get; set; }
        public virtual sanPham sanPham { get; set; }
        public virtual Size Size { get; set; }
    }
}