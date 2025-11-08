using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DoAn_WebBanGiay.Models
{
    public class sanPham
    {
        [Key]
        public int IdSP { get; set; }
        public string tenSP { get; set; }
        public string moTa { get; set; }
        public double Gia { get; set; }
        public int IdDMuc { get; set; }
        public int IdHang { get; set; }

        public virtual danhMuc danhMuc { get; set; }
        public virtual Hang Hang { get; set; }
        public virtual ICollection<sanPhamBienThe> sanPhamBienThe { get; set; }
        public virtual ICollection<Anh> Anh { get; set; }
    }
}