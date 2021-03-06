using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewContosoUniversity.Models.CustomerSupport;
using NewContosoUniversity.Entity;
using NewContosoUniversity.Services;
using NewContosoUniversity.Entity.Enums;
using NewContosoUniversity.Entity.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Newtonsoft.Json;

namespace NewContosoUniversity.Controllers
{
    public class CustomerSupportController : Controller
    {
        //private readonly NewContosoUniversityDBContext _context;

        private ISvcWCCustomerDetails _customerdetails;
        private ISvcWCInteractions _interactions;
        private ISvcWCMasterData _masterData;
        

        public CustomerSupportController(ISvcWCCustomerDetails CustomerDetails, ISvcWCInteractions Interactions, ISvcWCMasterData MasterData)
        {
            _customerdetails = CustomerDetails;
            _interactions = Interactions;
            _masterData = MasterData;
        }

        #region New Customer Contact
        [HttpGet]
        public IActionResult NewCustomerContact([FromQuery]int CustomerID)
        {
            var model = new ViewModelNewCustomerContact(CustomerID);
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCustomerContact(ViewModelNewCustomerContact model)
        {
            if (ModelState.IsValid)
            {
                WCContactDetails NewContact = new WCContactDetails();
                NewContact.ContactPerson = model.ContactPerson;
                NewContact.CustomerID = model.CustomerID;
                NewContact.Email = model.Email;
                NewContact.PhoneNumber = model.PhoneNumber;
                NewContact.PrimaryPhone = model.PrimaryPhone;
                NewContact.EmergencyPhone = model.EmergencyPhone;
                NewContact.WebsiteURL = model.WebsiteURL;
                NewContact.LinkedInURL = model.LinkedInURL;
                await _customerdetails.Add(NewContact);

            }
            return View(model);

        }
        #endregion
        
        #region New Customer
        [HttpGet]
        public IActionResult NewCustomer()
        {
            var model = new ViewModelNewCustomer();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> NewCustomer(ViewModelNewCustomer model)
         {
            if (ModelState.IsValid)
            {
                WCCustomerDetails NewCustomer = new WCCustomerDetails();
                NewCustomer.FirstName = model.FirstName;
                NewCustomer.LastName = model.LastName;
                NewCustomer.MiddleName = model.MiddleName;
                NewCustomer.OccupationID = model.OccupationID;
                NewCustomer.Organisation = model.Organisation;
                NewCustomer.DoorNo = model.DoorNo;
                NewCustomer.Building = model.Building;
                NewCustomer.LandMark = model.LandMark;
                NewCustomer.Street1 = model.Street1;
                NewCustomer.Street2 = model.Street2;
                NewCustomer.Locality = model.Locality;
                NewCustomer.City = model.City;
                NewCustomer.Pincode = model.Pincode;
                NewCustomer.AddressTypeID = model.AddressType;
                await _customerdetails.Add(NewCustomer);
                
            }
            return View(model);
         }
        [HttpGet]
        public IActionResult SearchCustomer()
        {
            var model = new ViewModelSearchCustomer();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchCustomer(ViewModelSearchCustomer model)
        {
            IEnumerable<WCCustomerDetails> customers = null;
            List<ViewModelSearchCustomerResults> SearchResultsmodel = null;
            if (ModelState.IsValid)
            {

                if (model.FirstName.Length > 0)
                {
                    customers = await _customerdetails.SearchCustomers(EnumCustomerSortOrder.FirstName, model.FirstName);
                }
                if (model.LastName.Length > 0)
                {

                    customers = await _customerdetails.SearchCustomers(EnumCustomerSortOrder.LastName, model.LastName);
                }
                //SearchResultsmodel = await BuildSearchResults(customers);
                SearchResultsmodel = await BuildSearchResults(customers);
            }
            model.SearchResults = SearchResultsmodel;
            return View(model);
        }
        private async Task<List<ViewModelSearchCustomerResults>> BuildSearchResults(IEnumerable<WCCustomerDetails> customers)
        {
            List<ViewModelSearchCustomerResults> SearchResultsmodel = new List<ViewModelSearchCustomerResults>();


            foreach (WCCustomerDetails customer in customers)
            {
                ViewModelSearchCustomerResults searchResult = new ViewModelSearchCustomerResults();
                searchResult.FirstName = customer.FirstName;
                searchResult.LastName = customer.LastName;

                WCInteraction LatestInteraction = await _interactions.FindLatestInteraction(customer.CustomerID);
                if (LatestInteraction != null)
                {
                    searchResult.LastInteractionDate = LatestInteraction.InteractDateTime;
                    WCCommunicationChannelType CommunicationChannel = LatestInteraction.CommunicationChannelType;
                    searchResult.CommunicationChannel = CommunicationChannel.CommunicationChannelTypeDesc;
                    WCIContactDetails ContactDetails = LatestInteraction.Contact;
                    searchResult.ContactPerson = ContactDetails.ContactPerson;
                    searchResult.RelationShip = ContactDetails.RelationShip;
                }

               
                SearchResultsmodel.Add(searchResult);

            }
            return SearchResultsmodel;
        }
        #endregion

        #region Interactions page loading
        [HttpGet]
        public async Task<IActionResult> NewCustomerInteraction(int CustomerID)
        {
            
            var model = new ViewModelNewCustomerInteraction(CustomerID);
            WCCustomerDetails Cust = await _customerdetails.GetCustomerDetails(CustomerID);
            if (Cust != null)
            {
                model.Customer = Cust;
            }
            IEnumerable<WCCommunicationChannelType> WCC = await _masterData.GetAllCommunicationTypes();
            if (WCC != null)
            {
               
                List<SelectListItem> ListCommunicationChannelType = new List<SelectListItem>();
                foreach (WCCommunicationChannelType WC in WCC)
                {
                    SelectListItem CommunicationChannelType = new SelectListItem();

                    CommunicationChannelType.Text = WC.CommunicationChannelTypeDesc;
                    CommunicationChannelType.Value = WC.CommunicationChannelTypeID.ToString();
                    ListCommunicationChannelType.Add(CommunicationChannelType);
                }
                model.AvailableCommunicationChannels = ListCommunicationChannelType;
            }

            IEnumerable<WCInteractionType> WCCInteractionTypes = await _masterData.GetAllInteractionTypes();
            if (WCCInteractionTypes != null)
            {

                List<SelectListItem> ListInteractionType = new List<SelectListItem>();
                foreach (WCInteractionType WC in WCCInteractionTypes)
                {
                    SelectListItem InteractionType = new SelectListItem();

                    InteractionType.Text = WC.InteractionTypeDesc;
                    InteractionType.Value = WC.InteractionTypeID.ToString();
                    ListInteractionType.Add(InteractionType);
                }
                model.AvailableInteractionTypes = ListInteractionType;
            }
            
            

            IEnumerable<WCInterestedCourses> InterestedCourses = await _interactions.GetLastInterestedCourses(CustomerID);
            if (WCC != null)
            {
                model.InterestedCourses = InterestedCourses;
            }
 
            IEnumerable<WCCourseMaster> CourseMasterCollection = await _masterData.GetAllCourses();
            if (CourseMasterCollection != null && CourseMasterCollection.Count()>0)
            {
                List<CourseSelection> LstAvailableCourses = new List<CourseSelection>();
                List<SelectListItem> SelectAvailableCourses = new List<SelectListItem>();

                foreach (WCCourseMaster item in CourseMasterCollection)
                {
                    CourseSelection NewCourse = new CourseSelection();
                    NewCourse.CourseDescription = item.CourseDescription;
                    NewCourse.CourseID = item.CourseID;
                    NewCourse.CourseDescription = item.CourseDescription;
                    NewCourse.CourseDetails = item.CourseDetails;
                    NewCourse.CourseSchedule = item.CourseSchedule;
                    NewCourse.CourseTitle = item.CourseTitle;
                    NewCourse.CourseType = item.CourseType;
                    NewCourse.CourseTypeID = item.CourseTypeID;
                    NewCourse.Duration = item.Duration;
                    if (InterestedCourses!=null && InterestedCourses.Count()>0)
                    {
                        if (InterestedCourses.Where(WC => WC.CourseID == NewCourse.CourseID) != null)
                            NewCourse.Selected = true;
                        else
                            NewCourse.Selected = false;
                    }
                    LstAvailableCourses.Add(NewCourse);

                    SelectListItem SelectAvailableCourse = new SelectListItem();

                    SelectAvailableCourse.Text = item.CourseTitle;
                    SelectAvailableCourse.Value = item.CourseID.ToString();
                    SelectAvailableCourses.Add(SelectAvailableCourse);

                }
                model.SelectAvailableCourses = SelectAvailableCourses;
                model.AvailableCourses = LstAvailableCourses;

               /* int total = LstAvailableCourses.Count();
                if (total > 4)
                {
                    model.TotalRows = LstAvailableCourses.Count();
                }
                else {
                    model.TotalRows = 1;
                }*/
            }

            WCContactDetails Contact = Cust.ContactDetails.FirstOrDefault(WC => (WC.RelationShip == "Self"));
            model.Contact = Contact;

            IEnumerable<WCStaffDetails> AvailStaff = await _masterData.GetAllTutorStaff("Chef");
            if (AvailStaff != null && AvailStaff.Count() > 0)
            {
                
                List<SelectListItem> StaffList = new List<SelectListItem>();
                foreach (WCStaffDetails WC in AvailStaff)
                {
                    SelectListItem staff = new SelectListItem();
                    //var name = WC.StaffRoles.FirstOrDefault().Role.RoleDescription;
                    //name = WC.StaffRoles.FirstOrDefault().Staff.LastName;
                    staff.Text = WC.FirstName + "," + WC.LastName;
                    staff.Value = WC.StaffID.ToString();
                    StaffList.Add(staff);
                }
                  model.AvailableTutors = StaffList;
               
            }
            
            return View(model);

        }

        #endregion
        
        #region Interaction Page submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCustomerInteraction(ViewModelNewCustomerInteraction model)
        {
            if (ModelState.IsValid)
            {
               // WCContactDetails NewContact = model.Contact;
               // NewContact = await _customerdetails.Add(NewContact);

                

                WCInteraction NewInteraction = new WCInteraction();
                NewInteraction.CustomerID = model.Customer.CustomerID;
                NewInteraction.CallBackStartDate = model.CallBackStartDate;
                NewInteraction.CallBackStartTime = model.CallBackStartTime;
                NewInteraction.CallBackEndDate = model.CallBackEndDate;
                NewInteraction.CallBackEndTime = model.CallBackEndTime;
                NewInteraction.CommunicationChannelTypeID = model.CommunicationChannelTypeID;
                NewInteraction.InteractiontypeID = model.InteractiontypeID;
                NewInteraction.ContactID = model.Contact.ContactID;
                NewInteraction.Discussion = model.Discussion;
                //NewInteraction.FaceToFaceMeetingID = NewF2FMeeting.FaceToFaceMeetingID;
                NewInteraction.InteractDateTime = System.DateTime.Now;
                NewInteraction= await _interactions.Add(NewInteraction);

                //WCInterestedCourses WCInterestedCourses=
                
              

                WCFaceToFaceMeeting NewF2FMeeting = model.F2FMeeting;
                NewF2FMeeting.AllotedTimeInMinutes=30;
                NewF2FMeeting.CourseID = model.F2FMeeting.CourseID;
                NewF2FMeeting.StaffID = model.F2FMeeting.StaffID;
                NewF2FMeeting.InteractionID = NewInteraction.InteractionID;
                NewF2FMeeting = await _interactions.Add(NewF2FMeeting);

                foreach (CourseSelection item in model.AvailableCourses)
                {
                    if (item.Selected)
                    {
                        WCInterestedCourses interestedCourse = new WCInterestedCourses();
                        interestedCourse.CourseID = item.CourseID;
                        interestedCourse.InteractionID = NewInteraction.InteractionID;
                        interestedCourse= await _interactions.Add(interestedCourse);
                        
                    }
                }

            }
            return View(model);

        }

        [HttpGet]
        public async Task<JsonResult> GetF2FMeetings(int staffID)
        {
            IEnumerable<WCFaceToFaceMeeting> obj = await _masterData.GetAllAvailableF2FMeeting(staffID);
            JsonResult oj;
            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.MaxDepth = 10;
            //oj = new JsonResult(obj, settings);
            oj = new JsonResult(obj);
            return oj;

            //return new JsonResult(await _masterData.GetAllAvailableF2FMeeting(staffID));
        }
        #endregion
    }
    
}