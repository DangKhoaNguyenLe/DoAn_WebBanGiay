using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiay.Models
{
    public class HoaDonChiTiet
    {
        public int IdHoaDon { get; set; }
        public int IdSP { get; set; }
        public virtual sanPhamBienThe sanPhamBienThe{ get; set;}
        public int SoLuong { get; set; }
        public double Gia {  get; set; }
    }
}