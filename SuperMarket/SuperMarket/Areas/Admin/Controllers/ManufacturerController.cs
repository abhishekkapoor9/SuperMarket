using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;

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

            using (EComsDBEntity entities = new EComsDBEntity())
            {
                entities.suppliers.Add(model);
                entities.SaveChanges();
                
            }
            return View(model);
        }
        
        public JsonResult GetSuppliers(string sidx, string sort, int page, int rows)
        {
            EComsDBEntity db = new EComsDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var SupplierList = db.suppliers.Select(
                    t => new
                    {
                        t.SupplierId,
                        t.SupplierNmae,
                        t.Address,
                        t.Description,
                        t.mobileNumber
                    });
            int totalRecords = SupplierList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                SupplierList = SupplierList.OrderByDescending(t => t.SupplierNmae);
                SupplierList = SupplierList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                SupplierList = SupplierList.OrderBy(t => t.SupplierNmae);
                SupplierList = SupplierList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = SupplierList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        public string Edit(Supplier Model)
        {
            EComsDBEntity db = new EComsDBEntity();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Model).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfully";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string Delete(string Id)
        {
            EComsDBEntity db = new EComsDBEntity();
            Supplier student = db.suppliers.Find(Id);
            db.suppliers.Remove(student);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }
}
