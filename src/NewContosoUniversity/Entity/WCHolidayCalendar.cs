using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewContosoUniversity.Entity
{
    public class WCHolidayCalendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HolidayID { get; set; }
        public DateTime HolidayStartDateTime { get; set; }
        public DateTime HolidayEndDateTime { get; set; }
        public string HolidayReason { get; set; }

    }
}
