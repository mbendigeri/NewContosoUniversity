namespace NewContosoUniversity.Entity.Interfaces
{
    public interface WCIContactDetails
    {
        int ContactID { get; set; }
        int? CustomerID { get; set; }
        int? StaffID { get; set; }
        string ContactPerson { get; set; }
        string RelationShip { get; set; }
        string PhoneNumber { get; set; }
        bool PrimaryPhone { get; set; }
        bool EmergencyPhone { get; set; }
        string PhoneType { get; set; }
        string Email { get; set; }
        string LinkedInURL { get; set; }
        string WebsiteURL { get; set; }
        //List<WCIPhoneDetails> ListContactPhone { get; set; }
    }
}
