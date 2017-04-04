using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtPassWeb.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            return RedirectToAction("Overview");//Overview();
        }

        public ActionResult Overview()
        {
            ViewBag.Title = "Program Participant Overview";

            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Title = "Add Program Participant";

            return View();
        }
    }
}