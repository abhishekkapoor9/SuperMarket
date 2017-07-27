using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace SuperMarket.Areas.Admin.Controllers
{
    public class ManufacturerController : Controller
    {
        //
        // GET: /Admin/Manufacturer/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Supplier model )
        {

            using (EComDBEntities entities = new EComDBEntities())
            {
                entities.suppliers.Add(model);
                entities.SaveChanges();
                
            }
            return View(model);
        }
    }
}
