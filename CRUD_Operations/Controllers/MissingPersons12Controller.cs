using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_Operations.Models;
using Missing_Person.Models.Entity;

namespace CRUD_Operations.Controllers
{
    public class MissingPersons12Controller : Controller
    {
        private cntContext db = new cntContext();

        // GET: MissingPersons12
        public ActionResult Index()
        {
            return View(db.MissingPersons.ToList());
        }

        // GET: MissingPersons12/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissingPerson missingPerson = db.MissingPersons.Find(id);
            if (missingPerson == null)
            {
                return HttpNotFound();
            }
            return View(missingPerson);
        }

        // GET: MissingPersons12/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MissingPersons12/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "personID,Name,LastName,FatherName,Age,Nation,Gender,DOB,MissingPlace,MissingFrom,ImagePath,Email,Phone,userID")] MissingPerson missingPerson)
        {
            if (ModelState.IsValid)
            {
                db.MissingPersons.Add(missingPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(missingPerson);
        }

        // GET: MissingPersons12/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissingPerson missingPerson = db.MissingPersons.Find(id);
            if (missingPerson == null)
            {
                return HttpNotFound();
            }
            return View(missingPerson);
        }

        // POST: MissingPersons12/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "personID,Name,LastName,FatherName,Age,Nation,Gender,DOB,MissingPlace,MissingFrom,ImagePath,Email,Phone,userID")] MissingPerson missingPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missingPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(missingPerson);
        }

        // GET: MissingPersons12/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissingPerson missingPerson = db.MissingPersons.Find(id);
            if (missingPerson == null)
            {
                return HttpNotFound();
            }
            return View(missingPerson);
        }

        // POST: MissingPersons12/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissingPerson missingPerson = db.MissingPersons.Find(id);
            db.MissingPersons.Remove(missingPerson);
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
