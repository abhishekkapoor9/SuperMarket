using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using SuperMarket.Models;
using System;

namespace SuperMarket.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        //
        // GET: /Admin/Brand/

        public ActionResult Index()
        {
            ViewData["Status"] = "null";
            return View();
        }

        [HttpPost]
        public ActionResult Index(Brand model)
        {
            try
            {
                using (EComDBEntity entities = new EComDBEntity())
                {
                    entities.brands.Add(model);
                    entities.SaveChanges();
                    ViewData["Status"] = "Success";
                    return View(model);
                }
            }
            catch (Exception e1)
            {
                ViewData["Status"] = "Fail";
                return View(model);
            }
            finally
            {
               
            }
        }

        public JsonResult GetBrands(string sidx, string sort, int page, int rows)
        {
            EComDBEntity db = new EComDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var SupplierList = db.brands.Select(
                    t => new
                    {
                        t.BrandId,
                        t.BrandName
                    });
            int totalRecords = SupplierList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                SupplierList = SupplierList.OrderByDescending(t => t.BrandName);
                SupplierList = SupplierList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                SupplierList = SupplierList.OrderBy(t => t.BrandName);
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


        public string Edit(Brand Model)
        {
            EComDBEntity db = new EComDBEntity();
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
            EComDBEntity db = new EComDBEntity();
            Supplier student = db.suppliers.Find(Id);
            db.suppliers.Remove(student);
            db.SaveChanges();
            return "Deleted successfully";
        }

    }
}
