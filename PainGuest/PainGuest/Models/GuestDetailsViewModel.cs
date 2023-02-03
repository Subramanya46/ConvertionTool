using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PainGuest.Models
{
    public class GuestDetailsView
    {
        public int id { get; set; }
        [Display(Name = "Guest Name")]
        public string GuestName { get; set; }
        public int? GuestGenderID { get; set; }
        [Display(Name = "Gender")]
        public string GuestGenderName { get; set; }
        [Display(Name = "Mobile Number")]
        public string GuestMobileNumber { get; set; }
        [Display(Name = "Father Name")]
        public string GuestFathersName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? GuestDateOfBirth { get; set; }
        [Display(Name = "Age")]
        public int? GuestAge { get; set; }
        [Display(Name = "Permanent Address")]
        public string GuestPermanentAddress { get; set; }
        [Display(Name = "Temporory address")]
        public string GuestTemporaryAddress { get; set; }
        [Display(Name = "Mail Id")]
        public string GuestMailId { get; set; }
        [Display(Name = "Educational Qualification")]
        public string EducationalQualification { get; set; }
        [Display(Name = "Date of Admission")]
        public DateTime? DateOfAdmission { get; set; }
        [Display(Name = "Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }
        [Display(Name = "Relationship")]
        public string EmergencyContactNumberRelationship { get; set; }
        [Display(Name = "Office Address")]
        public string GuestOfficeAddress { get; set; }
        [Display(Name = "Telephone Number")]
        public string Gst_OfficeTelephoneNumber { get; set; }
        [Display(Name = "Monthly Rent")]
        public decimal? MonthlyRent { get; set; }

        [Display(Name = "Advance Amount")]
        public decimal? AdvanceAmount { get; set; }
        [Display(Name = "Deposit Amount")]
        public decimal? DepositAmount { get; set; }

        public DateTime? DateCreated { get; set; }
        public int RoomType { get; set; }
        [Display(Name = "Room Type")]
        public string RoomTypeName { get; set; }
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        [Display(Name = "Bed Number")]
        public int BedNumber { get; set; }
        public string isRoomVacant { get; set; }

    }
}