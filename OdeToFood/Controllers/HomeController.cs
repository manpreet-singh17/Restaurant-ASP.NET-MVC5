using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        

        public JsonResult AutoComplete(string term)
        {
            
            var result = _db.Restaurants
                .Where(x => x.Name.StartsWith(term))
                .Take(5)
                .Select(x => new { label = x.Name });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(CacheProfile ="Long", VaryByHeader = "X-Requested-With; Accept-Language", Location = OutputCacheLocation.Server)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model =
                _db.Restaurants
                .OrderBy(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select(r => new RestaurantListViewModel {
                    ID = r.ID,
                    City = r.City,
                    Country = r.Country,
                    Name = r.Name,
                    CountOfReviews = r.Reviews.Count
                }).ToPagedList(pageNumber: page, pageSize: 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_RestaurantList", model);
            }
            return View(model);            
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

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}