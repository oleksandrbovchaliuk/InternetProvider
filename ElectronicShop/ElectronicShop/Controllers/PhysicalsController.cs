using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectronicShop;

namespace ElectronicShop.Controllers
{
    public class PhysicalsController : Controller
    {
        private InternetProviderEntities db = new InternetProviderEntities();

        // GET: Physicals
        public ActionResult Index()
        {
            var physical = db.Physical.Include(p => p.Customers);
            return View(physical.ToList());
        }

        // GET: Physicals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physical physical = db.Physical.Find(id);
            if (physical == null)
            {
                return HttpNotFound();
            }
            return View(physical);
        }

        // GET: Physicals/Create
        public ActionResult Create()
        {
            ViewBag.ID_Customer = new SelectList(db.Customers, "ID_Customer", "ID_Customer");
            return View();
        }

        // POST: Physicals/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Customer,Surname,First_Name,Number_Of_Passport,Physical_Adress,Phone_Number,Password")] Physical physical)
        {
            if (ModelState.IsValid)
            {
                db.Physical.Add(physical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Customer = new SelectList(db.Customers, "ID_Customer", "ID_Customer", physical.ID_Customer);
            return View(physical);
        }

        // GET: Physicals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physical physical = db.Physical.Find(id);
            if (physical == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Customer = new SelectList(db.Customers, "ID_Customer", "ID_Customer", physical.ID_Customer);
            return View(physical);
        }

        // POST: Physicals/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Customer,Surname,First_Name,Number_Of_Passport,Physical_Adress,Phone_Number,Password")] Physical physical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(physical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Customer = new SelectList(db.Customers, "ID_Customer", "ID_Customer", physical.ID_Customer);
            return View(physical);
        }

        // GET: Physicals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physical physical = db.Physical.Find(id);
            if (physical == null)
            {
                return HttpNotFound();
            }
            return View(physical);
        }

        // POST: Physicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Physical physical = db.Physical.Find(id);
            db.Physical.Remove(physical);
            db.SaveChanges();
            return RedirectToAction("Index");
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
