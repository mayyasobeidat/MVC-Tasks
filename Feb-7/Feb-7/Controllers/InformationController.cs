using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Feb_7.Models;

namespace Feb_7.Controllers
{
    public class InformationController : Controller
    {
        private MVCEntities db = new MVCEntities();

        // GET: Information
        public ActionResult Index()
        {
            return View(db.Information.ToList());
        }

        // GET: Information/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // GET: Information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Information/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Image,CV")] Information information, HttpPostedFileBase image, HttpPostedFileBase cv)
        {


            if (ModelState.IsValid)
            {

                string imgPath = "";
                string cvPath = "";
                if (image != null)
                {
                    imgPath = Path.GetFileName(image.FileName);
                    image.SaveAs(Path.Combine(Server.MapPath("~/image/") + image.FileName));
                }



                if (cv != null)
                {
                    cvPath = Path.GetFileName(cv.FileName);
                    cv.SaveAs(Path.Combine(Server.MapPath("~/CVs/") + cv.FileName));
                }


                information.Image = imgPath;
                information.CV = cvPath;

                db.Information.Add(information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(information);

        }

        // GET: Information/Edit/5
        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information information = db.Information.Find(id);

            Session["IMG"] = information.Image;
            Session["CV"] = information.CV;

            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // POST: Information/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Image,CV")] Information information, HttpPostedFileBase image, HttpPostedFileBase cv)
        {
            information.Image = Session["IMG"].ToString();
            information.CV = Session["CV"].ToString();

            if (ModelState.IsValid)
            {
                string imgPath = "";
                string cvPath = "";
                if (image != null)
                {
                    imgPath = Path.GetFileName(image.FileName);
                    image.SaveAs(Path.Combine(Server.MapPath("~/image/") + image.FileName));
                    information.Image = imgPath;
                }

                if (cv != null)
                {
                    cvPath = Path.GetFileName(cv.FileName);
                    cv.SaveAs(Path.Combine(Server.MapPath("~/CVs/") + cv.FileName));
                    information.CV = cvPath;
                }

                db.Entry(information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(information);
        }
        // GET: Information/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // POST: Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Information information = db.Information.Find(id);
            db.Information.Remove(information);
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
