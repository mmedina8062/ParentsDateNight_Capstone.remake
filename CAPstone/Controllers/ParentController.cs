using CAPstone.Models;
using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public ActionResult ViewNearBySitters(int zipcode)
        {
            var customers = GetSittersSharingZipCode().Where(s => s.ZipCode == zipcode);
            return View("ViewNearBySitters", customers);
        }
        /*public ActionResult VerifySitterNeeded(int sitterId)
        {
            //after confirmed send notification via email to sitter
            var sitter = context.Sitters.SingleOrDefault(s => s.Id == sitterId);

        }*/
        public async Task<ActionResult> SitterEmail(int id)
        {
            Sitter sitter = context.Sitters.Include(p => p.User).FirstOrDefault(p => p.Id == id);

            return View(sitter);

        }

        [HttpPost]
        public async Task<ActionResult> SitterEmail(Sitter sitter)
        {

            string email = sitter.User.Email;
            var client = new SendGridClient(APIKey.sendGridAPI);
            var from = new EmailAddress("parentsdatenights@gmail.com", "Parents");
            var subject = "Sitter Request";
            var to = new EmailAddress("sittersiter10@gmail.com", "Sitters");
            var plainTextContent = "Your Service Is Needed";
            var htmlContent = "<strong>Your service is needed, please confirm or cancel</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            var startdate = DateTime.Today;

            return RedirectToAction("Index");
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
            Parent Budget = context.Parents.Where(p => p.Budget == budget.Budget).FirstOrDefault();
            context.Parents.Add(Budget);
            context.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult AddBudget(int Id, Parent budget)
        {
            try
            {
                Parent parentFromDb = context.Parents.Find(Id);
                Parent BudgetFromDb = context.Parents.Where(p => p.Budget == budget.Budget).FirstOrDefault();
                context.SaveChanges();
                return RedirectToAction("index");
            }
            catch
            {
                return HttpNotFound();
            }

        }
        public ActionResult AddMiles(Parent miles)
        {
            /*Parent setMiles = context.Parents.Where(p => p.Miles == miles.Miles).FirstOrDefault();
            context.Parents.Add(setMiles);
            context.SaveChanges();*/
            return View("GenerateStaticMapUrlForSeletedPreference", "Preferences");
        }

        private IQueryable<Sitter> GetSittersSharingZipCode()
        {
            var parent = GetParent();
            return context.Sitters.Where(c => c.ZipCode == parent.ZipCode);
        }

        private Parent GetParent()
        {
            try
            {
                var currentUserId= User.Identity.GetUserId();
                var activeParent = context.Parents.SingleOrDefault(p => p.ApplicationId == currentUserId);
                return activeParent;
            }
            catch
            {
                throw new Exception("Not able to find your location");
            }
        }
        public ActionResult VerifyIfSitterIsNeeded()
        {
            return View();
        }
    }
}
