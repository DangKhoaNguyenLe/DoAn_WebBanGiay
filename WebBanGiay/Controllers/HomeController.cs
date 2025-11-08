using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_WebBanGiay.Models;
namespace DoAn_WebBanGiay.Controllers
{
    public class HomeController : Controller
    {
        private myDbQL_BanGiay db = new myDbQL_BanGiay();
        // GET: Hone
        public ActionResult Index()
        {
            var sanPhams = db.sanPham.ToList();
            return View(sanPhams);
        }
    }
}