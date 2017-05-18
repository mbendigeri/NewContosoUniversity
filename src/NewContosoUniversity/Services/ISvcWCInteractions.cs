using NewContosoUniversity.Entity;
using NewContosoUniversity.Entity.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewContosoUniversity.Services
{
    public interface ISvcWCInteractions
    {
        Task<WCInteraction> Add(WCInteraction Interaction);
        Task<WCFaceToFaceMeeting> Add(WCFaceToFaceMeeting F2FMeeting);
        Task<WCInterestedCourses> Add(WCInterestedCourses InterestedCourse);

        Task<IEnumerable<WCInteraction>> GetAll();
        Task<WCInteraction> GetInteractionDetails(int interactionID);

        Task<IEnumerable<WCInterestedCourses>> GetLastInterestedCourses(int CustomerID);
        
        Task<WCInteraction> FindLatestInteraction(int CustomerID);
        Task<IEnumerable<WCInteraction>> FindInteractionsByCustomerID(int CustomerID);
        
        

    }
}