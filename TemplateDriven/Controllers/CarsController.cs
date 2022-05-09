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
    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Location);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.Location_Id = new SelectList(db.Locations, "Location_Id", "Location_Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Car_Id,Brand_Name,Available,Description,Regi_Number,Color,Transitions,Price,Capacity,ModelYear,Location_Id,CarTypes")] Car car)
        {
            //get location based on selected 
            Location location = db.Locations.Find(car.Location_Id);

            if (ModelState.IsValid)
            {
                //increment total cars after adding new car
                location.Total_Cars++;
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Location_Id = new SelectList(db.Locations, "Location_Id", "Location_Name", car.Location_Id);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location_Id = new SelectList(db.Locations, "Location_Id", "Location_Name", car.Location_Id);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Car_Id,Brand_Name,Available,Description,Regi_Number,Color,Transitions,Price,Capacity,ModelYear,Location_Id,CarTypes")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Location_Id = new SelectList(db.Locations, "Location_Id", "Location_Name", car.Location_Id);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);

            //get location based on selected 
            Location location = db.Locations.Find(car.Location_Id);
            //decrement  number of cars in the when deleting a car
            //confirm if the total is greater than zero
            if (location.Total_Cars > 0)
            {
                location.Total_Cars--;
            }
            //should not proceed if total cars is zero
            else if (location.Total_Cars <= 0)
            {
                ModelState.AddModelError("", "Cannot delete");
            }
            db.Cars.Remove(car); 
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
