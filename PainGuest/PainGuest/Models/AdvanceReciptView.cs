namespace PainGuest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class AdvanceReciptView
    {
        public int id { get; set; }

        [Display(Name = "Guest Name"), Required, StringLength(100)]
        public string GuestName { get; set; }

        [Display(Name = "Advance Amount")]
        public decimal? AdvanceAmount { get; set; }

        //[Display(Name = "Advance  Amount Date")]
        //public decimal? da { get; set; }
    }
}