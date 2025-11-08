using DoAn_WebBanGiay.Controllers;
using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay.Controllers;

namespace DoAn_WebBanGiay.Areas.Admin.Controllers
{
    [AuthenFilter]
    public class SanPhamController : Controller
    {
        myDbQL_BanGiay db = new myDbQL_BanGiay();
        DbProcess dbs = new DbProcess();
        // GET: SanPham
        public ActionResult Index()
        {
            List<sanPham> sanPhams = dbs.getListsanPham();
            return View(sanPhams);
        }

        public ActionResult Create()
        {
            ViewBag.DanhMuc = db.danhMuc.ToList();
            ViewBag.Mau = db.Mau.ToList();
            ViewBag.Hang = db.Hang.ToList();
            ViewBag.Size = db.Size.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(sanPham s, int Mau, int[] dsSize, int[] dsSl, string[] dsAnh)
        {
            db.sanPham.Add(s);
            db.SaveChanges();

            int idSp = s.IdSP;
            int n = dsSize.Length;
            for (int i = 0; i < n; i++)
            {
                sanPhamBienThe spbt = new sanPhamBienThe();
                spbt.IdSP = idSp;
                spbt.IdMau = Mau;
                spbt.IdSize = dsSize[i];
                spbt.SoLuong = dsSl[i];
                db.sanPhamBienThe.Add(spbt);
            }
            db.SaveChanges();

            foreach (var item in dsAnh)
            {
                Anh a = new Anh();
                a.ImageURL = item;
                a.sanPham = s;
                db.Anh.Add(a);
            }
            db.SaveChanges();


            return RedirectToAction("Index", "DashBoard");
        }


        public ActionResult Edit(int id)
        {
            ViewBag.DanhMuc = db.danhMuc.ToList();
            ViewBag.Mau = db.Mau.ToList();
            ViewBag.Hang = db.Hang.ToList();
            ViewBag.Size = db.Size.ToList();
            sanPham s = dbs.getsanPhamById(id);
            return View(s);
        }


        [HttpPost]
        public ActionResult Edit(sanPham s, int Mau, int[] dsSize, int[] dsSl, string[] dsAnh)
        {
            //
            sanPham sp = db.sanPham.FirstOrDefault(t => t.IdSP == s.IdSP);
            sp.tenSP = s.tenSP;
            sp.moTa = s.moTa;
            sp.Gia = s.Gia;
            sp.danhMuc.IdDMuc = s.IdDMuc;
            sp.Hang.IdHang = s.IdHang;

            // 
            foreach(var i in db.sanPhamBienThe.Where(t => t.IdSP == s.IdSP))
            {
                db.sanPhamBienThe.Remove(i);
            }
            foreach (var i in db.Anh.Where(t => t.IdSP == s.IdSP))
            {
                db.Anh.Remove(i);
            }

            int idSp = s.IdSP;
            int n = dsSize.Length;
            for (int i = 0; i < n; i++)
            {
                sanPhamBienThe spbt = new sanPhamBienThe();
                spbt.IdSP = idSp;
                spbt.IdMau = Mau;
                spbt.IdSize = dsSize[i];
                spbt.SoLuong = dsSl[i];
                db.sanPhamBienThe.Add(spbt);
            }

            foreach (var item in dsAnh)
            {
                Anh a = new Anh();
                a.ImageURL = item;
                a.sanPham = sp;
                db.Anh.Add(a);
            }

            db.SaveChanges();

            return RedirectToAction("Index", "DashBoard");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (dbs.DeleteSanPham(id))
            {
                return RedirectToAction("Index", "SanPham");
            }
            else
            {
                List<sanPham> sanPhams = dbs.getListsanPham();
                TempData["Error"] = "Lỗi do đã sản phẩm thuộc danh mục này";
                return View("Index", sanPhams);
            }
        }
    }
}