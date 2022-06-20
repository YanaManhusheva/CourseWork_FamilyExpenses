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
    public class cFamilyMembersController : Controller
    {
        private FamilyExpensesEntities db = new FamilyExpensesEntities();

        // GET: cFamilyMembers
        public ActionResult Index()
        {
            var cFamilyMembers = db.cFamilyMembers.Include(c => c.cFamilyRole).Include(c => c.сFamily);
            return View(cFamilyMembers.ToList());
        }

        // GET: cFamilyMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cFamilyMember cFamilyMember = db.cFamilyMembers.Find(id);
            if (cFamilyMember == null)
            {
                return HttpNotFound();
            }
            var expenseSum = cFamilyMember.vExpenses.Sum(p => p.ExpenseSum);
            var incomeSum = cFamilyMember.cMonthlyIncomes.Sum(p => p.IncomeSum);
            ViewBag.ExpenseSum = expenseSum;
            ViewBag.IncomeSum = incomeSum;
            return View(cFamilyMember);
           
        }

        // GET: cFamilyMembers/Create
        public ActionResult Create()
        {
            ViewBag.FamilyRoleId = new SelectList(db.cFamilyRoles, "Id", "Role");
            ViewBag.FamilyId = new SelectList(db.сFamily, "Id", "Surname");
            return View();
        }

        // POST: cFamilyMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FamilyRoleId,FamilyId")] cFamilyMember cFamilyMember)
        {
            if (ModelState.IsValid)
            {
                db.cFamilyMembers.Add(cFamilyMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyRoleId = new SelectList(db.cFamilyRoles, "Id", "Role", cFamilyMember.FamilyRoleId);
            ViewBag.FamilyId = new SelectList(db.сFamily, "Id", "Surname", cFamilyMember.FamilyId);
            return View(cFamilyMember);
        }

        // GET: cFamilyMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cFamilyMember cFamilyMember = db.cFamilyMembers.Find(id);
            if (cFamilyMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyRoleId = new SelectList(db.cFamilyRoles, "Id", "Role", cFamilyMember.FamilyRoleId);
            ViewBag.FamilyId = new SelectList(db.сFamily, "Id", "Surname", cFamilyMember.FamilyId);
            return View(cFamilyMember);
        }

        // POST: cFamilyMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FamilyRoleId,FamilyId")] cFamilyMember cFamilyMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFamilyMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyRoleId = new SelectList(db.cFamilyRoles, "Id", "Role", cFamilyMember.FamilyRoleId);
            ViewBag.FamilyId = new SelectList(db.сFamily, "Id", "Surname", cFamilyMember.FamilyId);
            return View(cFamilyMember);
        }

        // GET: cFamilyMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cFamilyMember cFamilyMember = db.cFamilyMembers.Find(id);
            if (cFamilyMember == null)
            {
                return HttpNotFound();
            }
            return View(cFamilyMember);
        }

        // POST: cFamilyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cFamilyMember cFamilyMember = db.cFamilyMembers.Find(id);
            db.cFamilyMembers.Remove(cFamilyMember);
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
