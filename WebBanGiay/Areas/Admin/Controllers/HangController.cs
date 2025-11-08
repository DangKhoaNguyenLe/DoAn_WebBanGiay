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
    public class HangController : Controller
    {
        DbProcess db = new DbProcess();
        // GET: Admin/Hang
        public ActionResult Index()
        {
            ViewBag.dsHang = db.getListHang();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hang h)
        {
            db.addHang(h);
            return RedirectToAction("Index", "Hang");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Mess = "Edit";
            ViewBag.dsHang = db.getListHang();
            ViewBag.Hang = db.getHangById(id);
            return View("Index");
        }


        [HttpPost]
        public ActionResult Edit(Hang h)
        {
            db.UpdateHang(h);
            return RedirectToAction("Index", "Hang");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (db.DeleteHang(id))
            {
                return RedirectToAction("Index", "Hang");
            }
            else
            {
                ViewBag.dsHang = db.getListHang();
                TempData["Error"] = "Lỗi do đã sản phẩm thuộc hãng này";
                return View("Index");
            }
        }

    }
}