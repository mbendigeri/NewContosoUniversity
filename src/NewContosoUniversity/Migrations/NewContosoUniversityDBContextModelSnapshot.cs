using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NewContosoUniversity.Data;

namespace NewContosoUniversity.Migrations
{
    [DbContext(typeof(NewContosoUniversityDBContext))]
    partial class NewContosoUniversityDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCommunicationChannelType", b =>
                {
                    b.Property<int>("CommunicationChannelTypeID");

                    b.Property<string>("CommunicationChannelTypeDesc");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("CommunicationChannelTypeID");

                    b.ToTable("WCCommunicationChannelType");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCContactDetails", b =>
                {
                    b.Property<int>("ContactID");

                    b.Property<string>("ContactPerson");

                    b.Property<int?>("CustomerID");

                    b.Property<string>("Email");

                    b.Property<bool>("EmergencyPhone");

                    b.Property<string>("LinkedInURL");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PhoneType");

                    b.Property<bool>("PrimaryPhone");

                    b.Property<string>("RelationShip");

                    b.Property<int?>("StaffID");

                    b.Property<string>("WebsiteURL");

                    b.HasKey("ContactID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StaffID");

                    b.ToTable("WCContactDetails");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCourseDetails", b =>
                {
                    b.Property<int>("CourseDetailID");

                    b.Property<string>("CourseChapter");

                    b.Property<string>("CourseChapterDescription");

                    b.Property<int>("CourseID");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("CourseDetailID");

                    b.HasIndex("CourseID");

                    b.ToTable("WCCourseDetails");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCourseMaster", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<string>("CourseDescription");

                    b.Property<string>("CourseTitle");

                    b.Property<int>("CourseTypeID");

                    b.Property<int>("Duration");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("CourseID");

                    b.HasIndex("CourseTypeID");

                    b.ToTable("WCCourseMaster");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCourseSchedule", b =>
                {
                    b.Property<int>("CourseScheduleID");

                    b.Property<int>("CourseID");

                    b.Property<string>("CourseScheduleName");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<DateTime>("StartDateTime");

                    b.HasKey("CourseScheduleID");

                    b.HasIndex("CourseID");

                    b.ToTable("WCCourseSchedule");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCourseType", b =>
                {
                    b.Property<int>("CourseTypeID");

                    b.Property<string>("CourseTypeDesc");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("CourseTypeID");

                    b.ToTable("WCCourseType");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCustomerDetails", b =>
                {
                    b.Property<int>("CustomerID");

                    b.Property<int>("AddressTypeID");

                    b.Property<string>("Building");

                    b.Property<string>("City");

                    b.Property<string>("DoorNo");

                    b.Property<string>("FirstName");

                    b.Property<string>("LandMark");

                    b.Property<string>("LastName");

                    b.Property<string>("Locality");

                    b.Property<string>("MiddleName");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("OccupationID");

                    b.Property<string>("Organisation");

                    b.Property<string>("Pincode");

                    b.Property<string>("Street1");

                    b.Property<string>("Street2");

                    b.HasKey("CustomerID");

                    b.ToTable("WCCustomerDetails");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCFaceToFaceMeeting", b =>
                {
                    b.Property<int>("FaceToFaceMeetingID");

                    b.Property<int>("AllotedTimeInMinutes");

                    b.Property<int>("CompletedTimeInMinutes");

                    b.Property<DateTime>("FaceToFaceMeetingDateTime");

                    b.Property<int>("InteractionID");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("courseID");

                    b.Property<int>("staffID");

                    b.HasKey("FaceToFaceMeetingID");

                    b.HasIndex("InteractionID");

                    b.HasIndex("courseID");

                    b.HasIndex("staffID");

                    b.ToTable("WCFaceToFaceMeeting");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCHolidayCalendar", b =>
                {
                    b.Property<int>("HolidayID");

                    b.Property<DateTime>("HolidayEndDateTime");

                    b.Property<string>("HolidayReason");

                    b.Property<DateTime>("HolidayStartDateTime");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("HolidayID");

                    b.ToTable("WCHolidayCalendar");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCInteraction", b =>
                {
                    b.Property<int>("InteractionID");

                    b.Property<DateTime?>("CallBackEndDate");

                    b.Property<DateTime?>("CallBackEndTime");

                    b.Property<DateTime?>("CallBackStartDate");

                    b.Property<DateTime?>("CallBackStartTime");

                    b.Property<int>("CommunicationChannelTypeID");

                    b.Property<int>("ContactID");

                    b.Property<int>("CustomerID");

                    b.Property<string>("Discussion");

                    b.Property<int?>("FaceToFaceMeetingID");

                    b.Property<DateTime>("InteractDateTime");

                    b.Property<int>("InteractiontypeID");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("InteractionID");

                    b.HasIndex("CommunicationChannelTypeID");

                    b.HasIndex("ContactID");

                    b.HasIndex("InteractiontypeID");

                    b.ToTable("WCInteractions");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCInteractionType", b =>
                {
                    b.Property<int>("InteractionTypeID");

                    b.Property<string>("InteractionTypeDesc");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("InteractionTypeID");

                    b.ToTable("WCInteractionType");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCInterestedCourses", b =>
                {
                    b.Property<int>("InteractionID");

                    b.Property<int>("CourseID");

                    b.Property<int>("CourseScheduleID");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int?>("WCInteractionInteractionID");

                    b.HasKey("InteractionID", "CourseID", "CourseScheduleID");

                    b.HasIndex("CourseID");

                    b.HasIndex("CourseScheduleID");

                    b.HasIndex("InteractionID");

                    b.HasIndex("WCInteractionInteractionID");

                    b.ToTable("WCInterestedCourses");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCRoleMaster", b =>
                {
                    b.Property<int>("RoleID");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("RoleDescription");

                    b.Property<int?>("WCStaffDetailsStaffID");

                    b.HasKey("RoleID");

                    b.HasIndex("WCStaffDetailsStaffID");

                    b.ToTable("WCRoleMaster");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCStaffDetails", b =>
                {
                    b.Property<int>("StaffID");

                    b.Property<int>("AddressTypeID");

                    b.Property<string>("Building");

                    b.Property<string>("City");

                    b.Property<string>("DoorNo");

                    b.Property<string>("FirstName");

                    b.Property<string>("LandMark");

                    b.Property<string>("LastName");

                    b.Property<string>("Locality");

                    b.Property<string>("MiddleName");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Pincode");

                    b.Property<string>("Street1");

                    b.Property<string>("Street2");

                    b.HasKey("StaffID");

                    b.ToTable("WCStaffDetails");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCStaffRole", b =>
                {
                    b.Property<int>("StaffID");

                    b.Property<int>("RoleID");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("StaffID", "RoleID");

                    b.HasIndex("RoleID");

                    b.HasIndex("StaffID");

                    b.ToTable("WCStaffRole");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCContactDetails", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCCustomerDetails", "Customer")
                        .WithMany("ContactDetails")
                        .HasForeignKey("CustomerID");

                    b.HasOne("NewContosoUniversity.Entity.WCStaffDetails", "Staff")
                        .WithMany("ContactDetails")
                        .HasForeignKey("StaffID");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCourseDetails", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCCourseMaster", "Course")
                        .WithMany("CourseDetails")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCourseMaster", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCCourseType", "CourseType")
                        .WithMany()
                        .HasForeignKey("CourseTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCCourseSchedule", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCCourseMaster", "Course")
                        .WithMany("CourseSchedule")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCFaceToFaceMeeting", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCInteraction", "Interaction")
                        .WithMany("FaceToFaceMeeting")
                        .HasForeignKey("InteractionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewContosoUniversity.Entity.WCCourseMaster", "Course")
                        .WithMany()
                        .HasForeignKey("courseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewContosoUniversity.Entity.WCStaffDetails", "Staff")
                        .WithMany()
                        .HasForeignKey("staffID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCInteraction", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCCommunicationChannelType", "CommunicationChannelType")
                        .WithMany()
                        .HasForeignKey("CommunicationChannelTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewContosoUniversity.Entity.WCContactDetails", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewContosoUniversity.Entity.WCInteractionType", "Interactiontype")
                        .WithMany()
                        .HasForeignKey("InteractiontypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCInterestedCourses", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCCourseMaster", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");

                    b.HasOne("NewContosoUniversity.Entity.WCCourseSchedule", "CourseSchedule")
                        .WithMany()
                        .HasForeignKey("CourseScheduleID");

                    b.HasOne("NewContosoUniversity.Entity.WCInteraction", "Interaction")
                        .WithMany()
                        .HasForeignKey("InteractionID");

                    b.HasOne("NewContosoUniversity.Entity.WCInteraction")
                        .WithMany("InterestedCourses")
                        .HasForeignKey("WCInteractionInteractionID");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCRoleMaster", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCStaffDetails")
                        .WithMany("Roles")
                        .HasForeignKey("WCStaffDetailsStaffID");
                });

            modelBuilder.Entity("NewContosoUniversity.Entity.WCStaffRole", b =>
                {
                    b.HasOne("NewContosoUniversity.Entity.WCRoleMaster", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewContosoUniversity.Entity.WCStaffDetails", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
