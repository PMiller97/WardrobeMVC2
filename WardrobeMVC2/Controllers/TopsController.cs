using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC2.Models;

namespace WardrobeMVC2.Controllers
{
    public class TopsController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: Tops
        public ActionResult Index()
        {
            var tops = db.Tops.Include(t => t.TopType);
            return View(tops.ToList());
        }

        // GET: Tops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Top top = db.Tops.Find(id);
            if (top == null)
            {
                return HttpNotFound();
            }
            return View(top);
        }

        // GET: Tops/Create
        public ActionResult Create()
        {
            ViewBag.TopTypeID = new SelectList(db.TopTypes, "TopTypeID", "TypeName");
            return View();
        }

        // POST: Tops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopID,TopName,TopPhoto,TopColor,TopSeason,TopOccasion,TopTypeID")] Top top)
        {
            if (ModelState.IsValid)
            {
                /*Got this code from Pete, but I could not get it to work myself. Too many failed attempts, and the code would show up on the view instead of the picture for some reason.*/
                /*if (top.TopTypeID.Equals(1))
                {
                    top.TopPhoto = "~/Content/rsz_rhcpshirt.png";
                }
                if (top.TopTypeID.Equals(2))
                {
                    top.TopPhoto = "~/Content/rsz_maroonvneck.png";
                }
                if (top.TopTypeID.Equals(3))
                {
                    top.TopPhoto = "~/Content/rsz_graytanktop.png";
                }
                if (top.TopTypeID.Equals(4))
                {
                    top.TopPhoto = "~/Content/rsz_moonphases.png";
                }
                if (top.TopTypeID.Equals(5))
                {
                    top.TopPhoto = "~/Content/rsz_linkinparkhoodie.png";
                }
                if (top.TopTypeID.Equals(6))
                {
                    top.TopPhoto = "~/Content/rsz_favoriteflannel.png";
                }
                else
                {
                    top.TopPhoto = "~/Content/rsz_zeldaleggings.png";
                }*/

                db.Tops.Add(top);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TopTypeID = new SelectList(db.TopTypes, "TopTypeID", "TypeName", top.TopTypeID);
            return View(top);
        }

        // GET: Tops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Top top = db.Tops.Find(id);
            if (top == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopTypeID = new SelectList(db.TopTypes, "TopTypeID", "TypeName", top.TopTypeID);
            return View(top);
        }

        // POST: Tops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopID,TopName,TopPhoto,TopColor,TopSeason,TopOccasion,TopTypeID")] Top top)
        {
            if (ModelState.IsValid)
            {
                db.Entry(top).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopTypeID = new SelectList(db.TopTypes, "TopTypeID", "TypeName", top.TopTypeID);
            return View(top);
        }

        // GET: Tops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Top top = db.Tops.Find(id);
            if (top == null)
            {
                return HttpNotFound();
            }
            return View(top);
        }

        // POST: Tops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Top top = db.Tops.Find(id);
            db.Tops.Remove(top);
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
