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
    public class AccessoryTypesController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: AccessoryTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.AccessoryTypes.ToListAsync());
        }

        // GET: AccessoryTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryType accessoryType = await db.AccessoryTypes.FindAsync(id);
            if (accessoryType == null)
            {
                return HttpNotFound();
            }
            return View(accessoryType);
        }

        // GET: AccessoryTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessoryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AccessoryTypeID,TypeName")] AccessoryType accessoryType)
        {
            if (ModelState.IsValid)
            {
                db.AccessoryTypes.Add(accessoryType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accessoryType);
        }

        // GET: AccessoryTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryType accessoryType = await db.AccessoryTypes.FindAsync(id);
            if (accessoryType == null)
            {
                return HttpNotFound();
            }
            return View(accessoryType);
        }

        // POST: AccessoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AccessoryTypeID,TypeName")] AccessoryType accessoryType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoryType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accessoryType);
        }

        // GET: AccessoryTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryType accessoryType = await db.AccessoryTypes.FindAsync(id);
            if (accessoryType == null)
            {
                return HttpNotFound();
            }
            return View(accessoryType);
        }

        // POST: AccessoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AccessoryType accessoryType = await db.AccessoryTypes.FindAsync(id);
            db.AccessoryTypes.Remove(accessoryType);
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
