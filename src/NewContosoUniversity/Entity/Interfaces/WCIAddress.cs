using NewContosoUniversity.Entity.Enums;

namespace NewContosoUniversity.Entity.Interfaces
{
    public interface WCIAddress
    {
        string DoorNo { get; set; }
        string Building { get; set; }
        string Street1 { get; set; }
        string Street2 { get; set; }
        string Locality { get; set; }
        string Pincode { get; set; }
        string City { get; set; }
        string LandMark { get; set; }

        EnumAddressType AddressTypeID { get; set; }

    }
}