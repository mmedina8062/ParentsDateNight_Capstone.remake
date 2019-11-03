using CAPstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CAPstone.Controllers
{
    public class ParentController : Controller
    {
        ApplicationDbContext context;
        public ParentController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Parent
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            var parent = context.Parents.ToList();
            return View(parent);
        }

        // GET: Parent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = context.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            Parent parent = new Parent();
            return View(parent);
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(Parent parent)
        {
            try
            {
                // TODO: Add insert logic here
                parent.ApplicationId = User.Identity.GetUserId();
                context.Parents.Add(parent);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception Error)
            {
                return View(Error);
            }
        }

        // GET: Parent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = context.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Parent parent)
        {
            if (ModelState.IsValid)
                try
                {
                    // TODO: Add update logic here
                    context.Entry(parent).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(HttpNotFound());
                }
            return View(parent);
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent deletedparent = context.Parents.Find(id);
            if (deletedparent == null)
            {
                return HttpNotFound();
            }
            return View(deletedparent);
        }

        // POST: Parent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Parent parent)
        {
            try
            {
                // TODO: Add delete logic here
                Parent deletedparent = context.Parents.Find(id);
                context.Parents.Remove(deletedparent);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(HttpNotFound());
            }
        }
        public ActionResult AddBudget(Parent budget)
        {
            /*Parent Budget = context.Parents.Where(p => p.Budget == budget.Budget).FirstOrDefault();
            context.Parents.Add(Budget);
            context.SaveChanges();*/
            return View();
        }
        /*[HttpPost]
        public ActionResult AddBudget(int Id, Parent budget)
        {
            try
            {
                Parent parentFromDb = context.Parents.Find(Id);
                Parent BudgetFromDb = context.Parents.Where(p => p.Budget == budget.Budget).FirstOrDefault();
                context.Parents.Add(BudgetFromDb);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            catch
            {
                return HttpNotFound();
            }
            
        }*/
        public ActionResult AddMiles()
        {
            return View();
        }
    }
}
