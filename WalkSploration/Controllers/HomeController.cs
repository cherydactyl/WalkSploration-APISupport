using Google.GData.Client;          //Install-Package Google.GData.Client, Install-Package Newtonsoft.Json
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WalkSploration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                        return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //helper functions here


    }
}