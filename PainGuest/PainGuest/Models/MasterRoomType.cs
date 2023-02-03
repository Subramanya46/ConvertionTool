namespace PainGuest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterRoomType")]
    public partial class MasterRoomType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int RoomTypeID { get; set; }

        [StringLength(50)]
        public string RoomTypeName { get; set; }
    }
}
