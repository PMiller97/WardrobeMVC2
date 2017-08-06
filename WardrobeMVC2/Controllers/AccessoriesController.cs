using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC2.Models;

namespace WardrobeMVC2.Controllers
{
    public class AccessoriesController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: Accessories
        public async Task<ActionResult> Index()
        {
            var accessories = db.Accessories.Include(a => a.AccessoryType);
            return View(await accessories.ToListAsync());
        }

        // GET: Accessories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = await db.Accessories.FindAsync(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            ViewBag.AccessoryTypeID = new SelectList(db.AccessoryTypes, "AccessoryTypeID", "TypeName");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AccessoryID,AccessoryName,AccessoryPhoto,AccessoryColor,AccessorySeason,AccessoryOccasion,AccessoryTypeID")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryTypeID = new SelectList(db.AccessoryTypes, "AccessoryTypeID", "TypeName", accessory.AccessoryTypeID);
            return View(accessory);
        }

        // GET: Accessories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = await db.Accessories.FindAsync(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryTypeID = new SelectList(db.AccessoryTypes, "AccessoryTypeID", "TypeName", accessory.AccessoryTypeID);
            return View(accessory);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AccessoryID,AccessoryName,AccessoryPhoto,AccessoryColor,AccessorySeason,AccessoryOccasion,AccessoryTypeID")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryTypeID = new SelectList(db.AccessoryTypes, "AccessoryTypeID", "TypeName", accessory.AccessoryTypeID);
            return View(accessory);
        }

        // GET: Accessories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = await db.Accessories.FindAsync(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Accessory accessory = await db.Accessories.FindAsync(id);
            db.Accessories.Remove(accessory);
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
