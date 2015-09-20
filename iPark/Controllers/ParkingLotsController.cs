using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iPark.Models;

namespace iPark.Controllers
{
    public class ParkingLotsController : Controller
    {
        private iParkEntities db = new iParkEntities();

        // GET: ParkingLots
        public ActionResult Index()
        {
            return View(db.ParkingLots.ToList());
        }

        // GET: ParkingLots/Details/5
        public ActionResult Details(string id)
        {
            id = id.Replace("%20", "");//Removes empty characters
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = db.ParkingLots.Find(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            return View(parkingLot);
        }

        // GET: ParkingLots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkingLots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lot_id,status,location")] ParkingLot parkingLot)
        {
            if (ModelState.IsValid)
            {
                db.ParkingLots.Add(parkingLot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkingLot);
        }

        // GET: ParkingLots/Edit/5
        public ActionResult Edit(string id)
        {
            id = id.Replace("%20", "");//Removes empty characters
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = db.ParkingLots.Find(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            return View(parkingLot);
        }

        // POST: ParkingLots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lot_id,status,location")] ParkingLot parkingLot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingLot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkingLot);
        }

        // GET: ParkingLots/Delete/5
        public ActionResult Delete(string id)
        {
            id = id.Replace("%20", "");//Removes empty characters
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = db.ParkingLots.Find(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            return View(parkingLot);
        }

        // POST: ParkingLots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ParkingLot parkingLot = db.ParkingLots.Find(id);
            db.ParkingLots.Remove(parkingLot);
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
