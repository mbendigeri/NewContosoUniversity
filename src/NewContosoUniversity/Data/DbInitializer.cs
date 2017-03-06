using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NewContosoUniversity.Data;
using NewContosoUniversity.Entity;
using NewContosoUniversity.Entity.Enums;

namespace NewContosoUniversity.Entity
{
    public static class DbInitializer
    {
        
        public static void Initialize(NewContosoUniversityDBContext context)
        {
            context.Database.EnsureCreated();
            DataWCRole(context);
            DataWCCommunicationChannelType(context);
            DataWCCourseType(context);
            DataWCCourseMaster(context);
            DataWCCustomerDetails(context);
            DataWCContactDetails(context);
            DataWCStaff(context);


        }
        private static void DataWCRole(NewContosoUniversityDBContext context)
        {

            // Look for any WCCustomerDetailss.
            if (context.WCRoleMaster.Any())
            {
                return;   // DB has been seeded
            }
            WCRoleMaster[] Roles = new WCRoleMaster[]
            {
            new WCRoleMaster {RoleID=1,RoleDescription="Chef" },
            new WCRoleMaster {RoleID=2,RoleDescription="Chef Assisit" },

            };
            foreach (WCRoleMaster c in Roles)
            {
                context.WCRoleMaster.Add(c);
            }
            context.SaveChanges();
        }
      
        private static void DataWCCommunicationChannelType(NewContosoUniversityDBContext context)
        {

            // Look for any WCCustomerDetailss.
            if (context.WCCommunicationChannelType.Any())
            {
                return;   // DB has been seeded
            }
            WCCommunicationChannelType[] CommunicationChannelTypes = new WCCommunicationChannelType[]
            {
            new WCCommunicationChannelType {CommunicationChannelTypeID=1,CommunicationChannelTypeDesc="Phone" },
            new WCCommunicationChannelType {CommunicationChannelTypeID=2,CommunicationChannelTypeDesc="Email" },
            new WCCommunicationChannelType {CommunicationChannelTypeID=3,CommunicationChannelTypeDesc="WhatsApp" },

            };
            foreach (WCCommunicationChannelType c in CommunicationChannelTypes)
            {
                context.WCCommunicationChannelType.Add(c);
            }
            context.SaveChanges();
        }
        private static void DataWCCourseType(NewContosoUniversityDBContext context)
        {

            // Look for any WCCustomerDetailss.
            if (context.WCCourseType.Any())
            {
                return;   // DB has been seeded
            }
            WCCourseType[] CourseTypes = new WCCourseType[]
            {
            new WCCourseType{CourseTypeID=1,CourseTypeDesc="Classic" },
            new WCCourseType{CourseTypeID=2,CourseTypeDesc="Excellence" },
            new WCCourseType{CourseTypeID=3,CourseTypeDesc="Weekend Rush" }

            };
            foreach (WCCourseType c in CourseTypes)
            {
                context.WCCourseType.Add(c);
            }
            context.SaveChanges();
        }
        private static void DataWCCourseMaster(NewContosoUniversityDBContext context)
        {

            // Look for any WCCustomerDetailss.
            if (context.WCCourseMaster.Any())
            {
                return;   // DB has been seeded
            }
            WCCourseMaster[] Courses = new WCCourseMaster[]
            {
            new WCCourseMaster{CourseID=1,CourseTitle="THE CHOCOLATE LAB",
                CourseDescription ="In this course you will be introduced to chocolate tempering and chocolate garnishes, colour casting, ganache, molded and hand dipped chocolates.",
            CourseTypeID=1,Duration=12},
            new WCCourseMaster{CourseID=2,CourseTitle="THE CHEESE CAKE",
                CourseDescription ="Say Cheese! and bake delectable cheese cake in whitecaps.Baked raspberry cheese cake, Japanese style cheese cake, Philadelphia style caramel cheese cake.",
            CourseTypeID=1,Duration=12},
            new WCCourseMaster{CourseID=3,CourseTitle="POUND CAKE AND TARTS",
                CourseDescription ="Let’s bake together! Learn different techniques of basic pound cake, carrot cake and banana walnut without losing focus on the creamy, nutty and crunchy delectable tart.",
            CourseTypeID=1,Duration=12},

            };
            foreach (WCCourseMaster c in Courses)
            {
                context.WCCourseMaster.Add(c);
            }
            context.SaveChanges();
        }
        private static void DataWCCustomerDetails(NewContosoUniversityDBContext context)
        {
            // Look for any WCCustomerDetailss.
            if (context.WCCustomerDetails.Any())
            {
                return;   // DB has been seeded
            }

            WCCustomerDetails[] Customers = new WCCustomerDetails[]
            {
            new WCCustomerDetails
            {CustomerID=1,
                FirstName ="Mallikarjun",
                MiddleName ="S",
                LastName ="Bendigeri",
                Organisation ="HP",
                OccupationID =EnumOccupation.Working,
                DoorNo="APt-103",
                Building="Archita-3",
                Street1 ="18th Cross",
                Street2 ="Ideal Homes Layout",
                Locality ="RRNagar",
                LandMark ="Bescom",
                City ="Bangalore",
                Pincode ="560098",
                AddressTypeID =EnumAddressType.Residence,
            },
            new WCCustomerDetails{CustomerID=2,
                FirstName ="Sagar",
                MiddleName ="G",
                LastName ="Dharapur",
                Organisation ="Robert Bosch",
                OccupationID =EnumOccupation.Working,
                DoorNo="APt-502",
                Building="Archita Daffodil",
                Street1 ="17 Cross",
                Street2 =" Ideal Homes Layout",
                Locality ="RRNagar",
                LandMark ="Bescom",
                City ="Bangalore",
                Pincode ="560098",
                AddressTypeID =EnumAddressType.Residence,},

            };
            foreach (WCCustomerDetails C in Customers)
            {
                context.WCCustomerDetails.Add(C);
            }
            context.SaveChanges();

        }
        private static void DataWCContactDetails(NewContosoUniversityDBContext context)
        {

            // Look for any WCCustomerDetailss.
            if (context.WCContactDetails.Any())
            {
                return;   // DB has been seeded
            }
            WCContactDetails[] Contacts = new WCContactDetails[]
            {
            new WCContactDetails{ContactID=1,ContactPerson="Mallikarjun",CustomerID=1,Email="mbendigeri@gmail.com",
                PhoneNumber ="9845593009",PhoneType="Mobile",PrimaryPhone=true,EmergencyPhone=false,
                RelationShip ="Self",LinkedInURL="WWW.LinkedIn.com/MallikarjunBendigeri",WebsiteURL="WWW.Bendigeri.com"},

            new WCContactDetails{ContactID=2,ContactPerson="Sheela",CustomerID=1,Email="Sheela.bendigeri@gmail.com",
                PhoneNumber ="9945603135",PhoneType="Mobile",PrimaryPhone=false,EmergencyPhone=false,
                RelationShip ="Wife",LinkedInURL="WWW.LinkedIn.com/SheelaBendigeri",WebsiteURL="WWW.SheelaBendigeri.com"},
             new WCContactDetails{ContactID=3,ContactPerson="Sharnabasappa",CustomerID=1,Email="sharabendigei@gmail.com",
                PhoneNumber ="9823423801",PhoneType="Mobile",PrimaryPhone=false,EmergencyPhone=false,
                RelationShip ="father"},

              new WCContactDetails{ContactID=4,ContactPerson="Rudresh",CustomerID=2,Email="Rudresh@gmail.com",
                PhoneNumber ="9234398234",PhoneType="Mobile",PrimaryPhone=true,EmergencyPhone=false,
                RelationShip ="Self",LinkedInURL="WWW.LinkedIn.com/Rudresh",WebsiteURL="WWW.SagarDharpur.com"},

            new WCContactDetails{ContactID=5,ContactPerson="Vishwanath",CustomerID=2,Email="Vishwanath@gmail.com",
                PhoneNumber ="7823423434",PhoneType="Mobile",PrimaryPhone=false,EmergencyPhone=false,
                RelationShip ="Father",LinkedInURL="WWW.LinkedIn.com/Vishwanath",WebsiteURL="WWW.SagarDharpur.com"},

             new WCContactDetails{ContactID=6,ContactPerson="Arvind",CustomerID=1,Email="ArvindMekin@gmail.com",
                PhoneNumber ="9823423801",PhoneType="Mobile",PrimaryPhone=false,EmergencyPhone=false,
                RelationShip ="Friend",LinkedInURL="WWW.LinkedIn.com/Arvind",WebsiteURL="WWW.Arvind.com"},

            };
            foreach (WCContactDetails c in Contacts)
            {
                context.WCContactDetails.Add(c);
            }
            context.SaveChanges();
        }

        private static void DataWCStaff(NewContosoUniversityDBContext context)
        {

            // Look for any WCCustomerDetailss.
            if (context.WCStaffDetails.Any())
            {
                return;   // DB has been seeded
            }
            WCStaffDetails[] Staff = new WCStaffDetails[]
            {
            new WCStaffDetails {
                StaffID=1,
                FirstName ="Rajesh",
                MiddleName ="S",
                LastName ="Jagaadeesan",
                DoorNo="Apt-203",
                Building="Deccan Enclave",
                Street1 ="17th Cross",
                Street2 ="BEML 5th Stage",
                Locality ="RRNagar",
                LandMark ="Patnager Bus Stop",
                City ="Bangalore",
                Pincode ="560098",
                AddressTypeID =EnumAddressType.Residence,
                },

            };
            foreach (WCStaffDetails c in Staff)
            {
                context.WCStaffDetails.Add(c);
            }
            context.SaveChanges();
        }
    }
}