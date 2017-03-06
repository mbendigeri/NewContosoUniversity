using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCCourseSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseScheduleID { get; set; }

        [ForeignKey("WCCourseMaster")]
        public int CourseID { get; set; }
        /*
         * Jan 17 6 Month 
         * Jan 17 1st Weekend 
         * Jan 17 2nd Weekend
         * Feb 17 6 Month
         */

        public string CourseScheduleName { get; set; }
        
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public WCCourseMaster Course { get; set; }

        //This is will be a filtereed calnder that is applicable for the course

    }
}
