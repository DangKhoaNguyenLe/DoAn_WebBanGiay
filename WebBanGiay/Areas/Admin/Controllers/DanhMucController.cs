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
    public class DanhMucController : Controller
    {
        DbProcess db = new DbProcess();
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            ViewBag.dsDanhmuc = db.getListdanhMuc();
            return View();
        }

        [HttpPost]
        public ActionResult Create(danhMuc m)
        {
            db.addDanhMuc(m);
            return RedirectToAction("Index", "DanhMuc");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Mess = "Edit";
            ViewBag.dsDanhmuc = db.getListdanhMuc();
            ViewBag.DanhMuc = db.getDanhMucById(id);
            return View("Index");
        }


        [HttpPost]
        public ActionResult Edit(danhMuc dm)
        {
            db.UpdateDanhMuc(dm);
            return RedirectToAction("Index", "DanhMuc");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (db.DeleteDanhMuc(id)) { 
                return RedirectToAction("Index", "DanhMuc");
            }
            else
            {
                ViewBag.dsDanhmuc = db.getListdanhMuc();
                TempData["Error"] = "Lỗi do đã sản phẩm thuộc danh mục này";
                return View("Index");
            }
        }
    }
}