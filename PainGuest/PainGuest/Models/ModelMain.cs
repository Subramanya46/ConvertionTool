using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PainGuest.Models
{
    public partial class ModelMain : DbContext
    {
        public ModelMain()
            : base("name=ModelMain")
        {
        }
        public virtual DbSet<GuestDetail> GuestDetails { get; set; }
        public virtual DbSet<MasterRoom> MasterRooms { get; set; }
        public virtual DbSet<MasterRoomType> MasterRoomTypes { get; set; }
        public virtual DbSet<MasterGender> MasterGenders { get; set; }
        public virtual DbSet<MonthlyPayments> MonthlyPaymentss { get; set; }
        public virtual DbSet<MasterPaymentMethod> MasterPaymentMethods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.GuestName)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.GuestMobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.GuestFathersName)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.GuestPermanentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.GuestTemporaryAddress)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.GuestMailId)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.EducationalQualification)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.EmergencyContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.EmergencyContactNumberRelationship)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.GuestOfficeAddress)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.Gst_OfficeTelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.MonthlyRent)
                .HasPrecision(10, 2);

            modelBuilder.Entity<GuestDetail>()
                .Property(e => e.AdvanceAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MasterRoomType>()
                .Property(e => e.RoomTypeName)
                .IsUnicode(false);
        }
        public System.Data.Entity.DbSet<PainGuest.Models.AdvanceReciptView> AdvanceReciptViews { get; set; }
    }
}
