using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCRoleMaster
    {
        private ICollection<WCStaffRole> _lstStaffroles;

        /* CourseChef=1,
CourseMarketing=2,
CourseContentCreator=3,
CourseAssitants=4,
ProgramManagement=5,
CourseCreator=6,
Councellor=7*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }
        public string RoleDescription { get; set; }

        public ICollection<WCStaffRole> StaffRoles
        {
            get
            {
                return _lstStaffroles;
            }
            set
            {
                _lstStaffroles = value;
            }
        }

    }
}
