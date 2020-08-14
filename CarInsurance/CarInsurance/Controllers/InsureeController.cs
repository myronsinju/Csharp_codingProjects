using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;
using Microsoft.Ajax.Utilities;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,QUOTE")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                TimeSpan ageCompare = DateTime.Now - insuree.DateOfBirth;
                if (Convert.ToInt32(ageCompare.TotalDays) <= (18 * 365))
                {
                    insuree.QUOTE += 100;
                }
                else if (Convert.ToInt32(ageCompare.TotalDays) <= (25 * 365) && Convert.ToInt32(ageCompare.TotalDays) >= (19 * 365))
                {
                    insuree.QUOTE += 50;
                }
                else
                {
                    insuree.QUOTE += 25;
                }
                if (insuree.CarYear < 2000)
                {
                    insuree.QUOTE += 25;
                }
                else if (insuree.CarYear > 2015)
                {
                    insuree.QUOTE += 25;
                }
                if (insuree.CarMake.ToLower() == "porsche")
                {
                    insuree.QUOTE += 25;
                    if (insuree.CarModel.ToLower() == "911 carrera")
                    {
                        insuree.QUOTE += 25;
                    }
                }
                for (int i = 0; i < insuree.SpeedingTickets; i++)
                {
                    insuree.QUOTE += 10;
                }
                if (insuree.DUI)
                {
                    insuree.QUOTE += insuree.QUOTE * 0.25m;
                }
                if (insuree.CoverageType)
                {
                    insuree.QUOTE += insuree.QUOTE * 0.50m;
                }
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,QUOTE")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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
//1. Calculate a quote:

//Start with a base of $50 / month.

//If the user is 18 and under, add $100 to the monthly total.

//If the user is between 19 and 25, add $50 to the monthly total.

//If the user is over 25, add $25 to the monthly total.

//If the car's year is before 2000, add $25 to the monthly total.

//If the car's year is after 2015, add $25 to the monthly total.

//If the car's Make is a Porsche, add $25 to the price.

//If the car's Make is a Porsche and its model is a 911 Carrera, add an additional $25 to the price.

//Add $10 to the monthly total for every speeding ticket the user has.

//If the user has ever had a DUI, add 25% to the total.

//If it's full coverage, add 50% to the total.

//2. Create an Admin view for a site administrator.This page must:

//Show all quotes issued, along with the user's first name, last name, and email address.