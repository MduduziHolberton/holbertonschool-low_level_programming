using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TemplateDriven.Models;

namespace TemplateDriven.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Car).Include(b => b.Location);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
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
            ViewBag.Car_Id = new SelectList(db.Cars, "Car_Id", "Brand_Name");
            ViewBag.Location_Id = new SelectList(db.Locations, "Location_Id", "Location_Name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_Id,Rental_Date,Return_Date,Total_Price,Booking_Status,Car_Id,Registration_Number,Brand_Name,Location_Id,Location_Name")] Booking booking)
        {
            //get location selected for bookings
            Location location = db.Locations.Find(booking.Location_Id);

            if (ModelState.IsValid)
            {
                //CHECK TOTAL CARS AVAILABLE BEFORE MAKING A BOOKING
                if (location.Total_Cars_Available > 0)
                {
                    //DECREASE NUMBER OF CARS AFTER A BOOKING IS MADE
                    location.Total_Cars_Available--;
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if(location.Total_Cars <=0)
                {
                    ModelState.AddModelError("", "No Cars Avalailable at this location in this moment ");
                }
            }

            ViewBag.Car_Id = new SelectList(db.Cars, "Car_Id", "Brand_Name", booking.Car_Id);
            ViewBag.Location_Id = new SelectList(db.Locations, "Location_Id", "Location_Name", booking.Location_Id);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Car_Id = new SelectList(db.Cars, "Car_Id", "Brand_Name", booking.Car_Id);
            ViewBag.Location_Id = new SelectList(db.Locations, "Location_Id", "Location_Name", booking.Location_Id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_Id,Rental_Date,Return_Date,Total_Price,Booking_Status,Car_Id,Registration_Number,Brand_Name,Location_Id,Location_Name")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Car_Id = new SelectList(db.Cars, "Car_Id", "Brand_Name", booking.Car_Id);
            ViewBag.Location_Id = new SelectList(db.Locations, "Location_Id", "Location_Name", booking.Location_Id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
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
        public ActionResult DeleteConfirmed(int id)
        {

            Booking booking = db.Bookings.Find(id);


            //get the location selected by the user when making a booking
            Location location = db.Locations.Find(booking.Location_Id);

            location.Total_Cars++;
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
