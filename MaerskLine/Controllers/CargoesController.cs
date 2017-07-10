using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;

namespace MaerskLine.Controllers
{
    public class CargoesController : Controller
    {
        private MaerskLineEntities db = new MaerskLineEntities();

        // GET: Cargoes
        public ActionResult Index()
        {
            var cargo = db.Cargo.Include(c => c.Customer).Include(c => c.Warehouse);
            return View(cargo.ToList());
        }

        // GET: Cargoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargoes/Create
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Customer, "CustID", "Name");
            ViewBag.WarehouseID = new SelectList(db.Warehouse, "WarehouseID", "Location");
            return View();
        }

        // POST: Cargoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CargoID,Type,Weight,CustID,WarehouseID")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Cargo.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustID = new SelectList(db.Customer, "CustID", "Name", cargo.CustID);
            ViewBag.WarehouseID = new SelectList(db.Warehouse, "WarehouseID", "Location", cargo.WarehouseID);
            return View(cargo);
        }

        // GET: Cargoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustID = new SelectList(db.Customer, "CustID", "Name", cargo.CustID);
            ViewBag.WarehouseID = new SelectList(db.Warehouse, "WarehouseID", "Location", cargo.WarehouseID);
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CargoID,Type,Weight,CustID,WarehouseID")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustID = new SelectList(db.Customer, "CustID", "Name", cargo.CustID);
            ViewBag.WarehouseID = new SelectList(db.Warehouse, "WarehouseID", "Location", cargo.WarehouseID);
            return View(cargo);
        }

        // GET: Cargoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cargo cargo = db.Cargo.Find(id);
            db.Cargo.Remove(cargo);
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
