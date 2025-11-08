using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebBanGiay.Models.Identity;

namespace WebBanGiay.Models
{
    public class HoaDon
    {
        [Key]
        public int IdHoaDon {  get; set; }
        public string IdUser { get; set; }
        public AppUser user { get; set; }
        public DateTime? NgayDat { get; set; } = DateTime.Now;
        public string TinhTrang { get; set; }

        public virtual ICollection<HoaDonChiTiet> hoaDonChiTiets { get; set; }

        public double ThanhTien => hoaDonChiTiets?.Sum(t => t.SoLuong * t.Gia) ?? 0;

    }
}