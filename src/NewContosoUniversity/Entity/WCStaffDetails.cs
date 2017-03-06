using System.Collections.Generic;
using NewContosoUniversity.Entity.Interfaces;
using NewContosoUniversity.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCStaffDetails : WCIPersonalInfo, WCIAddress
    {
        
        
        private string _firstname;
        private string _middlename;
        private string _lastname;
        private string _street1;
        private string _street2;
        private EnumAddressType _addressTypeID;
        private string _landmark;
        private string _city;
        private string _pincode;
        private string _locality;
        private ICollection<WCStaffRole> _lstStaffroles;
        private ICollection<WCContactDetails> _lstcontactinfo;
        private string _doorno;
        private string _building;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StaffID { get; set; }
       
        public string FirstName
        {
            get
            {
                return _firstname;
            }

            set
            {
                _firstname = value;
            }
        }
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
        public string LastName
        {
            get
            {
                return _lastname;
            }

            set
            {
                _lastname = value;
            }
        }

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
       
       
        public EnumAddressType AddressTypeID
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
        public ICollection<WCContactDetails> ContactDetails
        {
            get
            {
                return _lstcontactinfo;
            }
            set
            {
                _lstcontactinfo = value;
            }
        }
        public ICollection<WCStaffRole> StaffRoles {
            get
            {
                return _lstStaffroles;
            }
            set
            {
                _lstStaffroles = value;
            }
        }

    }
}
