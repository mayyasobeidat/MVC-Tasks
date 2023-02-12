﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Feb_12.Models;

namespace Feb_12.Controllers
{
    public class StudentCoursController : Controller
    {
        private dataEntities1 db = new dataEntities1();

        // GET: StudentCours
        public ActionResult Index()
        {
            var studentCourses = db.StudentCourses.Include(s => s.Cours).Include(s => s.Student);
            return View(studentCourses.ToList());
        }

        // GET: StudentCours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCours studentCours = db.StudentCourses.Find(id);
            if (studentCours == null)
            {
                return HttpNotFound();
            }
            return View(studentCours);
        }

        // GET: StudentCours/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        // POST: StudentCours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,CourseID,note")] StudentCours studentCours)
        {
            if (ModelState.IsValid)
            {
                db.StudentCourses.Add(studentCours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentCours.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", studentCours.StudentID);
            return View(studentCours);
        }

        // GET: StudentCours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCours studentCours = db.StudentCourses.Find(id);
            if (studentCours == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentCours.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", studentCours.StudentID);
            return View(studentCours);
        }

        // POST: StudentCours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,CourseID,note")] StudentCours studentCours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentCours.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", studentCours.StudentID);
            return View(studentCours);
        }

        // GET: StudentCours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCours studentCours = db.StudentCourses.Find(id);
            if (studentCours == null)
            {
                return HttpNotFound();
            }
            return View(studentCours);
        }

        // POST: StudentCours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCours studentCours = db.StudentCourses.Find(id);
            db.StudentCourses.Remove(studentCours);
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
