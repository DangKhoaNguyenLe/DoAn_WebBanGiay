using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn_WebBanGiay.Models
{
    public class Size
    {
        [Key]
        public int IdSize { get; set; }
        public string tenSize { get; set; }
        public virtual ICollection<sanPhamBienThe> sanPhamBienThe { get; set; }
    }
}