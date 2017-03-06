using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCCourseType
    {
        /*WeekEnd = 1,
        SixMonth = 2,
        OneWeek = 3,
        OneMonth = 4*
        */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseTypeID { get; set; }
        public string CourseTypeDesc { get; set; }


    }
}
