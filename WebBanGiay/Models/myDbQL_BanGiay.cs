using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DoAn_WebBanGiay.Controllers;
using WebBanGiay.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using WebBanGiay.Models.Identity;

namespace DoAn_WebBanGiay.Models
{
    public class myDbQL_BanGiay : DbContext
    {
        public myDbQL_BanGiay() : base("myDB") { }

        public DbSet<sanPham> sanPham { get; set; }
        public DbSet<sanPhamBienThe> sanPhamBienThe {  get; set; }
        public DbSet<Anh> Anh { get; set; }
        public DbSet<Hang> Hang { get; set; }
        public DbSet<Mau> Mau { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<danhMuc> danhMuc { get; set; }
        public DbSet<GioHang> gioHang { get; set; }
        public DbSet<GioHangChiTiet> gioHangChiTiet { get; set; }
        public DbSet<HoaDon> hoaDon { get; set; }
        public DbSet<HoaDonChiTiet> hoaDonChiTiet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<AppUser>();
            modelBuilder.Ignore<IdentityUserLogin>();
            modelBuilder.Ignore<IdentityUserRole>();
            modelBuilder.Ignore<IdentityUserClaim>();
            modelBuilder.Ignore<IdentityRole>();

            modelBuilder.Entity<sanPhamBienThe>()
                .HasKey(c => new { c.IdSP, c.IdMau, c.IdSize });
            modelBuilder.Entity<GioHangChiTiet>()
                .HasKey(c => new { c.IdSP, c.IdGioHang });
            modelBuilder.Entity<HoaDonChiTiet>()
                .HasKey(c => new { c.IdSP, c.IdHoaDon });

            modelBuilder.Entity<sanPham>()
                .HasMany(p => p.sanPhamBienThe)
                .WithRequired(b => b.sanPham)
                .HasForeignKey(i => i.IdSP)
                .WillCascadeOnDelete(true); 
            
            modelBuilder.Entity<sanPham>()
                .HasMany(p => p.Anh)
                .WithRequired(b => b.sanPham)
                .HasForeignKey(i => i.IdSP)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);

        }
    }
}