using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CAPstone.Models;

namespace CAPstone.Controllers
{
    public class RatingsController : Controller
    {
        ApplicationDbContext context;
        public RatingsController()
        {
            context = new ApplicationDbContext();
        }


        // GET: Ratings
        public ActionResult Index()
        {
            var ratings = context.Ratings.Include(r => r.Sitter);
            return View(ratings.ToList());
        }

        // GET: Ratings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ratings ratings = context.Ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            return View(ratings);
        }

        // GET: Ratings/Create
        public ActionResult Create()
        {
            ViewBag.SitterID = new SelectList(context.Sitters, "Id", "FirstName");
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RateID,SitterID,Rating,Comments")] Ratings ratings)
        {
            if (ModelState.IsValid)
            {
                context.Ratings.Add(ratings);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SitterID = new SelectList(context.Sitters.Where(s => s.Id == ratings.SitterID).ToList());
            context.SaveChanges();
            return View(ratings);
        }

        // GET: Ratings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ratings ratings = context.Ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            ViewBag.SitterID = new SelectList(context.Sitters, "Id", "FirstName", ratings.SitterID);
            return View(ratings);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RateID,SitterID,Rating,Comments")] Ratings ratings)
        {
            if (ModelState.IsValid)
            {
                context.Entry(ratings).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SitterID = new SelectList(context.Sitters, "Id", "FirstName", ratings.SitterID);
            return View(ratings);
        }

        // GET: Ratings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ratings ratings = context.Ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            return View(ratings);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ratings ratings = context.Ratings.Find(id);
            context.Ratings.Remove(ratings);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
