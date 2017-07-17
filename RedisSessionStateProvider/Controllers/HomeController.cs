using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisSessionStateProvider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.InstanceId = ServerConfig.CloudFoundryApplication?.InstanceIndex.ToString() ?? "N/A";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSession(String sessionData)
        {
            ViewBag.InstanceId = ServerConfig.CloudFoundryApplication?.InstanceIndex.ToString() ?? "N/A";
            HttpContext.Session["StoredValue"] = sessionData;
            return RedirectToAction("Index");
        }
    }
}