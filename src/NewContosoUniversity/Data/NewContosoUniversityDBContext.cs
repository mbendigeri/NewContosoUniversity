using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewContosoUniversity.Entity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewContosoUniversity.Data
{
    public class NewContosoUniversityDBContext : DbContext
    {
        public NewContosoUniversityDBContext(DbContextOptions<NewContosoUniversityDBContext> options) : base(options)
        {

        }
        public DbSet<WCCourseType> WCCourseType { get; set; }

        public DbSet<WCRoleMaster> WCRoleMaster { get; set; }

        public DbSet<WCCommunicationChannelType> WCCommunicationChannelType { get; set; }
        public DbSet<WCCourseMaster> WCCourseMaster { get; set; }
        public DbSet<WCCustomerDetails> WCCustomerDetails { get; set; }
        public DbSet<WCContactDetails> WCContactDetails { get; set; }
        
        public DbSet<WCCourseDetails> WCCourseDetails { get; set; }

        public DbSet<WCCourseSchedule> WCCourseSchedule { get; set; }
        
        public DbSet<WCStaffRole> WCStaffRole { get; set; }

        public DbSet<WCStaffDetails> WCStaffDetails { get; set; }

        public DbSet<WCInteraction> WCInteractions { get; set; }
        public DbSet<WCInterestedCourses> WCInterestedCourses { get; set; }
        
        public DbSet<WCHolidayCalendar> WCHolidayCalendar { get; set; }
        public DbSet<WCFaceToFaceMeeting> WCFaceToFaceMeeting { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* builder.Entity<WCCustomerDetails>().HasKey(m => m.CustomerID);
             builder.Entity<WCContactDetails>().HasKey(m => m.ContactID);
             builder.Entity<WCCourseDetails>().HasKey(m => m.CourseDetailID);
             builder.Entity<WCCourseMaster>().HasKey(m => m.CourseID);
             */

            builder.Entity<WCStaffRole>().HasKey(WC => new { WC.StaffID, WC.RoleID});

            /*builder.Entity<WCStaffDetails>()
                    .HasMany<WCRoleMaster>(S => S.StaffRoles);
                    */
                    
            builder.Entity<WCStaffRole>(entity =>
            { 
             entity.HasKey(WC => new { WC.StaffID, WC.RoleID });

                entity.HasOne(WS => WS.Staff)
                       .WithMany(WCSR => WCSR.StaffRoles)
                       .HasForeignKey(WS => WS.StaffID)
                       .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(WCR => WCR.Role)
                          .WithMany(WCSR => WCSR.StaffRoles)
                          .HasForeignKey(WCR => WCR.RoleID)
                          .OnDelete(DeleteBehavior.Restrict);

            });


            

            //builder.Entity<WCStaffRole>().Property(t => t.RoleID).ValueGeneratedNever;


            builder.Entity<WCInterestedCourses>().HasKey(WC => new { WC.InteractionID, WC.CourseID, WC.CourseScheduleID });

            builder.Entity(typeof(WCInterestedCourses))
            .HasOne(typeof(WCInteraction), "Interaction")
            .WithMany()
            .HasForeignKey("InteractionID")
            .OnDelete(DeleteBehavior.Restrict); // no ON DELETE

            builder.Entity<WCInterestedCourses>().HasKey(WC => new { WC.InteractionID, WC.CourseID, WC.CourseScheduleID });
            builder.Entity(typeof(WCInterestedCourses))
            .HasOne(typeof(WCCourseMaster), "Course")
            .WithMany()
            .HasForeignKey("CourseID")
            .OnDelete(DeleteBehavior.Restrict); // no ON DELETE

            builder.Entity<WCInterestedCourses>().HasKey(WC => new { WC.InteractionID, WC.CourseID, WC.CourseScheduleID });

            builder.Entity(typeof(WCInterestedCourses))
            .HasOne(typeof(WCCourseSchedule), "CourseSchedule")
            .WithMany()
            .HasForeignKey("CourseScheduleID")
            .OnDelete(DeleteBehavior.Restrict); // no ON DELETE

            //builder.Entity<WCInterestedCourses>().HasKey(WC => new { WC.InteractionID, WC.CourseID});

            // shadow properties
            builder.Entity<WCCustomerDetails>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCContactDetails>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCStaffDetails>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCCourseDetails>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCCourseMaster>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCCourseType>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCInteractionType>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCCommunicationChannelType>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCCourseSchedule>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCRoleMaster>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCStaffRole>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCInterestedCourses>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCInteraction>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCHolidayCalendar>().Property<DateTime>("ModifiedOn");
            builder.Entity<WCFaceToFaceMeeting>().Property<DateTime>("ModifiedOn");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<WCCustomerDetails>();
            updateUpdatedProperty<WCContactDetails>();
            updateUpdatedProperty<WCStaffDetails>();
            updateUpdatedProperty<WCCourseDetails>();
            updateUpdatedProperty<WCCourseMaster>();
            updateUpdatedProperty<WCInteractionType>();
            updateUpdatedProperty<WCCommunicationChannelType>();
            updateUpdatedProperty<WCCourseType>();
            updateUpdatedProperty<WCCourseSchedule>();
            updateUpdatedProperty<WCRoleMaster>();
            updateUpdatedProperty<WCStaffRole>();
            updateUpdatedProperty<WCInterestedCourses>();
            updateUpdatedProperty<WCInteraction>();
            updateUpdatedProperty<WCHolidayCalendar>();
            updateUpdatedProperty<WCFaceToFaceMeeting>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("ModifiedOn").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
