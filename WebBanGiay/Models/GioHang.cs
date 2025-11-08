using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebBanGiay.Models.Identity;

namespace WebBanGiay.Models
{
    public class GioHang {

        [Key]
        public int IdGioHang { get; set; }
        public string IdUser { get; set; }
        public AppUser user { get; set; }

        public DateTime? NgayTao { get; set; } = DateTime.Now;
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
        [NotMapped]
        public double ThanhTien  => GioHangChiTiets?.Sum(t => t.SlMua * t.tongTien) ?? 0;
    }
}