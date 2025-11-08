using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay.Models.Account;
using WebBanGiay.Models.Identity;
using Microsoft.Owin.Security;
namespace WebBanGiay.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(DangNhap lg)
        {
            AppDbConText appDbCt = new AppDbConText();
            AppUserStore appUs = new AppUserStore(appDbCt);
            AppUserManager appUm = new AppUserManager(appUs);
            var User = appUm.Find(lg.UserName, lg.PassWord);
            if(User != null)
            {
                var xacThuc = HttpContext.GetOwinContext().Authentication;
                var userI = appUm.CreateIdentity(User,
                    DefaultAuthenticationTypes.ApplicationCookie);
                xacThuc.SignIn(new AuthenticationProperties(), userI);
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}