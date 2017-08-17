using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarket.ViewModels;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SuperMarket.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Admin/Category/

        public ActionResult Index()
        {
            EComsDBEntity entities = new EComsDBEntity();

            var category = entities.categories.ToList();
            ViewBag.selectGrouList = category;

            var subcategory = entities.subcategories.ToList();
            ViewBag.selectSubCategoryList = subcategory;

           
            var brands = entities.brands.ToList();
            ViewBag.selectbrandsList = brands;

            var suppliers = entities.suppliers.ToList();
            ViewBag.selectSupplierList = suppliers;

            var attribute = entities.attributes.ToList();
            ViewBag.selectattributeList = attribute;

            var rate = entities.rates.ToList();
            ViewBag.selectrateList = attribute;
            return View();
        }
        [HttpPost]
        public ActionResult Index(CategoryViewModel model, string submit_category, string submit_subcategory, string submit_product)
        {
            try
            {
                int SubCategoryid = 0, Categoryid = 0, Productid = 0;
                using (EComsDBEntity entities = new EComsDBEntity())
                {
                    if (!string.IsNullOrEmpty(submit_category))
                    {
                        Category categorys = new Category
                        {
                            CategoryName = model.CategoryName
                        };
                        entities.categories.Add(categorys);
                        entities.SaveChanges();
                        entities.Entry(categorys).GetDatabaseValues();
                        Categoryid = categorys.CategoryId;
                    }
                    if (!string.IsNullOrEmpty(submit_subcategory))
                    {
                        string[] categoryid = Request.Form["CategoryName"].Split(',');
                        SubCategory subcategorys = new SubCategory
                        {
                            CategoryId = Convert.ToInt32(categoryid[1]),
                            SubCategoryName = model.SubCategoryName
                        };
                        entities.subcategories.Add(subcategorys);
                        entities.SaveChanges();
                        entities.Entry(subcategorys).GetDatabaseValues();
                        SubCategoryid = subcategorys.SubCategoryId;
                    }

                    if (!string.IsNullOrEmpty(submit_product))
                    {
                        string[] categoryid = Request.Form["CategoryName"].Split(',');
                        string[] subcategoryid = Request.Form["SubCategoryName"].Split(',');
                        string[] brandid = Request.Form["BrandName"].Split(',');
                        string[] supplierid = Request.Form["SupplierNmae"].Split(',');
                        string[] attributeid = Request.Form["AttributeName"].Split(',');
                        Product product = new Product
                        {
                            CategoryId = Convert.ToInt32(categoryid[1]),
                            BrandID = Convert.ToInt32(brandid[1]),
                            SupplierId = Convert.ToInt32(supplierid[1]),
                            SubCategoryId = Convert.ToInt32(subcategoryid[1]),
                            AttributeId = Convert.ToInt32(attributeid[1]),
                            ProductName = model.ProductName

                        };
                        entities.products.Add(product);
                        entities.SaveChanges();
                        entities.Entry(product).GetDatabaseValues();
                        Productid = product.ProductId;
                        ProductAvailability productavaliable = new ProductAvailability
                        {
                            ProductId = Productid,
                            ProductQuantity = model.ProductQuantity,
                            Price = model.Price,
                            ProductAvailable = 1,
                            ProductValues = model.AttributeValues,
                            ProductRateid = model.RateId,
                            ProductRateValue = model.RateName

                        };
                        entities.produtAvailabilities.Add(productavaliable);
                        entities.SaveChanges();
                    }

                    ViewData["Status"] = "Success";
                    var category = entities.categories.ToList();
                    ViewBag.selectGrouList = category;

                    var subcategory = entities.subcategories.ToList();
                    ViewBag.selectSubCategoryList = subcategory;

                    var brands = entities.brands.ToList();
                    ViewBag.selectbrandsList = brands;

                    var suppliers = entities.suppliers.ToList();
                    ViewBag.selectSupplierList = suppliers;

                    var attribute = entities.attributes.ToList();
                    ViewBag.selectattributeList = attribute;
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
        public JsonResult GetCategory(string sidx, string sort, int page, int rows)
        {
            EComsDBEntity db = new EComsDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var CategoryList = db.categories.Select(
                    t => new
                    {
                        t.CategoryId,
                        t.CategoryName
                    });
            int totalRecords = CategoryList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                CategoryList = CategoryList.OrderByDescending(t => t.CategoryName);
                CategoryList = CategoryList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                CategoryList = CategoryList.OrderBy(t => t.CategoryName);
                CategoryList = CategoryList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = CategoryList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public string EditCategory(Brand Model)
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

        public string DeleteCategory(int Id)
        {
            EComsDBEntity db = new EComsDBEntity();
            var categories = (from a in db.categories where a.CategoryId.Equals(Id) select a).FirstOrDefault();
            db.categories.Remove(categories);
            db.SaveChanges();
            return "Deleted successfully";
        }

        public JsonResult GetSubCategory(string sidx, string sort, int page, int rows)
        {
            EComsDBEntity db = new EComsDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var SubCategoryList = db.subcategories.Select(
                    t => new
                    {
                        t.SubCategoryId,
                        t.Categories.CategoryName,
                        t.SubCategoryName,
                    });
            int totalRecords = SubCategoryList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                SubCategoryList = SubCategoryList.OrderByDescending(t => t.SubCategoryName);
                SubCategoryList = SubCategoryList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                SubCategoryList = SubCategoryList.OrderBy(t => t.SubCategoryName);
                SubCategoryList = SubCategoryList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = SubCategoryList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public string EditSubCategory(Brand Model)
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

        public string DeleteSubCategory(int Id)
        {
            EComsDBEntity db = new EComsDBEntity();
            var categories = (from a in db.categories where a.CategoryId.Equals(Id) select a).FirstOrDefault();
            db.categories.Remove(categories);
            db.SaveChanges();
            return "Deleted successfully";
        }
        [HttpPost]
        public ActionResult GetCategoryList(string categoryID)
        {
            List<SubCategory> lstsubcat = new List<SubCategory>();
            int categoryiD = Convert.ToInt32(categoryID);
            using (EComsDBEntity cITYSTATEEntities = new EComsDBEntity())
            {
                lstsubcat = (cITYSTATEEntities.subcategories.Where(x => x.CategoryId == categoryiD)).ToList<SubCategory>();
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                var list = JsonConvert.SerializeObject(lstsubcat,
    Formatting.None,
    new JsonSerializerSettings()
    {
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    });
                //string result = javaScriptSerializer.Serialize(lstsubcat);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
