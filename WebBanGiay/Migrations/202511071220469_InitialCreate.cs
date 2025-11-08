namespace WebBanGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anhs",
                c => new
                    {
                        IdImage = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        IdSP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdImage)
                .ForeignKey("dbo.sanPhams", t => t.IdSP, cascadeDelete: true)
                .Index(t => t.IdSP);
            
            CreateTable(
                "dbo.sanPhams",
                c => new
                    {
                        IdSP = c.Int(nullable: false, identity: true),
                        tenSP = c.String(),
                        moTa = c.String(),
                        Gia = c.Double(nullable: false),
                        IdDMuc = c.Int(nullable: false),
                        IdHang = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSP)
                .ForeignKey("dbo.danhMucs", t => t.IdDMuc, cascadeDelete: true)
                .ForeignKey("dbo.Hangs", t => t.IdHang, cascadeDelete: true)
                .Index(t => t.IdDMuc)
                .Index(t => t.IdHang);
            
            CreateTable(
                "dbo.danhMucs",
                c => new
                    {
                        IdDMuc = c.Int(nullable: false, identity: true),
                        tenDMuc = c.String(),
                    })
                .PrimaryKey(t => t.IdDMuc);
            
            CreateTable(
                "dbo.Hangs",
                c => new
                    {
                        IdHang = c.Int(nullable: false, identity: true),
                        tenHang = c.String(),
                        XuatXu = c.String(),
                    })
                .PrimaryKey(t => t.IdHang);
            
            CreateTable(
                "dbo.sanPhamBienThes",
                c => new
                    {
                        IdSP = c.Int(nullable: false),
                        IdMau = c.Int(nullable: false),
                        IdSize = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdSP, t.IdMau, t.IdSize })
                .ForeignKey("dbo.Maus", t => t.IdMau, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.IdSize, cascadeDelete: true)
                .ForeignKey("dbo.sanPhams", t => t.IdSP, cascadeDelete: true)
                .Index(t => t.IdSP)
                .Index(t => t.IdMau)
                .Index(t => t.IdSize);
            
            CreateTable(
                "dbo.Maus",
                c => new
                    {
                        IdMau = c.Int(nullable: false, identity: true),
                        tenMau = c.String(),
                        maMau = c.String(),
                    })
                .PrimaryKey(t => t.IdMau);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        IdSize = c.Int(nullable: false, identity: true),
                        tenSize = c.String(),
                    })
                .PrimaryKey(t => t.IdSize);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sanPhamBienThes", "IdSP", "dbo.sanPhams");
            DropForeignKey("dbo.sanPhamBienThes", "IdSize", "dbo.Sizes");
            DropForeignKey("dbo.sanPhamBienThes", "IdMau", "dbo.Maus");
            DropForeignKey("dbo.sanPhams", "IdHang", "dbo.Hangs");
            DropForeignKey("dbo.sanPhams", "IdDMuc", "dbo.danhMucs");
            DropForeignKey("dbo.Anhs", "IdSP", "dbo.sanPhams");
            DropIndex("dbo.sanPhamBienThes", new[] { "IdSize" });
            DropIndex("dbo.sanPhamBienThes", new[] { "IdMau" });
            DropIndex("dbo.sanPhamBienThes", new[] { "IdSP" });
            DropIndex("dbo.sanPhams", new[] { "IdHang" });
            DropIndex("dbo.sanPhams", new[] { "IdDMuc" });
            DropIndex("dbo.Anhs", new[] { "IdSP" });
            DropTable("dbo.Sizes");
            DropTable("dbo.Maus");
            DropTable("dbo.sanPhamBienThes");
            DropTable("dbo.Hangs");
            DropTable("dbo.danhMucs");
            DropTable("dbo.sanPhams");
            DropTable("dbo.Anhs");
        }
    }
}
