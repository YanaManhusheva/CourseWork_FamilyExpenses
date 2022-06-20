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
    public class vExpensesController : Controller
    {
        private FamilyExpensesEntities db = new FamilyExpensesEntities();

        // GET: vExpenses
        public ActionResult Index()
        {
            var vExpenses = db.vExpenses.Include(v => v.cExpensePurpose).Include(v => v.cFamilyMember);
            return View(vExpenses.ToList());
        }

        // GET: vExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vExpense vExpense = db.vExpenses.Find(id);
            if (vExpense == null)
            {
                return HttpNotFound();
            }
            return View(vExpense);
        }

        // GET: vExpenses/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ExpensePurposeId = new SelectList(db.cExpensePurposes, "Id", "Name");
            return View(new vExpense { FamilyMemberId = id});
        }

        // POST: vExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,ExpenseSum,ExpensePurposeId,FamilyMemberId")] vExpense vExpense)
        {
            if (ModelState.IsValid)
            {
                db.vExpenses.Add(vExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpensePurposeId = new SelectList(db.cExpensePurposes, "Id", "Name", vExpense.ExpensePurposeId);
            ViewBag.FamilyMemberId = new SelectList(db.cFamilyMembers, "Id", "Name", vExpense.FamilyMemberId);
            return View(vExpense);
        }

        // GET: vExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vExpense vExpense = db.vExpenses.Find(id);
            if (vExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpensePurposeId = new SelectList(db.cExpensePurposes, "Id", "Name", vExpense.ExpensePurposeId);
            ViewBag.FamilyMemberId = new SelectList(db.cFamilyMembers, "Id", "Name", vExpense.FamilyMemberId);
            return View(vExpense);
        }

        // POST: vExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,ExpenseSum,ExpensePurposeId,FamilyMemberId")] vExpense vExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpensePurposeId = new SelectList(db.cExpensePurposes, "Id", "Name", vExpense.ExpensePurposeId);
            ViewBag.FamilyMemberId = new SelectList(db.cFamilyMembers, "Id", "Name", vExpense.FamilyMemberId);
            return View(vExpense);
        }

        // GET: vExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vExpense vExpense = db.vExpenses.Find(id);
            if (vExpense == null)
            {
                return HttpNotFound();
            }
            return View(vExpense);
        }

        // POST: vExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vExpense vExpense = db.vExpenses.Find(id);
            db.vExpenses.Remove(vExpense);
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
