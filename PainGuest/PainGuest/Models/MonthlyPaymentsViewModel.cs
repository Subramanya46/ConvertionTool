namespace PainGuest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;


    public partial class MonthlyPaymentsViewModel
    {

        public int id { get; set; }
        [Display(Name = "Guest Number")]
        public string GuestNumber { get; set; }

        [Display(Name = "Amount")]
        public decimal? Amount { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime? Payment_date { get; set; }

        //[Display(Name = "Payment Method")]
        //public int? PaymentMethodId { get; set; }

        [Display(Name = "Payment Method Name")]
        public string PaymentMethodName { get; set; }

        [Display(Name = "Payment Reference Number")]
        public string PaymentReferenceNumber { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}