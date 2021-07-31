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
using System.IO;
using Microsoft.AspNet.Identity;

namespace CRUD_Operations.Controllers
{
    public class MissingPersonsController : Controller
    {
        private cntContext db = new cntContext();

        [Authorize]
        // GET: MissingPersons
        public ActionResult Index()
        {
            string strCurrentUserId = User.Identity.GetUserId();
            return View(db.MissingPersons.Where(m => m.userID == strCurrentUserId).ToList());
        }

        // GET: MissingPersons/Details/5
        [Authorize]
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
        [Authorize]
        // GET: MissingPersons/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MissingPerson im)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(im.ImageFile.FileName);
                im.ImagePath = "~/images/" + fileName;
                im.userID = User.Identity.GetUserId();
                fileName = Path.Combine(Server.MapPath("~/images"), fileName);
                im.ImageFile.SaveAs(fileName);
                db.MissingPersons.Add(im);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(im);
        }

        [Authorize]
        // GET: MissingPersons/Edit/5
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
            ViewBag.te = db.MissingPersons.Find(id).ImagePath;
            return View(missingPerson);
        }

        // POST: MissingPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase ImageFile, MissingPerson im)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string fileName = Path.GetFileName(im.ImageFile.FileName);
                    im.ImagePath = "~/images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/images"), fileName);
                    im.ImageFile.SaveAs(fileName);
                    im.userID = User.Identity.GetUserId();


                    db.Entry(im).State = EntityState.Modified;
                    //string oldImgPath = Request.MapPath(Session["imgPath"].ToString());
                    //if (db.SaveChanges() > 0)
                    //{
                    //    if (System.IO.File.Exists(oldImgPath))
                    //    {
                    //        System.IO.File.Delete(oldImgPath);
                    //    }

                    //}
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                   // im.ImagePath = Session["imgPath"].ToString();
                    db.Entry(im).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                       return RedirectToAction("Index");
                    }

                }
            }
            return View();
        }


        [Authorize]
        // GET: MissingPersons/Delete/5
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

        [Authorize]
        // POST: MissingPersons/Delete/5
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


        
        // GET: MissingPersons/Details/5
        public ActionResult ViewPerson(int? id)
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
    }
}


