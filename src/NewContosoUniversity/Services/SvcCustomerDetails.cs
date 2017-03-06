using NewContosoUniversity.Data;
using NewContosoUniversity.Entity;
using NewContosoUniversity.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace NewContosoUniversity.Services
{
    public class SvcCustomerDetails : ISvcWCCustomerDetails
    {
        private NewContosoUniversityDBContext _context;
        public SvcCustomerDetails(NewContosoUniversityDBContext context)
        {
            _context = context;
        }
        public async Task<WCCustomerDetails> Add(WCCustomerDetails customerDetails)
        {
            customerDetails.CustomerID = _context.WCCustomerDetails.Max(WCC => WCC.CustomerID)+1;
            _context.Add(customerDetails);
            await _context.SaveChangesAsync();
            return customerDetails;
        }
        public async Task<WCContactDetails> Add(WCContactDetails contactdetails)
        {
            contactdetails.ContactID = _context.WCContactDetails.Max(WCC => WCC.ContactID) + 1;
            _context.Add(contactdetails);
            await _context.SaveChangesAsync();
            return contactdetails;
        }
        public async Task<IEnumerable<WCCustomerDetails>> GetAll()
        {
            return await _context.WCCustomerDetails.ToListAsync();
        }

        public async Task<WCCustomerDetails> GetCustomerDetails(int ID)
        {
            /*var Customer= _context.WCCustomerDetails.Include(Con => Con.ContactDetails);
             //return await _context.WCCustomerDetails.FirstOrDefaultAsync(cust => cust.CustomerID == ID);
             return await Customer.FirstOrDefaultAsync(cust => cust.CustomerID == ID);*/

            
            var Customer = _context.WCCustomerDetails.Include(Con => Con.ContactDetails);
            return await Customer.FirstOrDefaultAsync(cust => cust.CustomerID == ID);
        }

        public async Task<WCContactDetails> GetContactDetails(int ContactID)
        {
            return await _context.WCContactDetails.FirstOrDefaultAsync(contact => contact.ContactID == ContactID);
        }

        public async Task<IEnumerable<WCContactDetails>> GetContactDetailsByCustomerID(int CustomerID)
        {
            var Contacts = from WCC in _context.WCContactDetails
                            select WCC;

            if (CustomerID>0)
            {
                Contacts = Contacts.Where(WCC => WCC.CustomerID== CustomerID);
            }

            Contacts = Contacts.OrderByDescending(WCC => WCC.ContactPerson);
         
            return await Contacts.ToListAsync();
        }
        public async Task<IEnumerable<WCCustomerDetails>> SearchCustomers(EnumCustomerSortOrder sortOrder, string searchString)
        {
            var Customers = from WCC in _context.WCCustomerDetails
                           select WCC;

            if (!String.IsNullOrEmpty(searchString))
            {
                Customers = Customers.Where(WCC => WCC.FirstName.Contains(searchString) || WCC.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case EnumCustomerSortOrder.FirstName:
                    Customers = Customers.OrderByDescending(WCC => WCC.FirstName);
                    break;
                default:
                    Customers = Customers.OrderByDescending(WCC => WCC.LastName);
                    break;
            }
            return await Customers.ToListAsync();
            //return _context.WCCustomerDetails.Where(cust => (cust.FirstName == firstName || cust.LastName == lastname));
        }
        /*
        public IEnumerable<WCCustomerDetails> SearchCustomers(string Name, EnumCustomerSearchType searchType)
        {
            switch (searchType)
            {
                case EnumCustomerSearchType.FirstName:
                    {
                        return _context.WCCustomerDetails.Where(cust => (cust.FirstName == Name));

                    }

                case EnumCustomerSearchType.LastName:
                    {
                        return _context.WCCustomerDetails.Where(cust => (cust.LastName == Name));

                    }
                default:
                    return null;
            }
        }*/

    }
}
