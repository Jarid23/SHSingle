using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tip_Calculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Tip()
        {
            var model = new Models.TipCalculator();

            return View( model);
        }
        [HttpPost]
        public ActionResult Tip(decimal Bill, decimal TipPercent)
        {
            var model = new Models.TipCalculator();

            model.Bill = Bill;
            model.TipPercent = TipPercent;
            model.TipAmount = (Bill * TipPercent);

            return View(model);
        }
        }
}