using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCInteractionType
    {

        /*
             Inquiry = 1,
             F2FMeeting= 2,
             HouseWife = 3,
             Business = 4
             */
             [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InteractionTypeID { get; set; }
        public string InteractionTypeDesc { get; set; }

        /*
        /// <summary>
        /// This is not required. In case we want to know how interactions are of a particular type. Then the below collection will help
        /// </summary>
        public ICollection<WCInteractions> Interactions{ get; set; }
        */
    }
}
