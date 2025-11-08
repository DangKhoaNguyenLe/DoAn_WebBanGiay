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
    public class MauController : Controller
    {
        DbProcess db = new DbProcess();
        // GET: Mau
        public ActionResult Index()
        {
            ViewBag.dsMau = db.getListMau();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Mau m)
        {
            db.addMau(m);
            return RedirectToAction("Index", "Mau");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.dsMau = db.getListMau();
            ViewBag.Mau = db.getMauById(id);
            ViewBag.Mess = "Edit";
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Mau m)
        {
            db.UpdateMau(m);
            return RedirectToAction("Index", "Mau");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.DeleteMau(id);
            return RedirectToAction("Index", "Mau");
        }
    }
}