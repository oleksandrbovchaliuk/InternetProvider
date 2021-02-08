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
    public class FirmsController : Controller
    {
        private InternetProviderEntities db = new InternetProviderEntities();

        // GET: Firms
        public ActionResult Index()
        {
            var firm = db.Firm.Include(f => f.Customers);
            return View(firm.ToList());
        }

        // GET: Firms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firm.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            return View(firm);
        }

        // GET: Firms/Create
        public ActionResult Create()
        {
            ViewBag.ID_Customer = new SelectList(db.Customers, "ID_Customer", "ID_Customer");
            return View();
        }

        // POST: Firms/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Customer,Company_Name,Physical_Adress,Phone_Number,Password")] Firm firm)
        {
            if (ModelState.IsValid)
            {
                db.Firm.Add(firm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Customer = new SelectList(db.Customers, "ID_Customer", "ID_Customer", firm.ID_Customer);
            return View(firm);
        }

        // GET: Firms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firm.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Customer = new SelectList(db.Customers, "ID_Customer", "ID_Customer", firm.ID_Customer);
            return View(firm);
        }

        // POST: Firms/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Customer,Company_Name,Physical_Adress,Phone_Number,Password")] Firm firm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Customer = new SelectList(db.Customers, "ID_Customer", "ID_Customer", firm.ID_Customer);
            return View(firm);
        }

        // GET: Firms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firm.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            return View(firm);
        }

        // POST: Firms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firm firm = db.Firm.Find(id);
            db.Firm.Remove(firm);
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
