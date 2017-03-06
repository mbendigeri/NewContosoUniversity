using NewContosoUniversity.Data;
using NewContosoUniversity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace NewContosoUniversity.Services
{
    public class SvcWCMasterData : ISvcWCMasterData
    {
        private NewContosoUniversityDBContext _context;
        public SvcWCMasterData(NewContosoUniversityDBContext context)
        {
            _context = context;
        }
        public async Task<WCCourseMaster> Add(WCCourseMaster Course)
        {
            _context.Add(Course);
            await _context.SaveChangesAsync();
            return Course;
        }

        public async Task<WCCourseType> Add(WCCourseType CourseType)
        {
            _context.Add(CourseType);
            await _context.SaveChangesAsync();
            return CourseType;
        }

        public async Task<WCRoleMaster> Add(WCRoleMaster Role)
        {
            _context.Add(Role);
            await _context.SaveChangesAsync();
            return Role;
        }

        public async Task<WCCommunicationChannelType> Add(WCCommunicationChannelType CommunicationChannel)
        {
            _context.Add(CommunicationChannel);
            await _context.SaveChangesAsync();
            return CommunicationChannel;
        }

        public async Task<WCHolidayCalendar> Add(WCHolidayCalendar Calendar)
        {
            _context.Add(Calendar);
            await _context.SaveChangesAsync();
            return Calendar;
        }

        public async Task<IEnumerable<WCCommunicationChannelType>> GetAllCommunicationTypes()
        {
            return await _context.WCCommunicationChannelType.ToListAsync();
        }

        public async Task<IEnumerable<WCCourseMaster>> GetAllCourses()
        {
            return await _context.WCCourseMaster.ToListAsync();
        }

        public async Task<IEnumerable<WCCourseType>> GetAllCourseTypes()
        { 
            return await _context.WCCourseType.ToListAsync();
        }

        public async Task<IEnumerable<WCHolidayCalendar>> GetAllHolidays()
        {
            return await _context.WCHolidayCalendar.ToListAsync();
        }

        public async Task<IEnumerable<WCRoleMaster>> GetAllRoles()
        {
            return await _context.WCRoleMaster.ToListAsync();
        }
        public async Task<IEnumerable<WCStaffDetails>> GetAllTutorStaff(string searchString)
        {
            //var Staff = _context.WCStaffDetails.Include(RM => RM.Roles);

            var Staff = from WCS in _context.WCStaffDetails
                        from RM in WCS.StaffRoles.Where(RM => RM.Role.RoleDescription==searchString)
                        select WCS;
            

           /*
            var Staff = _context.WCStaffRole
                             .Include(WCS => WCS.Staff)
                             .Include(WCS => WCS.Role)
                             .Where(WCSR => WCSR.Role.RoleDescription == "Chef")
                             .Select(pt => pt.Staff);
                            */

            /*
            var Staff1 = from Staff in _context.WCStaffDetails
                        from Role in Staff.StaffRoles
                        select new
                        {
                            firstname = Staff.FirstName,
                            Role1 = Role.Role.RoleDescription,
                        } ;
            */
            //return await _context.WCStaffDetails.ToListAsync();
            return await Staff.ToListAsync();
        }
    }
}