namespace PainGuest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    
    [Table("MonthlyPayments")]
    public partial class MonthlyPayments
    {
        public int id { get; set; }
        [Display(Name = "Guest Number"), Required,]
        public string GuestNumber { get; set; }

        [Display(Name = "Amount"), Required,DataType(DataType.Currency)]
        public decimal? Amount { get; set; }

        [Display(Name = "Payment Date"), Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Payment_date { get; set; }

        [Display(Name = "Payment Method"), Required]
        public int? PaymentMethodId { get; set; }
        //public string PaymentMethodName { get; set; }

        [Display(Name = "Payment Reference Number")]
        public string PaymentReferenceNumber { get; set; }

        [Display(Name = "Remarks"), StringLength(250)]
        public string Remarks { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        
    }
}