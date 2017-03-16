using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieReview_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult MovieList()
        {

            return View();
        }

        public ActionResult ReviewList()
        {
            return View();
        }

        public ActionResult UserList()
        {

            return View();
        }
    }
}
