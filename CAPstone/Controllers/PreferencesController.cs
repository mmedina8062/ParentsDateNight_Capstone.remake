using CAPstone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CAPstone.Controllers
{
    public class PreferencesController : Controller
    {
        ApplicationDbContext context;
        public PreferencesController()
        {
            context = new ApplicationDbContext();
        }
      
        public ActionResult Index()
        {
            var preference = context.Preferences.ToList();
            return View(preference);
        }

     
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preferences preferences = context.Preferences.Find(id);
            if (preferences == null)
            {
                return HttpNotFound();
            }
            return View(preferences);
        }

    
        public ActionResult Create()
        {
            Preferences preferences = new Preferences();
            return View(preferences);
        }

     
        [HttpPost]
        public ActionResult Create(Preferences preferences)
        {
            try
            {
                context.Preferences.Add(preferences);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception Error)
            {
                return View(Error);
            }
        }

        
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preferences preferences = context.Preferences.Find(id);
            if (preferences == null)
            {
                return HttpNotFound();
            }

            return View(preferences);
        }

        
        [HttpPost]
        public ActionResult Edit(int id, Preferences preferences)
        {
            if (ModelState.IsValid)
                try
                {
                    // TODO: Add update logic here
                    context.Entry(preferences).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(HttpNotFound());
                }
            return View(preferences);
        }

       
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preferences deletedpreference = context.Preferences.Find(id);
            if (deletedpreference == null)
            {
                return HttpNotFound();
            }
            return View(deletedpreference);
        }

        
        [HttpPost]
        public ActionResult Delete(int id, Preferences preferences)
        {
            try
            {
                // TODO: Add delete logic here
                Preferences deletedpreference = context.Preferences.Find(id);
                context.Preferences.Remove(deletedpreference);
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