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
    public class SitterController : Controller
    {
        ApplicationDbContext context;
        public SitterController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Sitter
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            var sitter = context.Sitters.ToList();
            return View(sitter);
        }

        // GET: Sitter/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitter sitter = context.Sitters.Find(id);
            if (sitter == null)
            {
                return HttpNotFound();
            }
            return View(sitter);
        }

        // GET: Sitter/Create
        public ActionResult Create()
        {
            Sitter sitter = new Sitter();
            return View(sitter);
        }

        // POST: Sitter/Create
        [HttpPost]
        public ActionResult Create(Sitter sitter)
        {
            try
            {
                // TODO: Add insert logic here
                sitter.ApplicationId = User.Identity.GetUserId();
                context.Sitters.Add(sitter);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception Error)
            {
                return View(Error);
            }
        }

        // GET: Sitter/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitter sitter = context.Sitters.Find(id);
            if (sitter == null)
            {
                return HttpNotFound();
            }

            return View(sitter);
        }

        // POST: Sitter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Sitter sitter)
        {
            if (ModelState.IsValid)
                try
                {
                    // TODO: Add update logic here
                    context.Entry(sitter).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(HttpNotFound());
                }
            return View(sitter);
        }

        // GET: Sitter/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitter deletedsitter = context.Sitters.Find(id);
            if (deletedsitter == null)
            {
                return HttpNotFound();
            }
            return View(deletedsitter);
        }

        // POST: Sitter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Sitter sitter)
        {
            try
            {
                // TODO: Add delete logic here
                Sitter deletedsitter = context.Sitters.Find(id);
                context.Sitters.Remove(deletedsitter);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(HttpNotFound());
            }
        }
    }
}
