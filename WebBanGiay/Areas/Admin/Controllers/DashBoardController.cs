using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay.Controllers;
using WebBanGiay.Models.Identity;
namespace DoAn_WebBanGiay.Areas.Admin.Controllers
{
    [AuthenFilter]
    public class DashBoardController : Controller
    {

        myDbQL_BanGiay db = new myDbQL_BanGiay();
        // GET: DashBoard   
        public ActionResult Index()
        {
            return View();
        }


      
    }
}