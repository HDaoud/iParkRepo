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
    public class BookingsController : Controller
    {
        private iParkEntities db = new iParkEntities();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.ParkingLot).Include(b => b.User);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(string id)
        {
            id = id.Replace("%20", "");//Removes empty characters
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.lot_id = new SelectList(db.ParkingLots, "lot_id", "status");
            ViewBag.UID = new SelectList(db.Users, "UID", "Name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book_id,UID,lot_id,booking_time,checkin_time,release_time,checkout_time")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lot_id = new SelectList(db.ParkingLots, "lot_id", "status", booking.lot_id);
            ViewBag.UID = new SelectList(db.Users, "UID", "Name", booking.UID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(string id)
        {
            id = id.Replace("%20", "");//Removes empty characters;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.lot_id = new SelectList(db.ParkingLots, "lot_id", "status", booking.lot_id);
            ViewBag.UID = new SelectList(db.Users, "UID", "Name", booking.UID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,UID,lot_id,booking_time,checkin_time,release_time,checkout_time")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lot_id = new SelectList(db.ParkingLots, "lot_id", "status", booking.lot_id);
            ViewBag.UID = new SelectList(db.Users, "UID", "Name", booking.UID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(string id)
        {
            id = id.Replace("%20", "");//Removes empty characters
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
