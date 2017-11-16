using CarDealership.Model.Users;
using CarDealership.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;

using System.Web.Mvc;



namespace CarDealership.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact(string id)
        {
            var model = new ContactVM();

            model.Message = id;

            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult Special()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactVM model)
        {
            if(model.Email == null && model.Phone == null)
            {
                ModelState.AddModelError("Email", "Phone/Email is required");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            var user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Try again - either invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and log in
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
               
                    return RedirectToAction("Index");
            }
        }
    }
}
