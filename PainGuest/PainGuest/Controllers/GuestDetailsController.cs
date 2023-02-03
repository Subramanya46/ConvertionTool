using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PainGuest.Models;
using Rotativa;
using Rotativa.Options;

namespace PainGuest.Controllers
{
    public class GuestDetailsController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: GuestDetails
        public ActionResult Index()
        {
            var data = (from a in db.GuestDetails
                        join b in db.MasterGenders on a.GuestGenderID equals b.gender_id
                        join c in db.MasterRoomTypes on a.RoomType equals c.RoomTypeID
                        select new GuestDetailsView
                        {
                            id = a.id,
                            GuestName = a.GuestName,
                            GuestFathersName = a.GuestFathersName,
                            GuestGenderName = b.genderName,
                            GuestMobileNumber = a.GuestMobileNumber,
                            GuestMailId = a.GuestMailId,
                            EducationalQualification = a.EducationalQualification,
                            GuestAge = a.GuestAge,
                            GuestDateOfBirth = a.GuestDateOfBirth,
                            GuestPermanentAddress = a.GuestPermanentAddress,
                            GuestTemporaryAddress = a.GuestTemporaryAddress,
                            GuestOfficeAddress = a.GuestOfficeAddress,
                            Gst_OfficeTelephoneNumber = a.Gst_OfficeTelephoneNumber,
                            MonthlyRent = a.MonthlyRent,
                            AdvanceAmount = a.AdvanceAmount,
                            DateOfAdmission = a.DateOfAdmission,
                            EmergencyContactNumber = a.EmergencyContactNumber,
                            EmergencyContactNumberRelationship = a.EmergencyContactNumberRelationship,
                            //DepositAmount = a.DepositAmount,
                            RoomNumber = a.RoomNumber,
                            BedNumber = a.BedNumber,
                            RoomTypeName = c.RoomTypeName
                        });
            return View(data.ToList());
        }

        // GET: GuestDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            if (guestDetail == null)
            {
                return HttpNotFound();
            }
            return View(guestDetail);
        }
        [HttpGet]
        public ActionResult PrintAdvanceRecept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            AdvanceReciptView advanceReciptView = new AdvanceReciptView();
            advanceReciptView.id = guestDetail.id;
            advanceReciptView.GuestName = guestDetail.GuestName;
            advanceReciptView.AdvanceAmount = guestDetail.AdvanceAmount;
            if (advanceReciptView == null)
            {
                return HttpNotFound();
            }
            //return View(advanceReciptView);
            return new PartialViewAsPdf("PrintAdvanceRecept", advanceReciptView)
            {

                PageOrientation = Orientation.Portrait,
                PageSize = Size.B0,
                //CustomSwitches = "--footer-center \" [page] Page of [toPage] Pages\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"",
                FileName = "AdvanceReciept_" + advanceReciptView.GuestName + ".pdf"
            };
        }
        // GET: GuestDetails/Create
        public ActionResult Create()
        {
            GuestDetail guestDetail = new GuestDetail();
            ViewBag.RoomType = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName");
            ViewBag.GuestGenderID = new SelectList(db.MasterGenders, "gender_id", "genderName");
            ViewBag.RoomNumber = new SelectList(db.MasterRooms.Where(x => x.RoomTypeID == guestDetail.RoomType), "RoomNumber", "RoomNumber");
            ViewBag.BedNumber = new SelectList(db.MasterRooms.Where(x => x.RoomTypeID == guestDetail.RoomType).Where(x => x.RoomNumber == guestDetail.RoomNumber), "BedNumber", "BedNumber");
            return View();
        }

        // POST: GuestDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,GuestName,GuestGenderID,GuestMobileNumber,GuestFathersName,GuestDateOfBirth,GuestAge,GuestPermanentAddress,GuestTemporaryAddress,GuestMailId,EducationalQualification,DateOfAdmission,EmergencyContactNumber,EmergencyContactNumberRelationship,GuestOfficeAddress,Gst_OfficeTelephoneNumber,MonthlyRent,AdvanceAmount,RoomType,RoomNumber,BedNumber,isRoomVacant")] GuestDetail guestDetail)
        {
            try
            {
                ViewBag.RoomType = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName", guestDetail.RoomType);
                ViewBag.GuestGenderID = new SelectList(db.MasterGenders, "gender_id", "genderName", guestDetail.GuestGenderID);
                ViewBag.RoomNumber = new SelectList(db.MasterRooms, "RoomNumber", "RoomNumber", guestDetail.RoomNumber);
                ViewBag.BedNumber = new SelectList(db.MasterRooms, "BedNumber", "BedNumber", guestDetail.BedNumber);

                if (guestDetail.RoomType > 0)
                {
                    ViewBag.RoomNumber = new SelectList(db.MasterRooms.Where(x => x.RoomTypeID == guestDetail.RoomType), "RoomNumber", "RoomNumber", guestDetail.RoomNumber);
                    var c = db.MasterRooms.Where(x => x.RoomTypeID == guestDetail.RoomType).Select(x => x.RoomNumber).Distinct().ToList();
                    //ViewBag.RoomNumber = new SelectList(c, "RoomNumber", "RoomNumber", guestDetail.RoomNumber);
                    //bind Room Numbers
                }
                if (guestDetail.RoomNumber > 0)
                {
                    ViewBag.BedNumber = new SelectList(db.MasterRooms.Where(x => x.RoomTypeID == guestDetail.RoomType).Where(x => x.RoomNumber == guestDetail.RoomNumber), "BedNumber", "BedNumber", guestDetail.BedNumber);
                    //bind Bed Numbers
                }
                //Checking Room and Bed Available or Not 
                if (isRoomBedAvailable(guestDetail.RoomNumber, guestDetail.BedNumber))
                {
                    if (ModelState.IsValid)
                    {
                        guestDetail.DateCreated = DateTime.Now;
                        guestDetail.DateUpdated = DateTime.Now;
                        guestDetail.isRoomVacant = "N";
                        db.GuestDetails.Add(guestDetail);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(guestDetail);
                }
                else
                {
                    //Room Not Available;
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: GuestDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.RoomType = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName");
            ViewBag.GuestGenderID = new SelectList(db.MasterGenders, "gender_id", "genderName");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            if (guestDetail == null)
            {
                return HttpNotFound();
            }
            return View(guestDetail);
        }

        // POST: GuestDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,GuestName,GuestGenderID,GuestMobileNumber,GuestFathersName,GuestDateOfBirth,GuestAge,GuestPermanentAddress,GuestTemporaryAddress,GuestMailId,EducationalQualification,DateOfAdmission,EmergencyContactNumber,EmergencyContactNumberRelationship,GuestOfficeAddress,Gst_OfficeTelephoneNumber,MonthlyRent,AdvanceAmount,RoomType,RoomNumber,BedNumber")] GuestDetail guestDetail)
        {
            if (ModelState.IsValid)
            {
                guestDetail.DateUpdated = DateTime.Now;
                guestDetail.isRoomVacant = "N";
                db.Entry(guestDetail).State = EntityState.Modified;
                db.Entry(guestDetail).Property(x => x.DateCreated).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomType = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName", guestDetail.RoomType);
            ViewBag.GuestGenderID = new SelectList(db.MasterGenders, "gender_id", "genderName", guestDetail.GuestGenderID);
            return View(guestDetail);
        }

        // GET: GuestDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.RoomType = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName");
            ViewBag.GuestGenderID = new SelectList(db.MasterGenders, "gender_id", "genderName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            if (guestDetail == null)
            {
                return HttpNotFound();
            }
            return View(guestDetail);
        }

        // POST: GuestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            db.GuestDetails.Remove(guestDetail);
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
        public bool isRoomBedAvailable(int roomNumber, int BedNumber)
        {
            var count = db.GuestDetails.Where(a => a.RoomNumber == roomNumber & a.BedNumber == BedNumber & a.isRoomVacant == "N").Count();
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        ////[HttpPost]
        ////public ActionResult PrintSavePDF()
        ////{
        ////    return new ActionAsPdf("PrintAdvanceRecept");
        ////}
    }
}
