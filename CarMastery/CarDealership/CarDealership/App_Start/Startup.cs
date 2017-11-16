using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealership.Data;

namespace CarDealership.App_Start
{
    public class Startup
    {
            public void Configuration(IAppBuilder app)
            {
                app.UseCookieAuthentication(new CookieAuthenticationOptions()
                {
                    AuthenticationType = "ApplicationCookie",
                    LoginPath = new PathString("/auth/login")
                });
                app.CreatePerOwinContext(() => new CarDBContext());
                app.CreatePerOwinContext<UserManager<IdentityUser>>((options, context) => new UserManager<IdentityUser>(new UserStore<IdentityUser>(context.Get<CarDBContext>())));
                app.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) => new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context.Get<CarDBContext>())));
            }
        }
    }
