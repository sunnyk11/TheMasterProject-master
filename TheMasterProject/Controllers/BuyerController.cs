using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheMasterProject.Controllers
{
    [Authorize]
    public class BuyerController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}