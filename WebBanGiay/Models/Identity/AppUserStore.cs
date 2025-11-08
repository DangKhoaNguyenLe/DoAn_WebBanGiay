using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiay.Models.Identity
{
    public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(AppDbConText dbCT): base(dbCT) { }
    }
}