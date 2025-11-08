using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn_WebBanGiay.Models
{
    public class Mau
    {
        [Key]
        public int IdMau { get; set; }
        public string tenMau { get; set; }
        public string maMau { get; set; }
        public virtual ICollection<sanPhamBienThe> sanPhamBienThe { get; set; }
    }
}