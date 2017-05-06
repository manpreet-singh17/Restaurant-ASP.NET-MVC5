using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        // GET: Reviews
        public ActionResult Index([Bind(Prefix = "id")] int RestaurantId)
        {
            var Restaurant = _db.Restaurants.Find(RestaurantId);
            if (Restaurant != null)
            {
                return View(Restaurant);
            }
            return HttpNotFound();
        }

        //GET: Reviews/create
        public ActionResult create(int restaurantID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(RestaurantReview review )
        {
            if (ModelState.IsValid)
            {
                _db.RestaurantReviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("index", new { id = review.RestaurantID});
            }
            return View(review);
        }


        public ActionResult Edit(int id)
        {
            var review = _db.RestaurantReviews.Find(id);
            return View(review);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("index", new { id = review.RestaurantID });
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}