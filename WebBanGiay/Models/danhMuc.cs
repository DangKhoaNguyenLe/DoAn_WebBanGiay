using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DoAn_WebBanGiay.Models;

namespace DoAn_WebBanGiay.Models
{
    public class danhMuc
    {
        [Key]
        public int IdDMuc { get; set; }
        public string tenDMuc { get; set; }
        public virtual ICollection<sanPham> sanPham  { get; set; }
    }
}