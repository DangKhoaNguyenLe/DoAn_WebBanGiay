using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn_WebBanGiay.Models
{
    public class Hang
    {
        [Key]
        public int IdHang { get; set; }
        public string tenHang { get; set; }
        public string XuatXu { get; set; }
        public virtual ICollection<sanPham> sanPham { get; set; }
    }
}