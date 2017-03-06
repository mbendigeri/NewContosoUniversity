using NewContosoUniversity.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewContosoUniversity.Models.CustomerSupport
{
    public class ViewModelNewCustomer
    {
        private string _firstName;
        private string _lastName;
        private string _middlename;
        private EnumOccupation _occupationID;
        private string _organisation;
        private string _doorno;
        private string _building;
        private string _street1;
        private string _street2;
        private string _locality;
        private string _pincode;
        private string _city;
        private string _landmark;
        private EnumAddressType _addressTypeID;

        [DataType(DataType.Text)]
        [Required (ErrorMessage ="Please Enter the Customer's FirstName")]
        [MaxLength(150,ErrorMessage = "The First Name must be less than {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter the Customer's MiddleName")]
        [MaxLength(150, ErrorMessage = "The Middle Name must be less than {1} characters.")]
        public string MiddleName
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
            }
        }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter the Customer's Last Name")]
        [MaxLength(150, ErrorMessage = "The Last Name must be less than {1} characters.")]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
       
        [Required]
        [Display(Name = "Occupation")]
        public EnumOccupation OccupationID
        {
            get
            {
                return _occupationID;
            }
            set
            {
                _occupationID = value;
            }
        }
       
        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "Organisation")]
        public string Organisation
        {
            get
            {
                return _organisation;
            }

            set
            {
                _organisation = value;
            }
        }
        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "Door No")]
        public string DoorNo
        {
            get
            {
                return _doorno;
            }

            set
            {
                _doorno = value;
            }
        }

        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "Building")]
        public string Building
        {
            get
            {
                return _building;
            }

            set
            {
                _building = value;
            }
        }


        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "Street1")]
        public string Street1
        {
            get
            {
                return _street1;
            }

            set
            {
                _street1 = value;
            }
        }

        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "Street2")]
        public string Street2
        {
            get
            {
                return _street2;
            }

            set
            {
                _street2 = value;
            }
        }

        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "Locality")]
        public string Locality
        {
            get
            {
                return _locality;
            }

            set
            {
                _locality = value;
            }
        }

        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "Pincode")]
        public string Pincode
        {
            get
            {
                return _pincode;
            }

            set
            {
                _pincode = value;
            }
        }

        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "City")]
        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }

        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "LandMark")]
        public string LandMark
        {
            get
            {
                return _landmark;
            }

            set
            {
                _landmark = value;
            }
        }

        
        [Required]
        [Display(Name = "AddressType")]
        public EnumAddressType AddressType
        {
            get
            {
                return _addressTypeID;
            }

            set
            {
                _addressTypeID = value;
            }
        }
    }
}
