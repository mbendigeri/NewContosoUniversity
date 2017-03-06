using NewContosoUniversity.Entity;
using NewContosoUniversity.Entity.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewContosoUniversity.Services
{
    public interface ISvcWCCustomerDetails
    {

        Task<IEnumerable<WCCustomerDetails>> GetAll();
        Task<WCCustomerDetails> GetCustomerDetails(int ID);

        Task<WCContactDetails> GetContactDetails(int ContactID);

        Task<IEnumerable<WCContactDetails>> GetContactDetailsByCustomerID(int CustomerID);
        Task<WCCustomerDetails> Add(WCCustomerDetails customerDetails);

        Task<WCContactDetails> Add(WCContactDetails contactDetails);
        Task<IEnumerable<WCCustomerDetails>> SearchCustomers(EnumCustomerSortOrder sortOrder, string searchString);

   
    }
}