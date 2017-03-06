using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCCourseMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        [ForeignKey("WCCourseType")]
        public int CourseTypeID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public int Duration{ get; set; }
        public WCCourseType CourseType { get; set; }
        public ICollection<WCCourseDetails> CourseDetails { get; set; }

        public ICollection<WCCourseSchedule> CourseSchedule { get; set; }

    }
}
