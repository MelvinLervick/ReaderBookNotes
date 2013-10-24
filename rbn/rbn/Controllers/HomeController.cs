﻿using System.Web.Mvc;

namespace rbn.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Read what other readers have to say about your favorite book.";
			ViewBag.Message1 = "If you want to add notes for others to read, please register or login.";

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Reader Book Notes";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Contact Us";

			return View();
		}

    public ActionResult BookNotes()
    {
      ViewBag.Message = "Rreader Book Notes";

      return View();
    }
  }
}
