﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FireStation.Models;
using FireStation.Models.ViewModel;

namespace FireStation.Controllers
{
    public class ShiftRegisterController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: ShiftRegister
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    var tbl_ShiftRegister = db.tbl_ShiftRegister.Include(t => t.tbl_shift);
                    return View(tbl_ShiftRegister.ToList());
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult GetShiftByStateId(int Eid)
        {
            List<tbl_shift> objshift = new List<tbl_shift>();
            objshift = db.tbl_shift.Where(m => m.StateId == Eid).ToList();
            SelectList obg = new SelectList(objshift, "ShiftId", "ShiftName",0);
            return Json(obg);
        }
        [HttpPost]
        public ActionResult GetshiftEmployee(int Eid)
        {

           var objshift = (from i in db.tbl_Employee
                            join ai in db.tbl_ShiftEmployee on i.EmployeeId equals ai.Shiftid
                            join a in db.tbl_shift on ai.Shiftid equals a.ShiftId
                            where ai.Shiftid == Eid
                            orderby a.ShiftName
                            select new EmVM() { Name = string.Format("{0}{1}",i.EmployeeLastName,i.EmployeeFName),Id=i.EmployeeMCode }).ToList();
            return Json(objshift ,JsonRequestBehavior.AllowGet);
        }
        // GET: ShiftRegister/Details/5k
        public ActionResult Details(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_ShiftRegister tbl_ShiftRegister = db.tbl_ShiftRegister.Find(id);
                    if (tbl_ShiftRegister == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbl_ShiftRegister);
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: ShiftRegister/Create
        public ActionResult Create()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.ShiftRegisterShifId = new SelectList(db.tbl_shift, "ShiftId", "ShiftName");
                    ViewBag.OpState = db.tbl_State.ToList();
                    ViewBag.Emp = db.tbl_Employee.ToList();
                    return View();
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: ShiftRegister/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftRegisterid,ShiftRegisterDec,ShiftRegisterCommandor,ShiftRegisterTimeStart,ShiftRegisterTimeEnd,ShiftRegisterDateStart,ShiftRegisteridDateEnd,ShiftRegisterurl,ShiftRegisterShifId")] tbl_ShiftRegister tbl_ShiftRegister)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.OpState = db.tbl_State.ToList();
                    ViewBag.Emp = db.tbl_Employee.ToList();
                    if (ModelState.IsValid)
                    {
                        db.tbl_ShiftRegister.Add(tbl_ShiftRegister);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    ViewBag.ShiftRegisterShifId = new SelectList(db.tbl_shift, "ShiftId", "ShiftName", tbl_ShiftRegister.ShiftRegisterShifId);
                    return View(tbl_ShiftRegister);
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: ShiftRegister/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();

                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_ShiftRegister tbl_ShiftRegister = db.tbl_ShiftRegister.Find(id);
                    if (tbl_ShiftRegister == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.ShiftRegisterShifId = new SelectList(db.tbl_shift, "ShiftId", "ShiftName", tbl_ShiftRegister.ShiftRegisterShifId);
                    return View(tbl_ShiftRegister);
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: ShiftRegister/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShiftRegisterid,ShiftRegisterDec,ShiftRegisterCommandor,ShiftRegisterTimeStart,ShiftRegisterTimeEnd,ShiftRegisterDateStart,ShiftRegisteridDateEnd,ShiftRegisterurl,ShiftRegisterShifId")] tbl_ShiftRegister tbl_ShiftRegister)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (ModelState.IsValid)
                    {
                        db.Entry(tbl_ShiftRegister).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.ShiftRegisterShifId = new SelectList(db.tbl_shift, "ShiftId", "ShiftName", tbl_ShiftRegister.ShiftRegisterShifId);
            return View(tbl_ShiftRegister);
        }

        // GET: ShiftRegister/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_ShiftRegister tbl_ShiftRegister = db.tbl_ShiftRegister.Find(id);
                    if (tbl_ShiftRegister == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbl_ShiftRegister);
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: ShiftRegister/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    tbl_ShiftRegister tbl_ShiftRegister = db.tbl_ShiftRegister.Find(id);
                    db.tbl_ShiftRegister.Remove(tbl_ShiftRegister);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
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
