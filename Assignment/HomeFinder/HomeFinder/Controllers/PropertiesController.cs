using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeFinder.Models;
using Microsoft.AspNet.Identity;

namespace HomeFinder.Controllers
{
    public class PropertiesController : Controller
    {
        private HomeFinder_Model db = new HomeFinder_Model();

        // GET: Properties
        [Authorize]
        public ActionResult Myproperties()
        {
            if (User.IsInRole("Admin")) 
            { 
                return View(db.Properties.ToList()); 
            }
            else
            {
                var userId = User.Identity.GetUserId();
                var properties = db.Properties.Where(p => p.UserId ==
                userId).ToList();
                return View(properties);
            }
        }
        public ActionResult Buy()
        {           
            return View(db.Properties.ToList());
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Properties/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Address,NumberOfRooms,Size,Price")] Property property)
        {
            property.UserId = User.Identity.GetUserId();

            ModelState.Clear();
            TryValidateModel(property);
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("Myproperties");
            }

            return View(property);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            if (property.UserId != userId && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,NumberOfRooms,Size,Price,UserId")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Myproperties");
            }
            return View(property);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            if (property.UserId != userId && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
            db.SaveChanges();
            return RedirectToAction("Myproperties");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
