using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCInterestedCourses
    {


       
        public int InteractionID { get; set; }

       
        public int CourseID { get; set; }

        /// <summary>
        /// This is Selected Course Schedule. This is not available Schedule
        /// </summary>
        public int CourseScheduleID { get; set; }

        [ForeignKey("InteractionID")]
        public WCInteraction Interaction{ get; set; }

        [ForeignKey("CourseID")]
        public WCCourseMaster Course { get; set; }

        [ForeignKey("CourseScheduleID")]
        /// This is Selected Course Schedule. This is not available Schedule
        public WCCourseSchedule CourseSchedule { get; set; }
    }
}
