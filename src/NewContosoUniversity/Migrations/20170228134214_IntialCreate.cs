using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewContosoUniversity.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WCCommunicationChannelType",
                columns: table => new
                {
                    CommunicationChannelTypeID = table.Column<int>(nullable: false),
                    CommunicationChannelTypeDesc = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCCommunicationChannelType", x => x.CommunicationChannelTypeID);
                });

            migrationBuilder.CreateTable(
                name: "WCCourseType",
                columns: table => new
                {
                    CourseTypeID = table.Column<int>(nullable: false),
                    CourseTypeDesc = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCCourseType", x => x.CourseTypeID);
                });

            migrationBuilder.CreateTable(
                name: "WCCustomerDetails",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false),
                    AddressTypeID = table.Column<int>(nullable: false),
                    Building = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    DoorNo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LandMark = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    OccupationID = table.Column<int>(nullable: false),
                    Organisation = table.Column<string>(nullable: true),
                    Pincode = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCCustomerDetails", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "WCHolidayCalendar",
                columns: table => new
                {
                    HolidayID = table.Column<int>(nullable: false),
                    HolidayEndDateTime = table.Column<DateTime>(nullable: false),
                    HolidayReason = table.Column<string>(nullable: true),
                    HolidayStartDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCHolidayCalendar", x => x.HolidayID);
                });

            migrationBuilder.CreateTable(
                name: "WCInteractionType",
                columns: table => new
                {
                    InteractionTypeID = table.Column<int>(nullable: false),
                    InteractionTypeDesc = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCInteractionType", x => x.InteractionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "WCStaffDetails",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false),
                    AddressTypeID = table.Column<int>(nullable: false),
                    Building = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    DoorNo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LandMark = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Pincode = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCStaffDetails", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "WCCourseMaster",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false),
                    CourseDescription = table.Column<string>(nullable: true),
                    CourseTitle = table.Column<string>(nullable: true),
                    CourseTypeID = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCCourseMaster", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_WCCourseMaster_WCCourseType_CourseTypeID",
                        column: x => x.CourseTypeID,
                        principalTable: "WCCourseType",
                        principalColumn: "CourseTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WCContactDetails",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmergencyPhone = table.Column<bool>(nullable: false),
                    LinkedInURL = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneType = table.Column<string>(nullable: true),
                    PrimaryPhone = table.Column<bool>(nullable: false),
                    RelationShip = table.Column<string>(nullable: true),
                    StaffID = table.Column<int>(nullable: true),
                    WebsiteURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCContactDetails", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_WCContactDetails_WCCustomerDetails_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "WCCustomerDetails",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WCContactDetails_WCStaffDetails_StaffID",
                        column: x => x.StaffID,
                        principalTable: "WCStaffDetails",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WCRoleMaster",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    RoleDescription = table.Column<string>(nullable: true),
                    WCStaffDetailsStaffID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCRoleMaster", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_WCRoleMaster_WCStaffDetails_WCStaffDetailsStaffID",
                        column: x => x.WCStaffDetailsStaffID,
                        principalTable: "WCStaffDetails",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WCCourseDetails",
                columns: table => new
                {
                    CourseDetailID = table.Column<int>(nullable: false),
                    CourseChapter = table.Column<string>(nullable: true),
                    CourseChapterDescription = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCCourseDetails", x => x.CourseDetailID);
                    table.ForeignKey(
                        name: "FK_WCCourseDetails_WCCourseMaster_CourseID",
                        column: x => x.CourseID,
                        principalTable: "WCCourseMaster",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WCCourseSchedule",
                columns: table => new
                {
                    CourseScheduleID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    CourseScheduleName = table.Column<string>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCCourseSchedule", x => x.CourseScheduleID);
                    table.ForeignKey(
                        name: "FK_WCCourseSchedule_WCCourseMaster_CourseID",
                        column: x => x.CourseID,
                        principalTable: "WCCourseMaster",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WCInteractions",
                columns: table => new
                {
                    InteractionID = table.Column<int>(nullable: false),
                    CallBackEndDate = table.Column<DateTime>(nullable: true),
                    CallBackEndTime = table.Column<DateTime>(nullable: true),
                    CallBackStartDate = table.Column<DateTime>(nullable: true),
                    CallBackStartTime = table.Column<DateTime>(nullable: true),
                    CommunicationChannelTypeID = table.Column<int>(nullable: false),
                    ContactID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    Discussion = table.Column<string>(nullable: true),
                    FaceToFaceMeetingID = table.Column<int>(nullable: true),
                    InteractDateTime = table.Column<DateTime>(nullable: false),
                    InteractiontypeID = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCInteractions", x => x.InteractionID);
                    table.ForeignKey(
                        name: "FK_WCInteractions_WCCommunicationChannelType_CommunicationChannelTypeID",
                        column: x => x.CommunicationChannelTypeID,
                        principalTable: "WCCommunicationChannelType",
                        principalColumn: "CommunicationChannelTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WCInteractions_WCContactDetails_ContactID",
                        column: x => x.ContactID,
                        principalTable: "WCContactDetails",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WCInteractions_WCInteractionType_InteractiontypeID",
                        column: x => x.InteractiontypeID,
                        principalTable: "WCInteractionType",
                        principalColumn: "InteractionTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WCStaffRole",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCStaffRole", x => new { x.StaffID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_WCStaffRole_WCRoleMaster_RoleID",
                        column: x => x.RoleID,
                        principalTable: "WCRoleMaster",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WCStaffRole_WCStaffDetails_StaffID",
                        column: x => x.StaffID,
                        principalTable: "WCStaffDetails",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WCFaceToFaceMeeting",
                columns: table => new
                {
                    FaceToFaceMeetingID = table.Column<int>(nullable: false),
                    AllotedTimeInMinutes = table.Column<int>(nullable: false),
                    CompletedTimeInMinutes = table.Column<int>(nullable: false),
                    FaceToFaceMeetingDateTime = table.Column<DateTime>(nullable: false),
                    InteractionID = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    courseID = table.Column<int>(nullable: false),
                    staffID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCFaceToFaceMeeting", x => x.FaceToFaceMeetingID);
                    table.ForeignKey(
                        name: "FK_WCFaceToFaceMeeting_WCInteractions_InteractionID",
                        column: x => x.InteractionID,
                        principalTable: "WCInteractions",
                        principalColumn: "InteractionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WCFaceToFaceMeeting_WCCourseMaster_courseID",
                        column: x => x.courseID,
                        principalTable: "WCCourseMaster",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WCFaceToFaceMeeting_WCStaffDetails_staffID",
                        column: x => x.staffID,
                        principalTable: "WCStaffDetails",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WCInterestedCourses",
                columns: table => new
                {
                    InteractionID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    CourseScheduleID = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    WCInteractionInteractionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WCInterestedCourses", x => new { x.InteractionID, x.CourseID, x.CourseScheduleID });
                    table.ForeignKey(
                        name: "FK_WCInterestedCourses_WCCourseMaster_CourseID",
                        column: x => x.CourseID,
                        principalTable: "WCCourseMaster",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WCInterestedCourses_WCCourseSchedule_CourseScheduleID",
                        column: x => x.CourseScheduleID,
                        principalTable: "WCCourseSchedule",
                        principalColumn: "CourseScheduleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WCInterestedCourses_WCInteractions_InteractionID",
                        column: x => x.InteractionID,
                        principalTable: "WCInteractions",
                        principalColumn: "InteractionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WCInterestedCourses_WCInteractions_WCInteractionInteractionID",
                        column: x => x.WCInteractionInteractionID,
                        principalTable: "WCInteractions",
                        principalColumn: "InteractionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WCContactDetails_CustomerID",
                table: "WCContactDetails",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_WCContactDetails_StaffID",
                table: "WCContactDetails",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_WCCourseDetails_CourseID",
                table: "WCCourseDetails",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_WCCourseMaster_CourseTypeID",
                table: "WCCourseMaster",
                column: "CourseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_WCCourseSchedule_CourseID",
                table: "WCCourseSchedule",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_WCFaceToFaceMeeting_InteractionID",
                table: "WCFaceToFaceMeeting",
                column: "InteractionID");

            migrationBuilder.CreateIndex(
                name: "IX_WCFaceToFaceMeeting_courseID",
                table: "WCFaceToFaceMeeting",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_WCFaceToFaceMeeting_staffID",
                table: "WCFaceToFaceMeeting",
                column: "staffID");

            migrationBuilder.CreateIndex(
                name: "IX_WCInteractions_CommunicationChannelTypeID",
                table: "WCInteractions",
                column: "CommunicationChannelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_WCInteractions_ContactID",
                table: "WCInteractions",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_WCInteractions_InteractiontypeID",
                table: "WCInteractions",
                column: "InteractiontypeID");

            migrationBuilder.CreateIndex(
                name: "IX_WCInterestedCourses_CourseID",
                table: "WCInterestedCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_WCInterestedCourses_CourseScheduleID",
                table: "WCInterestedCourses",
                column: "CourseScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_WCInterestedCourses_InteractionID",
                table: "WCInterestedCourses",
                column: "InteractionID");

            migrationBuilder.CreateIndex(
                name: "IX_WCInterestedCourses_WCInteractionInteractionID",
                table: "WCInterestedCourses",
                column: "WCInteractionInteractionID");

            migrationBuilder.CreateIndex(
                name: "IX_WCRoleMaster_WCStaffDetailsStaffID",
                table: "WCRoleMaster",
                column: "WCStaffDetailsStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_WCStaffRole_RoleID",
                table: "WCStaffRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_WCStaffRole_StaffID",
                table: "WCStaffRole",
                column: "StaffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WCCourseDetails");

            migrationBuilder.DropTable(
                name: "WCFaceToFaceMeeting");

            migrationBuilder.DropTable(
                name: "WCHolidayCalendar");

            migrationBuilder.DropTable(
                name: "WCInterestedCourses");

            migrationBuilder.DropTable(
                name: "WCStaffRole");

            migrationBuilder.DropTable(
                name: "WCCourseSchedule");

            migrationBuilder.DropTable(
                name: "WCInteractions");

            migrationBuilder.DropTable(
                name: "WCRoleMaster");

            migrationBuilder.DropTable(
                name: "WCCourseMaster");

            migrationBuilder.DropTable(
                name: "WCCommunicationChannelType");

            migrationBuilder.DropTable(
                name: "WCContactDetails");

            migrationBuilder.DropTable(
                name: "WCInteractionType");

            migrationBuilder.DropTable(
                name: "WCCourseType");

            migrationBuilder.DropTable(
                name: "WCCustomerDetails");

            migrationBuilder.DropTable(
                name: "WCStaffDetails");
        }
    }
}
