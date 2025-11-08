namespace WebBanGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        IdGioHang = c.Int(nullable: false, identity: true),
                        IdUser = c.String(),
                        NgayTao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdGioHang);
            
            CreateTable(
                "dbo.GioHangChiTiets",
                c => new
                    {
                        IdSP = c.Int(nullable: false),
                        IdGioHang = c.Int(nullable: false),
                        SlMua = c.Int(nullable: false),
                        tongTien = c.Double(nullable: false),
                        sanPhamBienThe_IdSP = c.Int(),
                        sanPhamBienThe_IdMau = c.Int(),
                        sanPhamBienThe_IdSize = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdSP, t.IdGioHang })
                .ForeignKey("dbo.GioHangs", t => t.IdGioHang, cascadeDelete: true)
                .ForeignKey("dbo.sanPhamBienThes", t => new { t.sanPhamBienThe_IdSP, t.sanPhamBienThe_IdMau, t.sanPhamBienThe_IdSize })
                .Index(t => t.IdGioHang)
                .Index(t => new { t.sanPhamBienThe_IdSP, t.sanPhamBienThe_IdMau, t.sanPhamBienThe_IdSize });
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        IdHoaDon = c.Int(nullable: false, identity: true),
                        IdUser = c.String(),
                        NgayDat = c.DateTime(),
                        TinhTrang = c.String(),
                    })
                .PrimaryKey(t => t.IdHoaDon);
            
            CreateTable(
                "dbo.HoaDonChiTiets",
                c => new
                    {
                        IdSP = c.Int(nullable: false),
                        IdHoaDon = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        Gia = c.Double(nullable: false),
                        sanPhamBienThe_IdSP = c.Int(),
                        sanPhamBienThe_IdMau = c.Int(),
                        sanPhamBienThe_IdSize = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdSP, t.IdHoaDon })
                .ForeignKey("dbo.sanPhamBienThes", t => new { t.sanPhamBienThe_IdSP, t.sanPhamBienThe_IdMau, t.sanPhamBienThe_IdSize })
                .ForeignKey("dbo.HoaDons", t => t.IdHoaDon, cascadeDelete: true)
                .Index(t => t.IdHoaDon)
                .Index(t => new { t.sanPhamBienThe_IdSP, t.sanPhamBienThe_IdMau, t.sanPhamBienThe_IdSize });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDonChiTiets", "IdHoaDon", "dbo.HoaDons");
            DropForeignKey("dbo.HoaDonChiTiets", new[] { "sanPhamBienThe_IdSP", "sanPhamBienThe_IdMau", "sanPhamBienThe_IdSize" }, "dbo.sanPhamBienThes");
            DropForeignKey("dbo.GioHangChiTiets", new[] { "sanPhamBienThe_IdSP", "sanPhamBienThe_IdMau", "sanPhamBienThe_IdSize" }, "dbo.sanPhamBienThes");
            DropForeignKey("dbo.GioHangChiTiets", "IdGioHang", "dbo.GioHangs");
            DropIndex("dbo.HoaDonChiTiets", new[] { "sanPhamBienThe_IdSP", "sanPhamBienThe_IdMau", "sanPhamBienThe_IdSize" });
            DropIndex("dbo.HoaDonChiTiets", new[] { "IdHoaDon" });
            DropIndex("dbo.GioHangChiTiets", new[] { "sanPhamBienThe_IdSP", "sanPhamBienThe_IdMau", "sanPhamBienThe_IdSize" });
            DropIndex("dbo.GioHangChiTiets", new[] { "IdGioHang" });
            DropTable("dbo.HoaDonChiTiets");
            DropTable("dbo.HoaDons");
            DropTable("dbo.GioHangChiTiets");
            DropTable("dbo.GioHangs");
        }
    }
}
