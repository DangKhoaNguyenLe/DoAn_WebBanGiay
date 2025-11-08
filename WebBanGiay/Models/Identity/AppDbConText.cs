using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DoAn_WebBanGiay.Models;
using Microsoft.AspNet.Identity.EntityFramework;
namespace WebBanGiay.Models.Identity
{
    public class AppDbConText : IdentityDbContext<AppUser>
    {
        public AppDbConText() : base("myDB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<sanPham>();
            modelBuilder.Ignore<sanPhamBienThe>();
            modelBuilder.Ignore<Anh>();
            modelBuilder.Ignore<Hang>();
            modelBuilder.Ignore<Mau>();
            modelBuilder.Ignore<Size>();
            modelBuilder.Ignore<danhMuc>();
            modelBuilder.Ignore<GioHang>();
            modelBuilder.Ignore<GioHangChiTiet>();
            modelBuilder.Ignore<HoaDon>();
            modelBuilder.Ignore<HoaDonChiTiet>();
        }
    }
}