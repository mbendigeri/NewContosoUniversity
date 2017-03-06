using NewContosoUniversity.Data;
using NewContosoUniversity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace NewContosoUniversity.Services
{
    public class SvcWCInteractions : ISvcWCInteractions
    {
        private NewContosoUniversityDBContext _context;
        public SvcWCInteractions(NewContosoUniversityDBContext context)
        {
            _context = context;
        }
        public async Task<WCInteraction> Add(WCInteraction Interaction)
        {
            _context.Add(Interaction);
            await _context.SaveChangesAsync();
            return Interaction;
        }

        public async Task<WCFaceToFaceMeeting> Add(WCFaceToFaceMeeting F2FaceMeeting)
        {
            _context.Add(F2FaceMeeting);
            await _context.SaveChangesAsync();
            return F2FaceMeeting;
        }

        public async Task<IEnumerable<WCInteraction>> GetAll()
        {
            return await _context.WCInteractions.ToListAsync();
        }

        public async Task<WCInteraction> GetInteractionDetails(int interactionID)
        {
            var Interactions = from WCInt in _context.WCInteractions
                               select WCInt;
            WCInteraction Interact = null;

            if (interactionID > 0)
            {
                Interact = await Interactions.SingleOrDefaultAsync(WCInt => WCInt.InteractionID == interactionID);
            }
            return Interact;
        }

        public async Task<WCInteraction> FindLatestInteraction(int CustomerID)
        {

            var Interactions = from WCInt in _context.WCInteractions
                               select WCInt;
            WCInteraction Interact = null;

            if (CustomerID > 0)
            {
                
                Interact = await Interactions
                                .Where(WCInt => WCInt.CustomerID == CustomerID)
                                .OrderByDescending(WCInt => WCInt.InteractDateTime)
                                .FirstOrDefaultAsync();

                if (Interact != null)
                {
                    if (Interact.CommunicationChannelTypeID > 0)
                    {
                        Interact.CommunicationChannelType = await FindCommunicationChannelByID(Interact.CommunicationChannelTypeID);
                    }
                    if (Interact.ContactID > 0)
                    {
                        Interact.Contact = await FindContactByID(Interact.ContactID);
                    }
                }
            }
            return  Interact;
            
        }
        private async Task<WCContactDetails> FindContactByID(int ContactID)
        {
            var Contacts = from WCContact in _context.WCContactDetails
                                        select WCContact;

            WCContactDetails Contact = null;
            if (ContactID > 0)
            {

                Contact = await Contacts
                                .Where(WCContact => WCContact.ContactID == ContactID)
                                .FirstOrDefaultAsync();


            }
            return Contact;

        }
        private async Task<WCCommunicationChannelType> FindCommunicationChannelByID(int ChannelByID)
        {
            var CommunicationChannels = from WCComChannel in _context.WCCommunicationChannelType
                               select WCComChannel;

            WCCommunicationChannelType CommChannel = null;
            if (ChannelByID > 0)
            {

                CommChannel = await CommunicationChannels
                                .Where(WCComChannel => WCComChannel.CommunicationChannelTypeID == ChannelByID)                           
                                .FirstOrDefaultAsync();
                

            }
            return CommChannel;

        }
        public async Task<IEnumerable<WCInteraction>> FindInteractionsByCustomerID(int CustomerID)
        {
            var Interactions = from WCInt in _context.WCInteractions
                               select WCInt;
            List<WCInteraction> Interact = null;

            if (CustomerID > 0)
            {
                Interact = await Interactions.Where(WCInt => WCInt.CustomerID == CustomerID).ToListAsync();
                //Interact = Interactions.Where(WCInt => WCInt.CustomerID == CustomerID).ToListAsync();
            }
            return Interact;
            //return _context.WCCustomerDetails.Where(cust => (cust.FirstName == firstName || cust.LastName == lastname));
        }
       

    }
}
