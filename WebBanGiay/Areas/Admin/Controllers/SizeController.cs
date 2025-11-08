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
    public class SizeController : Controller
    {
        DbProcess db = new DbProcess();
        // GET: Size
        public ActionResult Index()
        {
            ViewBag.dsSize = db.getListSize();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Size s)
        {
            db.addSize(s);
            return RedirectToAction("Index", "Size");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.DeleteSize(id);
            return RedirectToAction("Index", "Size");
        }
    }
}