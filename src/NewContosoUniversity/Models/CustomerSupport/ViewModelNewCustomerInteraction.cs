using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewContosoUniversity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewContosoUniversity.Models.CustomerSupport
{
    public class CourseSelection:WCCourseMaster
    {
        public bool Selected { get; set; }

    }
    
    public class ViewModelNewCustomerInteraction
    {
       
        /// <summary>
        /// Master data
        /// </summary>
        private List<CourseSelection> availablecourses;
        private IEnumerable<WCInterestedCourses> interestedcourses;
        private IEnumerable<WCInteraction> interactions;
        //private IEnumerable<WCCommunicationChannelType> communicationchannels;
        private IEnumerable<WCCommunicationChannelType> availablecommunicationchannels;
        private List<SelectListItem> availabletutors;

        /// <summary>
        /// Customer details
        /// </summary>
        private WCCustomerDetails customer;
        private WCContactDetails contact;
        private WCFaceToFaceMeeting f2fMeeting;
        
        private string _discussion;
        private int _interactiontypeid;
        private DateTime _callbackstartdate;
        private DateTime _callbackstarttime;
        private DateTime _callbackEnddate;
        private DateTime _callbackEndtime;
        
        private int _communicationchannel;
        private int _totalRows;
        private string selectedstaffid;

        public ViewModelNewCustomerInteraction(int customerID)
        {
           /*
           PopulateCustomer(customerID);
           PopulateAvailableCourses();
           PopulateCommunicationChannels();
           */

        }
        public ViewModelNewCustomerInteraction()
        {
            // PopulateCustomer(customerID);
            //  PopulateAvailableCourses();
            // PopulateCommunicationChannels();

        }
        public string SelectedStaffID
        {
            get { return selectedstaffid; }
            set { selectedstaffid = value; }
        }
        //public IEnumerable<WCCourseMaster> AvailableCourses
        public List<CourseSelection> AvailableCourses
        {
            
            get { return availablecourses; }
            set { availablecourses = value; }
        }
        
        public int TotalRows
        {
            get { return _totalRows; }
            set { _totalRows = value; }
        }
        public IEnumerable<WCCommunicationChannelType> AvailableCommunicationChannels
        {
            get { return availablecommunicationchannels; }
            set { availablecommunicationchannels = value; }
        }
        //public IEnumerable<WCStaffDetails> AvailableTutors

        
        public List<SelectListItem> AvailableTutors
        {
            get { return availabletutors; }
            set { availabletutors = value; }
        }
        public WCCustomerDetails Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        public WCContactDetails Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        public WCFaceToFaceMeeting F2FMeeting
        {
            get { return f2fMeeting; }
            set {  f2fMeeting= value; }
        }


        public IEnumerable<WCInterestedCourses> InterestedCourses
        {
            get { return interestedcourses; }
            set { interestedcourses = value; }
        }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select an Interaction Type")]
        [Display(Name = "Interaction Type")]
        public int CommunicationChannelTypeID
        {
            get
            {
                return _communicationchannel;
            }
            set
            {
                _communicationchannel = value;
            }
        }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select an Interaction Type")]
        [Display(Name = "Interaction Type")]
        public int InteractiontypeID
        {
            get
            {
                return _interactiontypeid;
            }
            set
            {
                _interactiontypeid = value;
            }
        }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter the discussion")]
        [Display(Name = "Discussion")]
        public string Discussion
        {
            get
            {
                return _discussion;
            }
            set
            {
                _discussion = value;
            }
        }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select an Start Date for Call back")]
        [Display(Name = "Call Start Date ")]
        public DateTime CallBackStartDate
        {
            get
            {
                return _callbackstartdate;
            }
            set
            {
                _callbackstartdate = value;
            }
        }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select an Start time for Call back")]
        [Display(Name = "Call Start time")]
        public DateTime CallBackStartTime
        {
            get
            {
                return _callbackstarttime;
            }
            set
            {
                _callbackstarttime = value;
            }
        }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select an End Date for Call back")]
        [Display(Name = "Call Start Date ")]
        public DateTime CallBackEndDate
        {
            get
            {
                return _callbackEnddate;
            }
            set
            {
                _callbackstartdate = value;
            }
        }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select an End time for Call back")]
        [Display(Name = "Call Start time")]
        public DateTime CallBackEndTime
        {
            get
            {
                return _callbackEndtime;
            }
            set
            {
                _callbackEndtime = value;
            }
        }
        
        /*
        private void PopulateCustomer(int customerID)
        {

            //Query the table WCCustomerDetails and get all or top 10 interactions for the given Customer ID
            //Build the customer  object
            
        }
        private void PopulateAvailableCourses()
        {

            //Query the table WCCourseMaster and get all available courses
            
            throw new NotImplementedException();
        }

        private void PopulateCommunicationChannels()
        {
            //Query the table Communication Channel Channel and get all or top 10 interactions for the given Customer ID
            //Build the Communication Channel Channel list object

            throw new NotImplementedException();
        }
        */
    }

}
