using NewContosoUniversity.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCContactDetails : WCIContactDetails
    {
        //private List<WCIPhoneDetails> _ContactPhone;
        private int _contactID;
        private int? _customerID;
        private int? _staffID;
        private string _contactperson;
        private string _relationship;
        private string _phonenumber;
        private string _phoneType;
        private bool _primaryphone;
        private bool _Emergencyphone;
        private string _email;
        private string _linkedInURL;
        private string _websiteurl;
        private WCCustomerDetails _customer;
        private WCStaffDetails _staff;
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactID
        {
            get
            {
                return _contactID;
            }

            set
            {
                _contactID = value;
            }
        }
        [ForeignKey("WCCustomerDetails")]
        public int? CustomerID
        {
            get
            {
                return _customerID;
            }

            set
            {
                _customerID = value;
            }
        }
        [ForeignKey("WCStaffDetails")]
        public int? StaffID
        {
            get
            {
                return _staffID;
            }

            set
            {
                _staffID = value;
            }
        }

        public string ContactPerson
        {
            get
            {
                return _contactperson;
            }

            set
            {
                _contactperson = value;
            }
        }
        public string RelationShip
        {
            get
            {
                return _relationship ;
            }

            set
            {
                _relationship = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phonenumber;
            }

            set
            {
                _phonenumber = value;
            }
        }

        public string PhoneType
        {
            get
            {
                return _phoneType;
            }

            set
            {
                _phoneType = value;
            }
        }

        public bool PrimaryPhone
        {
            get
            {
                return _primaryphone;
            }

            set
            {
                _primaryphone = value;
            }
        }
        public bool EmergencyPhone
        {
            get
            {
                return _Emergencyphone;
            }

            set
            {
                _Emergencyphone = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string LinkedInURL
        {
            get
            {
                return _linkedInURL;
            }

            set
            {
                _linkedInURL = value;
            }
        }
        public string WebsiteURL
        {
            get
            {
                return _websiteurl;
            }

            set
            {
                _websiteurl = value;
            }
        }

        public WCCustomerDetails Customer
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
            }
        }
        public WCStaffDetails Staff
        {
            get
            {
                return _staff;
            }

            set
            {
                _staff = value;
            }
        }
    }
}
