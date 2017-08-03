using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket.Areas.Admin.Controllers
{
    public class OfferTypeController : Controller
    {
        //
        // GET: /Admin/OfferType/

        public ActionResult Index()
        {
            ViewData["Status"] = "null";
            return View();
        }

        [HttpPost]
        public ActionResult Index(OfferType model)
        {
            try
            {
                using (EComsDBEntity entities = new EComsDBEntity())
                {
                    entities.Offertypes.Add(model);
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

        public JsonResult GetOffers(string sidx, string sort, int page, int rows)
        {
            EComsDBEntity db = new EComsDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var OfferTypeList = db.Offertypes.Select(
                    t => new
                    {
                        t.OfferTypeId,
                        t.OfferName,
                        t.StartDate,
                        t.EndDate,
                        t.OfferOn
                    });
            int totalRecords = OfferTypeList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                OfferTypeList = OfferTypeList.OrderByDescending(t => t.OfferName);
                OfferTypeList = OfferTypeList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                OfferTypeList = OfferTypeList.OrderBy(t => t.OfferName);
                OfferTypeList = OfferTypeList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = OfferTypeList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        public string Edit(OfferType Model)
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
            OfferType student = db.Offertypes.Find(Id);
            db.Offertypes.Remove(student);
            db.SaveChanges();
            return "Deleted successfully";
        }

    }
}
