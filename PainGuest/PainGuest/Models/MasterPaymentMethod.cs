namespace PainGuest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    [Table("MasterPaymentMethod")]
    public partial class MasterPaymentMethod
    {
        public int ID { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }

    }
}