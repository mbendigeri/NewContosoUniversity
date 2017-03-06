using NewContosoUniversity.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewContosoUniversity.Models.CustomerSupport
{
    public class ReduntantViewModelCustomerDetails
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string Middle;
        public readonly EnumOccupation Occupation;
        public readonly string RelationShip;
        public readonly string ContactPerson;
        public readonly string Organisation;
        public readonly string DoorNo;
        public readonly string Building;
        public readonly string Street1;
        public readonly string Street2;
        public readonly string Locality;
        public readonly string PinCode;
        public readonly string City;
        public readonly string LandMark;
        public EnumAddressType AddressType;
    }
}
