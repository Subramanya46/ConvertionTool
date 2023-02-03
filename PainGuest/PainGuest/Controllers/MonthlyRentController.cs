using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PainGuest.Models;

namespace PainGuest.Controllers
{
    public class MonthlyRentController : Controller
    {
        private ModelMain db = new ModelMain();
        // GET: MonthlyRent
        public ActionResult Index()
        {
            var test = db.MonthlyPaymentss.ToList();
            var data = (from a in db.MonthlyPaymentss
                        join b in db.MasterPaymentMethods on a.PaymentMethodId equals b.PaymentMethodId
                        select new MonthlyPaymentsViewModel
                        {
                          id = a.id,
                          GuestNumber = a.GuestNumber,
                          Amount = a.Amount,
                          Payment_date = a.Payment_date,
                          PaymentMethodName = b.PaymentMethodName,
                          PaymentReferenceNumber = a.PaymentReferenceNumber,
                          Remarks = a.Remarks
                        }).ToList();
            return View(data);
        }

        // GET: MonthlyRent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyPayments monthlyPayments = db.MonthlyPaymentss.Find(id);
            if (monthlyPayments == null)
            {
                return HttpNotFound();
            }
            return View(monthlyPayments);
        }
        public ActionResult PrintRecipt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyPayments monthlyPayments = db.MonthlyPaymentss.Find(id);
            if (monthlyPayments == null)
            {
                return HttpNotFound();
            }
            return View(monthlyPayments);
        }
        // GET: MonthlyRent/Create
        public ActionResult Create()
        {
            ViewBag.PaymentMethodId = new SelectList(db.MasterPaymentMethods, "paymentMethodId", "PaymentmethodName");
            return View();
        }

        // POST: MonthlyRent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,GuestNumber,Amount,Payment_date,PaymentMethodId,PaymentReferenceNumber,Remarks")] MonthlyPayments monthlyPayments)
        {
            if (ModelState.IsValid)
            {
                monthlyPayments.DateCreated = DateTime.Now;
                monthlyPayments.DateUpdated = DateTime.Now;
                db.MonthlyPaymentss.Add(monthlyPayments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monthlyPayments);
        }

        // GET: MonthlyRent/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.PaymentMethodId = new SelectList(db.MasterPaymentMethods, "paymentMethodId", "PaymentmethodName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyPayments monthlyPayments = db.MonthlyPaymentss.Find(id);
            if (monthlyPayments == null)
            {
                return HttpNotFound();
            }
            return View(monthlyPayments);
        }

        // POST: MonthlyRent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,GuestNumber,Amount,Payment_date,PaymentMethodId,PaymentReferenceNumber,Remarks,DateCreated")] MonthlyPayments monthlyPayments)
        {
            if (ModelState.IsValid)
            {
                monthlyPayments.DateUpdated = DateTime.Now;
                db.Entry(monthlyPayments).State = EntityState.Modified;
                db.Entry(monthlyPayments).Property(x => x.DateCreated).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlyPayments);
        }

        // GET: MonthlyRent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyPayments monthlyPayments = db.MonthlyPaymentss.Find(id);
            if (monthlyPayments == null)
            {
                return HttpNotFound();
            }
            return View(monthlyPayments);
        }

        // POST: MonthlyRent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlyPayments monthlyPayments = db.MonthlyPaymentss.Find(id);
            db.MonthlyPaymentss.Remove(monthlyPayments);
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
