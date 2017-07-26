using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket.Areas.User.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /User/Category/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }

    }
}
