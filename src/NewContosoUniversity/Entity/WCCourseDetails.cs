using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{

    public class WCCourseDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseDetailID { get; set; }
        [ForeignKey("WCCourseMaster")]
        public int CourseID { get; set; }

        public string CourseChapter{ get; set; }

        public string CourseChapterDescription { get; set; }

        public WCCourseMaster Course { get; set; }
    }
}
