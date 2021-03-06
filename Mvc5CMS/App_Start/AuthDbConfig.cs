﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mvc5CMS.Data;
using Mvc5CMS.Models;

namespace Mvc5CMS.App_Start
{
    public class AuthDbConfig
    {
        public static void RegisterAdmin()
        {
            using (var context = new CmsContext())
            using (var userStore = new UserStore<CmsUser>(context))
            using (var userManager = new UserManager<CmsUser>(userStore))
            {
                var user = userStore.FindByNameAsync("admin").Result;

                if (user == null)
                {
                    var adminUser = new CmsUser
                    {
                        UserName = "admin",
                        Email = "admin@cms.com",
                        DisplayName = "Administrator"
                    };

                    userManager.Create(adminUser, "Passw0rd1234");
                }
            }
        }
    }
}