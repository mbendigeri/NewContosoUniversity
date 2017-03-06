using Microsoft.AspNetCore.Mvc;
using NewContosoUniversity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewContosoUniversity.Models.CustomerSupport
{
    
    public class ViewModelNewCustomerContact
    {
        private string _contactperson;
        private string _email;
        private string _phonenumber;
        private bool _primaryhone;
        private bool _emergencyhone;
        private string _linkedinurl;
        private string _websiteurl;
        private int _customerID;

        public ViewModelNewCustomerContact(int CustomerID)
        {
            _customerID = CustomerID;
        }
        public ViewModelNewCustomerContact()
        {
            
        }

        [DataType(DataType.Text)]
        [Display(Name = "CustomerID")]
        public int CustomerID
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
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter the Contact person")]
        [MaxLength(150, ErrorMessage = "The contact person must be less than {1} characters.")]
        [Display(Name = "Contact Person Name")]

        
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
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter the email of the contact person")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
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
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter the Phone of the contact person")]
        [Phone(ErrorMessage = "Invalid phone Address")]
        [Display(Name = "PhoneNumber")]
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
        
        [Display(Name = "PrimaryPhone")]
        public Boolean PrimaryPhone
        {
            get
            {
                return _primaryhone;
            }
            set
            {
                _primaryhone = value;
            }
        }
        [Display(Name = "PrimaryPhone")]
        public Boolean EmergencyPhone
        {
            get
            {
                return _emergencyhone;
            }
            set
            {
                _emergencyhone = value;
            }
        }
        [DataType(DataType.Text)]
        [Display(Name = "LinkedInURL")]
        public string LinkedInURL
        {
            get
            {
                return _linkedinurl;
            }
            set
            {
                _linkedinurl = value;
            }
        }
        [DataType(DataType.Text)]
        [Display(Name = "Website")]
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
    }

}
