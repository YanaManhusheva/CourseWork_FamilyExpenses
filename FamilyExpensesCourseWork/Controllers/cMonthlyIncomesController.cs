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
    public class cMonthlyIncomesController : Controller
    {
        private FamilyExpensesEntities db = new FamilyExpensesEntities();

        // GET: cMonthlyIncomes
        public ActionResult Index()
        {
            var cMonthlyIncomes = db.cMonthlyIncomes.Include(c => c.cFamilyMember).Include(c => c.cIncomeCategory);
            return View(cMonthlyIncomes.ToList());
        }

        // GET: cMonthlyIncomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cMonthlyIncome cMonthlyIncome = db.cMonthlyIncomes.Find(id);
            if (cMonthlyIncome == null)
            {
                return HttpNotFound();
            }
            return View(cMonthlyIncome);
        }

        // GET: cMonthlyIncomes/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.IncomeCategoryId = new SelectList(db.cIncomeCategories, "Id", "Name");
            return View(new cMonthlyIncome { FamilyMemberId = id });
        }

        // POST: cMonthlyIncomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IncomeSum,IncomeCategoryId,FamilyMemberId")] cMonthlyIncome cMonthlyIncome)
        {
            if (ModelState.IsValid)
            {
                db.cMonthlyIncomes.Add(cMonthlyIncome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyMemberId = new SelectList(db.cFamilyMembers, "Id", "Name", cMonthlyIncome.FamilyMemberId);
            ViewBag.IncomeCategoryId = new SelectList(db.cIncomeCategories, "Id", "Name", cMonthlyIncome.IncomeCategoryId);
            return View(cMonthlyIncome);
        }

        // GET: cMonthlyIncomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cMonthlyIncome cMonthlyIncome = db.cMonthlyIncomes.Find(id);
            if (cMonthlyIncome == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyMemberId = new SelectList(db.cFamilyMembers, "Id", "Name", cMonthlyIncome.FamilyMemberId);
            ViewBag.IncomeCategoryId = new SelectList(db.cIncomeCategories, "Id", "Name", cMonthlyIncome.IncomeCategoryId);
            return View(cMonthlyIncome);
        }

        // POST: cMonthlyIncomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IncomeSum,IncomeCategoryId,FamilyMemberId")] cMonthlyIncome cMonthlyIncome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMonthlyIncome).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyMemberId = new SelectList(db.cFamilyMembers, "Id", "Name", cMonthlyIncome.FamilyMemberId);
            ViewBag.IncomeCategoryId = new SelectList(db.cIncomeCategories, "Id", "Name", cMonthlyIncome.IncomeCategoryId);
            return View(cMonthlyIncome);
        }

        // GET: cMonthlyIncomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cMonthlyIncome cMonthlyIncome = db.cMonthlyIncomes.Find(id);
            if (cMonthlyIncome == null)
            {
                return HttpNotFound();
            }
            return View(cMonthlyIncome);
        }

        // POST: cMonthlyIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cMonthlyIncome cMonthlyIncome = db.cMonthlyIncomes.Find(id);
            db.cMonthlyIncomes.Remove(cMonthlyIncome);
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
