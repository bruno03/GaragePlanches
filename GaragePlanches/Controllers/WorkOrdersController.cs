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
    public class WorkOrdersController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: WorkOrders
        public async Task<ActionResult> Index()
        {
            var workOrder = db.WorkOrder.Include(w => w.Car).Include(w => w.Customer);
            return View(await workOrder.ToListAsync());
        }

        // GET: WorkOrders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = await db.WorkOrder.FindAsync(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public ActionResult Create(int CustID = 0)
        {
            ViewBag.CarID = new SelectList(db.Car, "CarID", "FullName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName");
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WorkOrderID,EntryDate,Price,Kilometers,CustomerID,CarID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrder.Add(workOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Car, "CarID", "Brand", workOrder.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname", workOrder.CustomerID);
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = await db.WorkOrder.FindAsync(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Car, "CarID", "Brand", workOrder.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname", workOrder.CustomerID);
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WorkOrderID,EntryDate,Price,Kilometers,CustomerID,CarID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Car, "CarID", "Brand", workOrder.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Firstname", workOrder.CustomerID);
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = await db.WorkOrder.FindAsync(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WorkOrder workOrder = await db.WorkOrder.FindAsync(id);
            db.WorkOrder.Remove(workOrder);
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
