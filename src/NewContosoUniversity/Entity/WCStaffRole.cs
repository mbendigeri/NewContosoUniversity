using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCStaffRole
    {


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StaffID { get; set; }


        [ForeignKey("StaffID")]
        public WCStaffDetails Staff { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }


        [ForeignKey("RoleID")]
        public WCRoleMaster Role { get; set; }

    }
    
}
