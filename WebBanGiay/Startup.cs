using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using WebBanGiay.Models.Identity;

[assembly: OwinStartup(typeof(WebBanGiay.Startup))]

namespace WebBanGiay
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            CreateRole();
        }

        public void CreateRole()
        {
            var rol =  new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new AppDbConText()));
            var appDbCt = new AppDbConText();
            var appUs = new AppUserStore(appDbCt);
            var appUm = new AppUserManager(appUs);

            if (!rol.RoleExists("admin"))
            {
                var rolNew = new IdentityRole();
                rolNew.Name = "admin";
                rol.Create(rolNew);
            }

            if(appUm.FindByName("admin") == null)
            {
                AppUser user = new AppUser();
                user.UserName = "admin";
                string pass = "admin@123";
                
                var check = appUm.Create(user, pass);
                if(check.Succeeded) {
                    appUm.AddToRole(user.Id, "admin");
                }
            }
        }
    }
}
