using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GaragePlanches.Models;

namespace GaragePlanches.Controllers
{
    public class CarsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Cars
        public async Task<ActionResult> Index()
        {
            var car = db.Car.Include(c => c.Customer);
            return View(await car.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Car.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CarID,Brand,Model,Immatrication,Year,CustomerID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Car.Add(car);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname", car.CustomerID);
            return View(car);
        }


        // GET: Cars/Create
        public ActionResult CreateCustomer(int id)
        {
            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname");
            //ViewBag.CustomerID = id; 
            ViewBag.Customer = db.Customers.Find(id);
            Car car = new Car();
            car.CustomerID = id; 
            return View(car);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCustomer([Bind(Include = "CarID,Brand,Model,Immatrication,Year,CustomerID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Car.Add(car);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname", car.CustomerID);
            return View(car);
        }


        // GET: Cars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Car.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname", car.CustomerID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CarID,Brand,Model,Immatrication,Year,CustomerID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname", car.CustomerID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Car.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Car car = await db.Car.FindAsync(id);
            db.Car.Remove(car);
            await db.SaveChangesAsync();
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
