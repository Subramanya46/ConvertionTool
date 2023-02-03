namespace PainGuest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GuestDetail
    {
        public int id { get; set; }

        [Display(Name = "Guest Name"), Required, StringLength(100)]
        public string GuestName { get; set; }

        [Display(Name = "Gender"), Required]
        public int GuestGenderID { get; set; }

        [Display(Name = "Mobile Number"), Required, MinLength(10, ErrorMessage = "Mobile Number should have 10 Numbers"), MaxLength(10, ErrorMessage = "Mobile Number Cant be more than 10 Number"), DataType(DataType.PhoneNumber)]
        public string GuestMobileNumber { get; set; }


        [Display(Name = "Father Name"), StringLength(100),Required]
        public string GuestFathersName { get; set; }

        [Display(Name = "Date of Birth"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GuestDateOfBirth { get; set; }

        [Display(Name = "Age"), Range(18, 100), Required]
        public int? GuestAge { get; set; }

        [Display(Name = "Permanent Address"), StringLength(250), Required]
        public string GuestPermanentAddress { get; set; }

        [Display(Name = "Temperory Address"), StringLength(250)]
        public string GuestTemporaryAddress { get; set; }

        [Display(Name = "Email Address"), StringLength(100), RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter Valid Email Address")]
        public string GuestMailId { get; set; }

        [Display(Name = "Educational Qualification"), StringLength(100)]
        public string EducationalQualification { get; set; }


        [Display(Name = "Admission Date"), Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfAdmission { get; set; }

        [Display(Name = "Emergency Contact Number"), StringLength(10), MinLength(10), MaxLength(10), Required]
        public string EmergencyContactNumber { get; set; }

        [Display(Name = "Relationship"), StringLength(50), DataType(DataType.Text), Required]
        public string EmergencyContactNumberRelationship { get; set; }

        [Display(Name = "Office Address"), StringLength(250)]
        public string GuestOfficeAddress { get; set; }

        [Display(Name = "Office Phone Number"), StringLength(10)]
        public string Gst_OfficeTelephoneNumber { get; set; }

        [Display(Name = "Monthly Rent"), Required]
        public decimal? MonthlyRent { get; set; }

        [Display(Name = "Advance Amount"), Required]
        public decimal? AdvanceAmount { get; set; }

        //[Display(Name = "Deposit Amount")]
        //public decimal? DepositAmount { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        [Display(Name = "Room Type"), Required]
        public int RoomType { get; set; }

        [Display(Name = "Room Number"), Required]
        public int RoomNumber { get; set; }

        [Display(Name = "Bed Number"), Required]
        public int BedNumber { get; set; }
        public string isRoomVacant { get; set; }
    }
}
