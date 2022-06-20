using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyExpensesCourseWork.Models;

namespace FamilyExpensesCourseWork.Controllers
{
    public class сFamilyController : Controller
    {
        private FamilyExpensesEntities db = new FamilyExpensesEntities();

        // GET: сFamily
        public ActionResult Index()
        {
            return View(db.сFamily.ToList());
        }

        // GET: сFamily/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            сFamily сFamily = db.сFamily.Find(id);
            if (сFamily == null)
            {
                return HttpNotFound();
            }
            var famCount = сFamily.cFamilyMembers.Count;
            ViewBag.FamCount = famCount;
            return View(сFamily);
        }

        // GET: сFamily/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: сFamily/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname")] сFamily сFamily)
        {
            if (ModelState.IsValid)
            {
                db.сFamily.Add(сFamily);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(сFamily);
        }

        // GET: сFamily/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            сFamily сFamily = db.сFamily.Find(id);
            if (сFamily == null)
            {
                return HttpNotFound();
            }
            return View(сFamily);
        }

        // POST: сFamily/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname")] сFamily сFamily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(сFamily).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(сFamily);
        }

        // GET: сFamily/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            сFamily сFamily = db.сFamily.Find(id);
            if (сFamily == null)
            {
                return HttpNotFound();
            }
            return View(сFamily);
        }

        // POST: сFamily/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            сFamily сFamily = db.сFamily.Find(id);
            db.сFamily.Remove(сFamily);
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
