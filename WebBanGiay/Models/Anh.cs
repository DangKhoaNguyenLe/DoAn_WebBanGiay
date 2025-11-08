using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn_WebBanGiay.Models
{
    public class Anh
    {
        [Key]
        public int IdImage { get; set; }
        public string ImageURL { get; set; }
        public int IdSP { get; set; }
        public virtual sanPham sanPham { get; set; }
    }
}