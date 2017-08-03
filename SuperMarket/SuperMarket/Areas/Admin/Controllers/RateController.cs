using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket.Areas.Admin.Controllers
{
    public class RateController : Controller
    {
        //
        // GET: /Admin/Rate/

        public ActionResult Index()
        {
            ViewData["Status"] = "null";
            return View();
        }

        [HttpPost]
        public ActionResult Index(Rate model)
        {
            try
            {
                using (EComsDBEntity entities = new EComsDBEntity())
                {
                    entities.rates.Add(model);
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

        public JsonResult GetRates(string sidx, string sort, int page, int rows)
        {
            EComsDBEntity db = new EComsDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var RateList = db.rates.Select(
                    t => new
                    {
                        t.RateId,
                        t.RateName
                    });
            int totalRecords = RateList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                RateList = RateList.OrderByDescending(t => t.RateName);
                RateList = RateList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                RateList = RateList.OrderBy(t => t.RateName);
                RateList = RateList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = RateList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        public string Edit(Rate Model)
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
            Rate rates = db.rates.Find(Id);
            db.rates.Remove(rates);
            db.SaveChanges();
            return "Deleted successfully";
        }

    }
}
