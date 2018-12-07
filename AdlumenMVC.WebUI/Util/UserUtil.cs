using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI
{
    public static class UserUtil
    {
        public static ApplicationUser GetUserById(string id)
        {
            ApplicationUser user = null;
            using (var db = new ApplicationDbContext())
            {
                user = db.Users.FirstOrDefault(x => x.Id == id);
            }
            return user;
        }
    }
}