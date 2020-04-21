using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiciosNacionCrema.Controllers
{
    public class CupController : Controller
    {
        // GET: Cup
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult a()
        {
            return View("1.aspx");
        }
        public ActionResult b()
        {
            return View("2.aspx");
        }
        public ActionResult c()
        {
            return View();
        }
        public ActionResult d()
        {
            return View();
        }
    }
}