using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zindler.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

        public ActionResult GetConfig()
        {
            return Content(ConfigurationManager.AppSettings["Yelp.AccessToken"] != "TEMP" ? "AccessToken Configured" : "NOT CONFIGURED!!");
        }
	}
}
