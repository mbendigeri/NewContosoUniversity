using NewContosoUniversity.Entity;
using NewContosoUniversity.Entity.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewContosoUniversity.Services
{
    public interface ISvcWCMasterData
    {
        Task<WCHolidayCalendar> Add(WCHolidayCalendar Calendar);
        Task<IEnumerable<WCHolidayCalendar>> GetAllHolidays();

        Task<WCCourseMaster> Add(WCCourseMaster Course);
        Task<IEnumerable<WCCourseMaster>> GetAllCourses();

        Task<WCCourseType> Add(WCCourseType CourseType);
        Task<IEnumerable<WCCourseType>> GetAllCourseTypes();

        Task<WCRoleMaster> Add(WCRoleMaster Role);
        Task<IEnumerable<WCRoleMaster>> GetAllRoles();

        Task<WCCommunicationChannelType> Add(WCCommunicationChannelType CommunicationChannel);
        Task<IEnumerable<WCCommunicationChannelType>> GetAllCommunicationTypes();

        Task<IEnumerable<WCStaffDetails>> GetAllTutorStaff(string searchString);

    }
}