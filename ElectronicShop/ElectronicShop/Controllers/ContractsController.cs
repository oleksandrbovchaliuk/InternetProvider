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
    public class ContractsController : Controller
    {
        private InternetProviderEntities db = new InternetProviderEntities();

        // GET: Contracts
        public ActionResult Index()
        {
            var contract = db.Contract.Include(c => c.Closing_Contract).Include(c => c.Additional_Services).Include(c => c.Customers).Include(c => c.Employee).Include(c => c.Tariff_Plan);
            return View(contract.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.ID_Contract = new SelectList(db.Closing_Contract, "ID_Contract", "Reason");
            ViewBag.ID_Contract = new SelectList(db.Additional_Services, "ID_Services", "ID_Services");
            ViewBag.ID_Contract = new SelectList(db.Customers, "ID_Customer", "ID_Customer");
            ViewBag.ID_Employee = new SelectList(db.Employee, "ID_Employee", "Surname");
            ViewBag.ID_Tariff_Plan = new SelectList(db.Tariff_Plan, "ID_Tariff_Plan", "Name_Of_Tariff");
            return View();
        }

        // POST: Contracts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Contract,ID_Employee,ID_Customer,ID_Tariff_Plan,ID_Services,Date_Of_Signing,Balance")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contract.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Contract = new SelectList(db.Closing_Contract, "ID_Contract", "Reason", contract.ID_Contract);
            ViewBag.ID_Contract = new SelectList(db.Additional_Services, "ID_Services", "ID_Services", contract.ID_Contract);
            ViewBag.ID_Contract = new SelectList(db.Customers, "ID_Customer", "ID_Customer", contract.ID_Contract);
            ViewBag.ID_Employee = new SelectList(db.Employee, "ID_Employee", "Surname", contract.ID_Employee);
            ViewBag.ID_Tariff_Plan = new SelectList(db.Tariff_Plan, "ID_Tariff_Plan", "Name_Of_Tariff", contract.ID_Tariff_Plan);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Contract = new SelectList(db.Closing_Contract, "ID_Contract", "Reason", contract.ID_Contract);
            ViewBag.ID_Contract = new SelectList(db.Additional_Services, "ID_Services", "ID_Services", contract.ID_Contract);
            ViewBag.ID_Contract = new SelectList(db.Customers, "ID_Customer", "ID_Customer", contract.ID_Contract);
            ViewBag.ID_Employee = new SelectList(db.Employee, "ID_Employee", "Surname", contract.ID_Employee);
            ViewBag.ID_Tariff_Plan = new SelectList(db.Tariff_Plan, "ID_Tariff_Plan", "Name_Of_Tariff", contract.ID_Tariff_Plan);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Contract,ID_Employee,ID_Customer,ID_Tariff_Plan,ID_Services,Date_Of_Signing,Balance")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Contract = new SelectList(db.Closing_Contract, "ID_Contract", "Reason", contract.ID_Contract);
            ViewBag.ID_Contract = new SelectList(db.Additional_Services, "ID_Services", "ID_Services", contract.ID_Contract);
            ViewBag.ID_Contract = new SelectList(db.Customers, "ID_Customer", "ID_Customer", contract.ID_Contract);
            ViewBag.ID_Employee = new SelectList(db.Employee, "ID_Employee", "Surname", contract.ID_Employee);
            ViewBag.ID_Tariff_Plan = new SelectList(db.Tariff_Plan, "ID_Tariff_Plan", "Name_Of_Tariff", contract.ID_Tariff_Plan);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contract.Find(id);
            db.Contract.Remove(contract);
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
