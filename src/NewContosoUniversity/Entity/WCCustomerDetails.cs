using NewContosoUniversity.Entity.Enums;
using NewContosoUniversity.Entity.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NewContosoUniversity.Entity
{

    public class WCCustomerDetails : WCIPersonalInfo, WCIAddress
    {

        //private List<WCIContactDetails> _lstcontactinfo;
        private int _customerID;
        private string _firstname;
        private string _middlename;
        private string _lastname;
        private EnumOccupation _occupationID;
        private string _organisation;
        private string _street1;
        private string _street2;
        private EnumAddressType _addressTypeID;
        private string _landmark;
        private string _city;
        private string _pincode;
        private string _locality;
        private string _doorno;
        private string _building;
        private List<WCContactDetails> _lstcontactinfo;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID {
            get
            {
                return _customerID;
            }

            set
            {
                _customerID = value;
            }
        }
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
                _street2=value;
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
                _locality=value;
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

        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city=value;
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
        public List<WCContactDetails> ContactDetails
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

    }
}
