using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCInteraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InteractionID { get; set; }

        [ForeignKey("WCnteractiontype")]
        public int InteractiontypeID { get; set; }

        /// <summary>
        /// Added newly
        /// </summary>
        [ForeignKey("WCCustomerDetails")]
        public int CustomerID { get; set; }

        [ForeignKey("WCContactDetails")]
        public int ContactID { get; set; }

        [ForeignKey("WCFaceToFaceMeeting")]
        public int? FaceToFaceMeetingID { get; set; }

        [ForeignKey("WCC")]
        public int CommunicationChannelTypeID { get; set; }
        public string Discussion { get; set; }

        public DateTime InteractDateTime { get; set; }

        
        public DateTime? CallBackStartDate { get; set; }
        public DateTime? CallBackEndDate { get; set; }

        public DateTime? CallBackStartTime { get; set; }
        public DateTime? CallBackEndTime { get; set; }
        
        public WCInteractionType Interactiontype { get; set; }
        public WCCommunicationChannelType CommunicationChannelType{ get; set; }

        public WCContactDetails Contact{ get; set; }

        public ICollection<WCInterestedCourses> InterestedCourses { get; set; }

        /// <summary>
        /// Ideally we will have only one face to face meeting for an interaction
        /// But I have still designed to have multiple F2F meeting for a single interaction
        /// </summary>
        public ICollection<WCFaceToFaceMeeting> FaceToFaceMeeting{ get; set; }



    }
    

}
