using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    //An interaction can also end with a Request for facetoface Meeting
    //The F2F meeting can be with Chef during intial phase and may be with a Staff to finalize the course, schedule,payment

    public class WCFaceToFaceMeeting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaceToFaceMeetingID { get; set; }
        [ForeignKey("WCInteractions")]
        public int InteractionID { get; set; }
        [ForeignKey("WCStaffDetails")]
        public int staffID { get; set; }
        [ForeignKey("WCCourseMaster")]
        public int courseID
        {
            get; set;
        }
        public DateTime FaceToFaceMeetingDateTime { get; set; }


        //Expected batch of joining
        public int AllotedTimeInMinutes { get; set; }

        public int CompletedTimeInMinutes { get; set; }

        public WCInteraction Interaction { get; set; }

        public WCStaffDetails Staff { get; set; }

        public WCCourseMaster Course{ get; set; }


    }
}
