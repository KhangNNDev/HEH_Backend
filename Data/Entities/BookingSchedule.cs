using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BookingSchedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid bookingScheduleID { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User User { get; set; }
        public Guid? profileID { get; set; }
        [ForeignKey("profileID")]
        public virtual SubProfile? SubProfile { get; set; }
        public Guid? scheduleID { get; set; }
        [ForeignKey("scheduleID")]
        public virtual Schedule Schedule { get; set; }
        public DateTime dateBooking { get; set; }
        public DateTime timeBooking { get; set; }
        public bool status { get; set; }
    }
}
